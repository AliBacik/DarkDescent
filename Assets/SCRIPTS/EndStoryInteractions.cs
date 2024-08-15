using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndStoryInteractions : MonoBehaviour
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
  

    public GameObject speechOneCanvas;
    public GameObject phone;
    public GameObject elevator;
    public GameObject elevatorTwo;
    public Animator animatorElevator;
    public Animator animatorElevator2;
    public GameObject endCanvas;
    public GameObject optionMenu;
    public GameObject controlCanvas;
    public bool phoneRange;
 
    public static bool phoneDestroyed;
    public bool Pressed;
    public bool outButton;
    public bool outButtonTwo;
    public bool elevDoorFirst;
    public bool elevDoorSec;
    public bool optionButtonPressed;


    private void Start()
    {
 
        phoneDestroyed = false;
        Pressed = false;
       

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

        if (Pressed && phoneRange && phoneDestroyed == false)
        {

            
            IsNotPressed();
            StartCoroutine(speechCall());
            Destroy(phone); // telefon yokedildi
            
            phoneRange = false;
            
            phoneDestroyed = true; // telefon yokedildi
            

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



        ///PC///
        ///
        if (Input.GetKeyDown(KeyCode.E) && phoneRange && phoneDestroyed == false)
        {


            IsNotPressed();
            StartCoroutine(speechCall());
            Destroy(phone); // telefon yokedildi

            phoneRange = false;

            phoneDestroyed = true; // telefon yokedildi


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


    }


    public void quitApp()
    {
        Application.Quit();
    }
    IEnumerator speechCall()
    {
        yield return new WaitForSeconds(1f);
        speechOneCanvas.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        speechOneCanvas.SetActive(false);
        endCanvas.SetActive(true);
        yield return new WaitForSeconds(9f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -3);
        Application.Quit();
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

    public void IsPressed()
    {
        Pressed = true;

    }

    public void IsNotPressed()
    {
        Pressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
   

        if (other.CompareTag("phone"))
        {
            
            phoneRange = true;
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("pickable"))
        {
            
            phoneRange = false;

        }

     
       
    }
}