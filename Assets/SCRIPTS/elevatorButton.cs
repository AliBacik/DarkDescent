using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer.Internal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class elevatorButton : MonoBehaviour
{

    [Header("Audio")]
    [SerializeField] private AudioSource elevatorOpenAudioSource = null;
    
    [Space(10)]
    [SerializeField] private AudioSource elevatorCloseAudioSource = null;
    
    [Space(10)]
    [SerializeField] private AudioSource elevatorWorksAudioSource = null;
    [SerializeField] private AudioSource elevatorButtonSource = null;

    public AnomalyManager anomalyCall;
    [Space(10)]
    public GameObject storyEndEyeClose;
    [Space(10)]

    public FloorChecker floorCheck;
    public GameObject NotRotatedScene;
    public GameObject RotatedScene;

    public elevatorButtonTwo secElevUsed;
    public GameObject FloorNumberSignes;   
    public GameObject elevator;
    public Animator animator;
   
    

    public static bool buttonOnePressed;
    public bool isClosed;
    public bool ButtonInsideRange;
    public bool FirstElevUsed;
    public bool Pressed;
    public bool rotated;
    public int CurrentFloor;
    
    public int lastFloor;
    
    // Start is called before the first frame update
    void Start()
    {
 
        FirstElevUsed = false;
        isClosed = true;
        elevator = GameObject.Find("Elevator");
        Animator otherAnimator = elevator.GetComponent<Animator>();         
        rotated = false;              
        lastFloor=10;
        storyEndEyeClose.SetActive(false);

    }

    void Update()
    {

        CurrentFloor = floorCheck.floorNumberPlayer;
        Debug.Log("elev 1 current floor "+ CurrentFloor );
        Debug.Log("elev 1 last " + lastFloor);


        if (FirstElevUsed == true && anomalyCall.anomalyLoaded == true && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
        {

            if (CurrentFloor < lastFloor)
            {
                if (floorCheck.elevatorOneRotated == true && CurrentFloor != 1 && CurrentFloor != 10 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(loadLevel());

                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;


                }


                if (CurrentFloor == 1 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    
                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;
                    StartCoroutine(StoryEndNextScene());
                }


            }


            if (CurrentFloor == lastFloor)
            {
                if (floorCheck.elevatorOneRotated == true && CurrentFloor != 1 && lastFloor != 10 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(loadLevel());


                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;
                }

                if (CurrentFloor == 1 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    // HÝKAYE SONU //
                   
                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;
                    /////////////////////////////
                    StartCoroutine(StoryEndNextScene());
                    /////////////////////////////

                }


            }

        }

        else if (FirstElevUsed == true && anomalyCall.anomalyLoaded == false && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
        {

            if (CurrentFloor < lastFloor)
            {
                if (floorCheck.elevatorOneRotated == true && CurrentFloor != 10 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(goBack()); ////EN BAÞA ATACAK FONKSÝYON BURAYA

                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;


                }


                if (CurrentFloor == 1 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(goBack()); ////EN BAÞA ATACAK FONKSÝYON BURAYA

                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;
                }


            }
            if (CurrentFloor == lastFloor)
            {
                if (floorCheck.elevatorOneRotated == true && lastFloor != 10 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(goBack()); ////EN BAÞA ATACAK FONKSÝYON BURAYA


                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;
                }

                if (floorCheck.elevatorTwoRotated == true && lastFloor != 10 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(goBack()); ////EN BAÞA ATACAK FONKSÝYON BURAYA


                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;
                }


                if (CurrentFloor == 1 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(goBack()); ////EN BAÞA ATACAK FONKSÝYON BURAYA

                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;
                }


            }
        }

        else if (FirstElevUsed == false && anomalyCall.anomalyLoaded == false && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
        {
            if (CurrentFloor < lastFloor)
            {
                if (floorCheck.elevatorOneRotated == true && CurrentFloor != 1 && CurrentFloor != 10 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                   
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(loadLevel());

                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;


                }


                if (CurrentFloor == 1 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    
                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;
                    StartCoroutine(StoryEndNextScene());
                }


                if (floorCheck.elevatorOneRotated == false && CurrentFloor != 1 && CurrentFloor != 10 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                  
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(loadLevel());

                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;


                }

            }
            if (CurrentFloor == lastFloor)
            {
                if (floorCheck.elevatorTwoRotated == true && CurrentFloor != 1 && lastFloor != 10 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                   
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(loadLevel());


                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;
                }


                if (CurrentFloor == 1 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    
                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;
                    StartCoroutine(StoryEndNextScene());
                }

                if (floorCheck.elevatorOneRotated == false && CurrentFloor != 1 && lastFloor != 10 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                   
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(loadLevel());


                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;
                }
            }

        }

        else if (FirstElevUsed == false && anomalyCall.anomalyLoaded == true && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
        {
            if (CurrentFloor < lastFloor)
            {
                if (floorCheck.elevatorOneRotated == true && CurrentFloor != 10 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(goBack());

                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;


                }


                if (CurrentFloor == 1 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(goBack());

                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;
                }

                if (floorCheck.elevatorOneRotated == false && CurrentFloor != 1 && CurrentFloor != 10 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(goBack());

                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;


                }

            }

            if (CurrentFloor == lastFloor)
            {
                if (floorCheck.elevatorOneRotated == true && CurrentFloor != 1 && CurrentFloor != 10 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(goBack());

                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;


                }
                if (floorCheck.elevatorTwoRotated == true && CurrentFloor != 1 && CurrentFloor != 10 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(goBack());

                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;


                }
                if (CurrentFloor == 1 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                  
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(goBack());

                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;
                }
            }


        }

       

        /// ///////////////////MOBÝL//////////////////
        /// 


        if (FirstElevUsed == true && anomalyCall.anomalyLoaded == true && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
        {

            if (CurrentFloor < lastFloor)
            {
                if (floorCheck.elevatorOneRotated == true && CurrentFloor != 1 && CurrentFloor != 10 && Pressed && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    IsNotPressed();
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(loadLevel());

                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;


                }


                if (CurrentFloor == 1 && Pressed && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    IsNotPressed();
                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;
                    StartCoroutine(StoryEndNextScene());
                }


            }


            if (CurrentFloor == lastFloor)
            {
                if (floorCheck.elevatorOneRotated == true && CurrentFloor != 1 && lastFloor != 10 && Pressed && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    IsNotPressed();
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(loadLevel());


                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;
                }

                if (CurrentFloor == 1 && Pressed && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    // HÝKAYE SONU //
                    IsNotPressed();
                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;
                    /////////////////////////////
                    StartCoroutine(StoryEndNextScene());
                    /////////////////////////////
                    
                }


            }

        }

        else if (FirstElevUsed == true && anomalyCall.anomalyLoaded == false && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
        {

            if (CurrentFloor < lastFloor)
            {
                if (floorCheck.elevatorOneRotated == true  && CurrentFloor != 10 && Pressed && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    IsNotPressed();
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(goBack()); ////EN BAÞA ATACAK FONKSÝYON BURAYA

                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;


                }


                if (CurrentFloor == 1 && Pressed && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    IsNotPressed();
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(goBack()); ////EN BAÞA ATACAK FONKSÝYON BURAYA

                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;
                }


            }
            if (CurrentFloor == lastFloor)
            {
                if (floorCheck.elevatorOneRotated == true && lastFloor != 10 && Pressed && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    IsNotPressed();
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(goBack()); ////EN BAÞA ATACAK FONKSÝYON BURAYA


                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;
                }

                if (floorCheck.elevatorTwoRotated == true && lastFloor != 10 && Pressed && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    IsNotPressed();
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(goBack()); ////EN BAÞA ATACAK FONKSÝYON BURAYA


                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;
                }


                if (CurrentFloor == 1 && Pressed && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    IsNotPressed();
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(goBack()); ////EN BAÞA ATACAK FONKSÝYON BURAYA

                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;
                }


            }
        }

        else if (FirstElevUsed == false && anomalyCall.anomalyLoaded == false && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
        {
            if (CurrentFloor < lastFloor)
            {
                if (floorCheck.elevatorOneRotated == true && CurrentFloor != 1 && CurrentFloor != 10 && Pressed && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    IsNotPressed();
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(loadLevel());

                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;


                }


                if (CurrentFloor == 1 && Pressed && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    IsNotPressed();
                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;
                    StartCoroutine(StoryEndNextScene());
                }


                if (floorCheck.elevatorOneRotated == false && CurrentFloor != 1 && CurrentFloor != 10 && Pressed && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    IsNotPressed();
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(loadLevel());

                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;


                }

            }
            if (CurrentFloor == lastFloor)
            {
                if (floorCheck.elevatorTwoRotated == true && CurrentFloor != 1 && lastFloor != 10 && Pressed && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    IsNotPressed();
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(loadLevel());


                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;
                }


                if (CurrentFloor == 1 && Pressed && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    IsNotPressed();
                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;
                    StartCoroutine(StoryEndNextScene());
                }

                if (floorCheck.elevatorOneRotated == false && CurrentFloor != 1 && lastFloor != 10 && Pressed && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    IsNotPressed();
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(loadLevel());


                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;
                }
            }

        }

        else if (FirstElevUsed == false && anomalyCall.anomalyLoaded == true && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
        {
            if (CurrentFloor < lastFloor)
            {
                if (floorCheck.elevatorOneRotated == true && CurrentFloor != 10 && Pressed && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    IsNotPressed();
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(goBack());

                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;


                }


                if (CurrentFloor == 1 && Pressed && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    IsNotPressed();
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(goBack());

                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;
                }

                if (floorCheck.elevatorOneRotated == false && CurrentFloor != 1 && CurrentFloor != 10 && Pressed && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    IsNotPressed();
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(goBack());

                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;


                }

            }

            if (CurrentFloor == lastFloor)
            {
                if (floorCheck.elevatorOneRotated == true && CurrentFloor != 1 && CurrentFloor != 10 && Pressed && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    IsNotPressed();
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(goBack());

                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;


                }
                if (floorCheck.elevatorTwoRotated == true && CurrentFloor != 1 && CurrentFloor != 10 && Pressed && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    IsNotPressed();
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(goBack());

                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;


                }
                if (CurrentFloor == 1 && Pressed && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    IsNotPressed();
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(goBack());

                    isClosed = false;
                    FirstElevUsed = true;
                    secElevUsed.SecElevUsed = false;
                }
            }


        }



    }

    public IEnumerator StoryEndNextScene()
    {
        /////////////////////////////
        storyEndEyeClose.SetActive(true);
        yield return new WaitForSeconds(4.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        /////////////////////////////
    }

    public void IsPressed()
    {
        Pressed = true;
        
       

    }

    public void IsNotPressed()
    {
        Pressed = false;
    }










    IEnumerator goBack()
    {
        CloseDoor();
        yield return new WaitForSeconds(1f);
        workDoor();
        StartCoroutine(loadLvlfirst());
        anomalyCall.ResetAnomalies();
        yield return new WaitForSeconds(6f);      
        anomalyCall.LoadAnomaly();
        OpenDoor();
    }

    IEnumerator loadLvlfirst()
    {
        yield return new WaitForSeconds(3f);

        int lvlFirst = 10;

        GameObject floorNumbers = GameObject.Find("FloorNumbers");

        foreach (Transform child in floorNumbers.transform)
        {
            child.gameObject.SetActive(false);
        }

        //Transform floorNumberSign = floorNumbers.transform.Find("floorNumber" + lvlFirst);
        //Transform floorNumberSign_2 = floorNumbers.transform.Find("floorNumber" + lvlFirst + "_2");
        Transform floorNumberSign2 = floorNumbers.transform.Find("floorNumber" + (lvlFirst - 1));
        Transform floorNumberSign2_2 = floorNumbers.transform.Find("floorNumber" + (lvlFirst - 1) + "_2");
        //floorNumberSign.gameObject.SetActive(false);
        //floorNumberSign_2.gameObject.SetActive(false);
        floorNumberSign2.gameObject.SetActive(true);
        floorNumberSign2_2.gameObject.SetActive(true);
        

        if (floorCheck.elevatorOneRotated == true)
        {
            NotRotatedScene.SetActive(true);
            RotatedScene.SetActive(false);      
            
            floorCheck.elevatorOneRotated = true;
            floorCheck.elevatorTwoRotated = false;           
            lastFloor = lvlFirst - 1;
            secElevUsed.lastFloor = lastFloor;
            floorCheck.floorNumberPlayer = lastFloor;
        }
        if (floorCheck.elevatorOneRotated == false)
        {

            RotatedScene.SetActive(false);
            NotRotatedScene.SetActive(true);
            floorCheck.elevatorOneRotated = true;
            floorCheck.elevatorTwoRotated = false;

            lastFloor = lvlFirst - 1;
            secElevUsed.lastFloor = lastFloor;
            floorCheck.floorNumberPlayer = lastFloor;


        }
    }

    IEnumerator loadLevel()        
    {
        CloseDoor();
        yield return new WaitForSeconds(1);
        workDoor();
        yield return new WaitForSeconds(6); // 5 saniye beklet


        if (CurrentFloor == lastFloor)
        {
            int num = lastFloor;
            
            GameObject floorNumbers = GameObject.Find("FloorNumbers");
            Transform floorNumberSign = floorNumbers.transform.Find("floorNumber" + num);
            Transform floorNumberSign_2 = floorNumbers.transform.Find("floorNumber" + num + "_2");
            Transform floorNumberSign2 = floorNumbers.transform.Find("floorNumber" + (num - 1));
            Transform floorNumberSign2_2 = floorNumbers.transform.Find("floorNumber" + (num - 1) + "_2");
            floorNumberSign.gameObject.SetActive(false);
            floorNumberSign_2.gameObject.SetActive(false);
            floorNumberSign2.gameObject.SetActive(true);
            floorNumberSign2_2.gameObject.SetActive(true);

            lastFloor = lastFloor - 1;
            floorCheck.floorNumberPlayer = lastFloor;


            if (floorCheck.elevatorOneRotated==true)
            {
                
                RotatedScene.SetActive(false);
                NotRotatedScene.SetActive(true);
                floorCheck.elevatorOneRotated = true;
                floorCheck.elevatorTwoRotated = false;

            }

            if (floorCheck.elevatorOneRotated == false)
            {
                NotRotatedScene.SetActive(true);
                RotatedScene.SetActive(false);
                
                floorCheck.elevatorTwoRotated = false;
                floorCheck.elevatorOneRotated = true;

            }

        }
       
        if (CurrentFloor < lastFloor)
        {

            int num = CurrentFloor;
            
            GameObject floorNumbers = GameObject.Find("FloorNumbers");
            Transform floorNumberSign = floorNumbers.transform.Find("floorNumber" + num);
            Transform floorNumberSign_2 = floorNumbers.transform.Find("floorNumber" + num + "_2");
            Transform floorNumberSign2 = floorNumbers.transform.Find("floorNumber" + (num - 1));
            Transform floorNumberSign2_2 = floorNumbers.transform.Find("floorNumber" + (num - 1) + "_2");
            floorNumberSign.gameObject.SetActive(false);
            floorNumberSign_2.gameObject.SetActive(false);
            floorNumberSign2.gameObject.SetActive(true);
            floorNumberSign2_2.gameObject.SetActive(true);

            CurrentFloor = CurrentFloor - 1;
            floorCheck.floorNumberPlayer = CurrentFloor;
            lastFloor = CurrentFloor;

            if (floorCheck.elevatorTwoRotated == true)
            {


                RotatedScene.SetActive(false);
                NotRotatedScene.SetActive(true);
                

                floorCheck.elevatorOneRotated = true;
                floorCheck.elevatorTwoRotated = false;


            }
            
            
           

        }
        //anomalyCall.ResetAnomaly();
        anomalyCall.LoadAnomaly();
        OpenDoor();

        }

    public void workDoor() 
    {
    elevatorWorksAudioSource.Play();
    
    }
    public void OpenDoor()
        {
           
            animator.SetTrigger("controlElevator");
            elevatorOpenAudioSource.Play();
            elevatorButtonSource.Play();
            
        }

    public void CloseDoor()
        {
           
            animator.SetTrigger("controlElevator");
            elevatorCloseAudioSource.Play();
            elevatorButtonSource.Play();
            
        }

    void OnTriggerEnter(Collider other)
        {
        if (other.CompareTag("Player"))
        {
            ButtonInsideRange = true;
            

        }
       
    }

    void OnTriggerExit(Collider other)
        {
        if (other.CompareTag("Player") )
        {
            ButtonInsideRange = false;
        }
        

    }

    
}
