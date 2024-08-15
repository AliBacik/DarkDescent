using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractions : MonoBehaviour
{


    [Header("AudioElevator")]
    [SerializeField] private AudioSource elevatorOpenAudioSource = null;

    [Space(10)]
    [SerializeField] private AudioSource elevatorCloseAudioSource = null;

    [Space(10)]
    [SerializeField] private AudioSource elevatorWorksAudioSource = null;
    [SerializeField] private AudioSource elevatorButtonSource = null;

    [Header("AudioElevator2")]
    [SerializeField] private AudioSource elevatorOpenSecAudioSource = null;

    [Space(10)]
    [SerializeField] private AudioSource elevatorCloseSecAudioSource = null;

    [Space(10)]
    [SerializeField] private AudioSource elevatorWorksSecAudioSource = null;
    [SerializeField] private AudioSource elevatorButtonSecSource = null;

    [Header("Audio")]
    [SerializeField] private AudioSource phoneRingSource = null;
    [SerializeField] private AudioSource torchPickAudioSource = null;

    [SerializeField] private LayerMask phoneLayer;
    
    public static bool objectPickedUp; // obje baþlangýçta alýnmadý
    public bool torchLightControl; // el feneri baþlangýçta kapalý
    public bool PlayerInRangePickUp;
    public bool phoneRange;
    public static bool phoneDestroyed;
    public bool phoneRinging;
    public bool outButton;
    public bool outButtonTwo;
    public bool elevDoorFirst;
    public bool elevDoorSec;
    public bool Pressed;
    public bool flashPressed;
    public bool optionButtonPressed;

    //public elevatorButton buttonControl;
    //public elevatorButton buttonControlTwo;
    private RaycastHit hit;
    public GameObject elevator;
    public GameObject elevatorTwo;
    public Animator animatorElevator;
    public Animator animatorElevator2;
    public GameObject torchModel; // modeli kamerada etkinleþtirmek için    
    public GameObject torchLight;
    public GameObject selectedObject;
    public GameObject phone;
    public GameObject conversationCanvas;
    public GameObject SpeechToTrigger;
    public GameObject talk;
    Renderer myRenderer;
    public GameObject optionMenu;
    public GameObject controlCanvas;

    public string targetMaterialName = "512"; // Emission'ý deðiþtireceðimiz hedef malzemenin adý
   
    public float emissionIntensity = 8.0f; // Emission yoðunluðu


    private void Start()
    {
       
        elevator = GameObject.Find("Elevator");
        Animator otherAnimator = elevator.GetComponent<Animator>();
        elevatorTwo = GameObject.Find("Elevator (1)");
        Animator otherAnimatorTwo = elevator.GetComponent<Animator>();
        phoneRinging = false;
        phoneDestroyed = false;
        talk.SetActive(false);
        StartCoroutine(ringPlay());        
        selectedObject.SetActive(false);
        objectPickedUp = false;
        torchLightControl = false;
        torchModel.SetActive(false);
        conversationCanvas.SetActive(false);
        SpeechToTrigger.SetActive(false);
        optionButtonPressed = false;
        
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (optionButtonPressed == true)
            {
                backButtonPressed();
                        
            }
            if (optionButtonPressed == false)
            {
                optionButtonPress();
            }
            
            

        }
        

        // scriptin içindeki duruma göre player in range pick up' ý döndürür

        if (PlayerInRangePickUp && Input.GetKeyDown(KeyCode.E))
        {
            if (objectPickedUp == false && phoneRinging == false)
            {
                takeObject();
                objectPickedUp = true;
                PlayerInRangePickUp = false;
                StartCoroutine(triggerSpeech());

            }
        }


        // MOBÝL //
        if (PlayerInRangePickUp && Pressed)
        {
            if (objectPickedUp == false && phoneRinging == false)
            {
                takeObject();
                objectPickedUp = true;
                PlayerInRangePickUp = false;
                StartCoroutine(triggerSpeech());

            }
        }



        /////////////// MOBÝL ////////////////////////


        if (flashPressed && objectPickedUp)
        {
            
            TurnedOnOffTorch();


        }

        //////////////////////////////////////////////
        ///

        if (Input.GetKeyDown(KeyCode.F) && objectPickedUp)
        {
            Debug.Log("F tuþuna basýldý");
            TurnedOnOffTorch();


        }

        if (Input.GetKeyDown(KeyCode.E) && phoneRange && phoneDestroyed == false && phoneRinging == true)
        {

            phoneAnswer();
            Destroy(phone); // telefon yokedildi
            phoneRange = false;
            phoneRinging = false;
            phoneDestroyed = true; // telefon yokedildi
            talk.SetActive(false);
            conversationCanvas.SetActive(true);
            StartCoroutine(conversationCanvasDiss());
            StartCoroutine(canvasdisappear());



        }
        if (Input.GetKeyDown(KeyCode.E) && outButton == true)
        {

            OpenDoor();
            elevDoorFirst = true;

        }
        if (Input.GetKeyDown(KeyCode.E) && outButtonTwo == true)
        {

            OpenDoorSec();
            elevDoorSec = true;
        }
        if (Input.GetKeyDown(KeyCode.E) && outButton == true && elevDoorFirst == true)
        {

            CloseDoor();
            elevDoorFirst = false;

        }
        if (Input.GetKeyDown(KeyCode.E) && outButtonTwo == true && elevDoorSec == true)
        {

            CloseDoorSec();
            elevDoorSec = false;
        }

        ///////////////////////////MOBÝL///////////////////////////////////
        if (Pressed && phoneRange && phoneDestroyed == false && phoneRinging == true)
        {

            phoneAnswer();
            IsNotPressed();
            Destroy(phone); // telefon yokedildi
            phoneRange = false;
            phoneRinging = false;
            phoneDestroyed = true; // telefon yokedildi
            talk.SetActive(false);
            conversationCanvas.SetActive(true);
            StartCoroutine(conversationCanvasDiss());
            StartCoroutine(canvasdisappear());



        }
        if (Pressed && outButton == true)
        {

            OpenDoor();
            elevDoorFirst = true;


        }
        if (Pressed && outButtonTwo == true)
        {

            OpenDoorSec();
            elevDoorSec = true;
        }
        if (Pressed && outButton == true && elevDoorFirst == true)
        {

            CloseDoor();
            elevDoorFirst = false;

        }
        if (Pressed && outButtonTwo == true && elevDoorSec == true)
        {

            CloseDoorSec();
            elevDoorSec = false;
        }


    }


    void SetEmissionIntensityPhone()
    {
        Renderer renderer = phone.GetComponent<Renderer>();
        Material mat = renderer.material;

        float emission = Mathf.PingPong(Time.time, 7.4f);
        Color baseColor = Color.white; //Replace this with whatever you want for your base color at emission level '1'

        Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);

        mat.SetColor("_EmissionColor", finalColor);
    }

    void SetEmissionIntensityFlash()
    {
        Renderer renderer = selectedObject.GetComponent<Renderer>();
        Material mat = renderer.material;

        float emission = Mathf.PingPong(Time.time, 3.0f);
        Color baseColor = Color.white; //Replace this with whatever you want for your base color at emission level '1'

        Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);

        mat.SetColor("_EmissionColor", finalColor);
    }
    IEnumerator conversationCanvasDiss()
    {
        yield return new WaitForSeconds(29.0f); // Wait for 36 seconds
        conversationCanvas.SetActive(false); // Deactivate 
        selectedObject.SetActive(true);
        SetEmissionIntensityFlash();
        
    }


    public void OpenDoor()
    {
        IsNotPressed();
        animatorElevator.SetTrigger("controlElevator");
        elevatorOpenAudioSource.Play();
        elevatorButtonSource.Play();
       
    }

    public void CloseDoor()
    {

        IsNotPressed();
        animatorElevator.SetTrigger("controlElevator");
        elevatorCloseAudioSource.Play();
        elevatorButtonSource.Play();
        
    }

    public void OpenDoorSec()
    {
        IsNotPressed();
        animatorElevator2.SetTrigger("controlElevator");
        elevatorOpenSecAudioSource.Play();
        elevatorButtonSecSource.Play();
      
    }

    public void CloseDoorSec()
    {
        IsNotPressed();
        animatorElevator2.SetTrigger("controlElevator");
        elevatorCloseSecAudioSource.Play();
        elevatorButtonSecSource.Play();
       
    }

    private void phoneAnswer()
    {
        
        phoneRingSource.Stop();
        
        
    }

    public void TurnedOnOffTorch()
    {
        torchLight.SetActive(!torchLightControl);
        
        torchLightControl = !torchLightControl; // ýþýk açýldý

        FlashNotPressed();

    }

    private IEnumerator triggerSpeech() 
    {
        SpeechToTrigger.SetActive(true);
        yield return new WaitForSeconds(5f);
        SpeechToTrigger.SetActive(false);
        

    }

    IEnumerator ringPlay()
    {

        yield return new WaitForSeconds(4f); // Wait for 4 second
        phoneRingSource.Play(); // activate the pickup alert
        SetEmissionIntensityPhone();
        yield return new WaitForSeconds(1f);
        talk.SetActive(true);
        phoneRinging = true;
    }

    IEnumerator canvasdisappear()
    {
        yield return new WaitForSeconds(1f); // Wait for 5 second
        talk.SetActive(false); // activate the pickup alert
    }

    public void quitApp()
    {
        Application.Quit();
    }
  
    public void IsPressed()
    {
        Pressed = true;
        
    }

    public void IsNotPressed()
    {
        Pressed = false;
    }

    public void optionButtonPress()
    {
        //controlCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;
        
        optionMenu.SetActive(true);
        optionButtonPressed = true;

    }

    public void backButtonPressed()
    {
        optionMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        //controlCanvas.SetActive(true);
        optionButtonPressed = false;
    }

    public void FlashPressed()
    {
        flashPressed = true;
        
    }
    public void FlashNotPressed()
    {
        flashPressed = false;

    }

    public void RestartButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }



    private void takeObject()
    {
        IsNotPressed();
        Destroy(selectedObject); // el fenerini sahneden sil

        torchModel.SetActive(true); // el fenerini kameraya koy

        torchLightControl = true;

        if (torchPickAudioSource != null)
        {
            torchPickAudioSource.Play();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pickable"))
        {
            PlayerInRangePickUp = true;
            
        }
      
        if (other.CompareTag("phone"))      
        {
            PlayerInRangePickUp = false;
            phoneRange = true;
        }

        if (other.CompareTag("outButton"))
        {
            outButton=true;
        }
        if (other.CompareTag("outButtonTwo"))
        {
            outButtonTwo= true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("pickable"))
        {
            PlayerInRangePickUp = false;
            phoneRange = false;
            
        }
      
        if (other.CompareTag("phone"))
        {
            PlayerInRangePickUp = false;
        }
        if (other.CompareTag("outButton"))
        {
            outButton = false;
        }
        if (other.CompareTag("outButtonTwo"))
        {
            outButtonTwo= false;
        }
    }







}
