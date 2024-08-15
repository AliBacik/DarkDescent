using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class elevatorButtonTwo : MonoBehaviour
{

    [Header("Audio")]
    [SerializeField] private AudioSource elevatorTwoOpenAudioSource = null;

    [Space(10)]
    [SerializeField] private AudioSource elevatorTwoCloseAudioSource = null;

    [Space(10)]
    [SerializeField] private AudioSource elevatorTwoWorksAudioSource = null;
    [SerializeField] private AudioSource elevatorTwoButtonSource = null;

    public AnomalyManager anomalyCall;

    [Space(10)]
    public GameObject storyEndEyeClose;
    [Space(10)]

    public FloorChecker floorCheck;
    public GameObject NotRotatedScene;
    public GameObject RotatedScene;

    public elevatorButton firstElevUsed;
    public GameObject FloorNumberSignes;
    public GameObject elevatorTwo;
    public Animator animatorTwo;

    public bool SecElevUsed;

    public bool isClosed;
    public bool ButtonInsideRange;

    public bool rotated;
    public int CurrentFloor;

    public int lastFloor;
    public bool Pressed;

    // Start is called before the first frame update
    void Start()
    {
        SecElevUsed = false;
        isClosed = true;
        elevatorTwo = GameObject.Find("Elevator (1)");
        Animator otherAnimator = elevatorTwo.GetComponent<Animator>();
        rotated = false;
        lastFloor = 10;
        storyEndEyeClose.SetActive(false);

    }

    void Update()
    {

        CurrentFloor = floorCheck.floorNumberPlayer;
        Debug.Log("elev 2 current floor " + CurrentFloor);
        Debug.Log("elev 2 last " + lastFloor);


        if (SecElevUsed == true && anomalyCall.anomalyLoaded == true && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
        {
            if (CurrentFloor < lastFloor)
            {
                if (floorCheck.elevatorOneRotated == true && CurrentFloor != 1 && CurrentFloor != 10 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir

                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(loadLevel());

                    isClosed = false;
                    SecElevUsed = true;
                    firstElevUsed.FirstElevUsed = false;


                }


                if (CurrentFloor == 1 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir

                    isClosed = false;
                    SecElevUsed = true;
                    firstElevUsed.FirstElevUsed = false;
                    StartCoroutine(StoryEndNextScene());
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
                    SecElevUsed = true;
                    firstElevUsed.FirstElevUsed = false;
                }


                if (CurrentFloor == 1 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir

                    isClosed = false;
                    SecElevUsed = true;
                    firstElevUsed.FirstElevUsed = false;
                    StartCoroutine(StoryEndNextScene());
                }


            }

        }

        else if (SecElevUsed == true && anomalyCall.anomalyLoaded == false && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
        {
            if (CurrentFloor < lastFloor)
            {
                if (floorCheck.elevatorOneRotated == true && lastFloor != 10 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir

                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(goBack()); ////EN BAÞA ATACAK FONKSÝYON BURAYA

                    isClosed = false;
                    SecElevUsed = true;
                    firstElevUsed.FirstElevUsed = false;


                }


                if (CurrentFloor == 1 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir

                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(goBack()); ////EN BAÞA ATACAK FONKSÝYON BURAYA


                    isClosed = false;
                    SecElevUsed = true;
                    firstElevUsed.FirstElevUsed = false;
                }


            }
            if (CurrentFloor == lastFloor)
            {
                if (floorCheck.elevatorTwoRotated == true && lastFloor != 10 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir

                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(goBack()); ////EN BAÞA ATACAK FONKSÝYON BURAYA


                    isClosed = false;
                    SecElevUsed = true;
                    firstElevUsed.FirstElevUsed = false;
                }


                if (CurrentFloor == 1 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(goBack()); ////EN BAÞA ATACAK FONKSÝYON BURAYA


                    isClosed = false;
                    SecElevUsed = true;
                    firstElevUsed.FirstElevUsed = false;
                }


            }
        }

        else if (SecElevUsed == false && anomalyCall.anomalyLoaded == false && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
        {
            if (CurrentFloor < lastFloor)
            {
                if (floorCheck.elevatorOneRotated == true && CurrentFloor != 1 && CurrentFloor != 10 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir

                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(loadLevel());

                    isClosed = false;
                    SecElevUsed = true;
                    firstElevUsed.FirstElevUsed = false;


                }


                if (CurrentFloor == 1 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir

                    isClosed = false;
                    SecElevUsed = true;
                    firstElevUsed.FirstElevUsed = false;

                    StartCoroutine(StoryEndNextScene());
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
                    SecElevUsed = true;
                    firstElevUsed.FirstElevUsed = false;
                }


                if (CurrentFloor == 1 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir

                    isClosed = false;
                    SecElevUsed = true;
                    firstElevUsed.FirstElevUsed = false;
                    StartCoroutine(StoryEndNextScene());
                }

                if (floorCheck.elevatorTwoRotated == false && lastFloor == 10 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {

                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    GameObject HallTrigger = GameObject.Find("MainHallTrigger");
                    GameObject elevator = GameObject.Find("Elevator");

                    GameObject elevatorButtonFake = elevator.transform.Find("elevatorButtonOutFake").gameObject;
                    GameObject elevatorButtonReal = elevator.transform.Find("elevatorButtonOut").gameObject;

                    GameObject elevatorTrigger = GameObject.Find("elevatorTrigger");


                    Destroy(HallTrigger);
                    elevatorButtonFake.SetActive(false);
                    elevatorButtonReal.SetActive(true);
                    elevatorTrigger.SetActive(false);

                    StartCoroutine(loadLevel());

                    isClosed = false;
                    SecElevUsed = true;
                    firstElevUsed.FirstElevUsed = false;
                    floorCheck.startFloor = false;

                    Debug.Log("9.kata inildi");

                }
                if (floorCheck.elevatorTwoRotated == false && CurrentFloor != 1 && lastFloor != 10 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(loadLevel());


                    isClosed = false;
                    SecElevUsed = true;
                    firstElevUsed.FirstElevUsed = false;
                }


            }
        }

        else if (SecElevUsed == false && anomalyCall.anomalyLoaded == true && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
        {
            if (CurrentFloor < lastFloor)
            {
                if (floorCheck.elevatorOneRotated == true && CurrentFloor != 1 && CurrentFloor != 10 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir

                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(goBack());

                    isClosed = false;
                    SecElevUsed = true;
                    firstElevUsed.FirstElevUsed = false;


                }


                if (CurrentFloor == 1 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir

                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(goBack());

                    isClosed = false;
                    SecElevUsed = true;
                    firstElevUsed.FirstElevUsed = false;
                }

            }
            if (CurrentFloor == lastFloor)
            {
                if (floorCheck.elevatorTwoRotated == true && CurrentFloor != 1 && CurrentFloor != 10 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir

                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(loadLevel());

                    isClosed = false;
                    SecElevUsed = true;
                    firstElevUsed.FirstElevUsed = false;


                }

                if (CurrentFloor == 1 && Input.GetKeyDown(KeyCode.E) && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir

                    isClosed = false;
                    SecElevUsed = true;
                    firstElevUsed.FirstElevUsed = false;
                    StartCoroutine(StoryEndNextScene());
                }
            }


        }



        /////MOBÝL////
        ///

        if (SecElevUsed == true && anomalyCall.anomalyLoaded == true && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
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
                    SecElevUsed = true;
                    firstElevUsed.FirstElevUsed = false;


                }


                if (CurrentFloor == 1 && Pressed && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    IsNotPressed();
                    isClosed = false;
                    SecElevUsed = true;
                    firstElevUsed.FirstElevUsed = false;
                    /////////////////////////////
                    StartCoroutine(StoryEndNextScene());
                    /////////////////////////////
                 
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
                    SecElevUsed = true;
                    firstElevUsed.FirstElevUsed = false;
                }


                if (CurrentFloor == 1 && Pressed && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    IsNotPressed();
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    ///HÝKAYE SONU///
                    isClosed = false;
                    SecElevUsed = true;
                    firstElevUsed.FirstElevUsed = false;
                    /////////////////////////////
                    StartCoroutine(StoryEndNextScene());
                    /////////////////////////////
                    
                }


            }

        }

        else if (SecElevUsed == true && anomalyCall.anomalyLoaded == false && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
        {
            if (CurrentFloor < lastFloor)
            {
                if (floorCheck.elevatorTwoRotated == true && lastFloor != 10 && Pressed && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    IsNotPressed();
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(goBack()); ////EN BAÞA ATACAK FONKSÝYON BURAYA


                    isClosed = false;
                    SecElevUsed = true;
                    firstElevUsed.FirstElevUsed = false;
                }


                if (CurrentFloor == 1 && Pressed && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    IsNotPressed();
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(goBack()); ////EN BAÞA ATACAK FONKSÝYON BURAYA


                    isClosed = false;
                    SecElevUsed = true;
                    firstElevUsed.FirstElevUsed = false;
                }


            }
            if (CurrentFloor == lastFloor)
            {
                if (floorCheck.elevatorTwoRotated == true && lastFloor != 10 && Pressed && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    IsNotPressed();
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(goBack()); ////EN BAÞA ATACAK FONKSÝYON BURAYA


                    isClosed = false;
                    SecElevUsed = true;
                    firstElevUsed.FirstElevUsed = false;
                }

                if (CurrentFloor == 1 && Pressed && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    IsNotPressed();
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(goBack()); ////EN BAÞA ATACAK FONKSÝYON BURAYA


                    isClosed = false;
                    SecElevUsed = true;
                    firstElevUsed.FirstElevUsed = false;
                }

            }
        }

        else if (SecElevUsed == false && anomalyCall.anomalyLoaded == false && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
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
                    SecElevUsed = true;
                    firstElevUsed.FirstElevUsed = false;


                }


                if (CurrentFloor == 1 && Pressed && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    // HÝKAYE SONU //
                    IsNotPressed();
                    isClosed = false;
                    SecElevUsed = true;
                    firstElevUsed.FirstElevUsed = false;
                    /////////////////////////////
                    StartCoroutine(StoryEndNextScene());
                    /////////////////////////////
                  
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
                    SecElevUsed = true;
                    firstElevUsed.FirstElevUsed = false;
                }


                if (CurrentFloor == 1 && Pressed && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    IsNotPressed();
                    isClosed = false;
                    SecElevUsed = true;
                    firstElevUsed.FirstElevUsed = false;
                    StartCoroutine(StoryEndNextScene());
                }

                if (floorCheck.elevatorTwoRotated == false && lastFloor == 10 && Pressed && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    IsNotPressed();
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    GameObject HallTrigger = GameObject.Find("MainHallTrigger");
                    GameObject elevator = GameObject.Find("Elevator");

                    GameObject elevatorButtonFake = elevator.transform.Find("elevatorButtonOutFake").gameObject;
                    GameObject elevatorButtonReal = elevator.transform.Find("elevatorButtonOut").gameObject;

                    GameObject elevatorTrigger = GameObject.Find("elevatorTrigger");


                    Destroy(HallTrigger);
                    elevatorButtonFake.SetActive(false);
                    elevatorButtonReal.SetActive(true);
                    elevatorTrigger.SetActive(false);

                    StartCoroutine(loadLevel());

                    isClosed = false;
                    SecElevUsed = true;
                    firstElevUsed.FirstElevUsed = false;
                    floorCheck.startFloor = false;

                    

                }
                if (floorCheck.elevatorTwoRotated == false && CurrentFloor != 1 && lastFloor != 10 && Pressed && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    IsNotPressed();
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(loadLevel());


                    isClosed = false;
                    SecElevUsed = true;
                    firstElevUsed.FirstElevUsed = false;
                }


            }
        }

        else if (SecElevUsed == false && anomalyCall.anomalyLoaded == true && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
        {
            if (CurrentFloor < lastFloor)
            {
                if (floorCheck.elevatorOneRotated == true  && CurrentFloor != 1 && CurrentFloor != 10 && Pressed && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    IsNotPressed();
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(goBack());

                    isClosed = false;
                    SecElevUsed = true;
                    firstElevUsed.FirstElevUsed = false;


                }


                if (CurrentFloor == 1 && Pressed && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    IsNotPressed();
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(goBack());

                    isClosed = false;
                    SecElevUsed = true;
                    firstElevUsed.FirstElevUsed = false;
                }

            }
            if (CurrentFloor == lastFloor)
            {
                if (floorCheck.elevatorTwoRotated == true && CurrentFloor != 1 && CurrentFloor != 10 && Pressed && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    IsNotPressed();
                    anomalyCall.removeAnomaliesFromScene();
                    StartCoroutine(loadLevel());

                    isClosed = false;
                    SecElevUsed = true;
                    firstElevUsed.FirstElevUsed = false;


                }
                if (CurrentFloor == 1 && Pressed && ButtonInsideRange && elevatorBreakTrigger.MalfunctionController == false)
                {
                    // Asansör kapýsý açýk ve mevcut kat 10 ise ve E tuþuna basýldýysa, seviyeyi yükle ve iþaretleri deðiþtir
                    IsNotPressed();
                    isClosed = false;
                    SecElevUsed = true;
                    firstElevUsed.FirstElevUsed = false;
                    StartCoroutine(StoryEndNextScene());
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

        

        if (floorCheck.elevatorTwoRotated == true)
        {
            
            RotatedScene.SetActive(true);
            NotRotatedScene.SetActive(false);
            floorCheck.elevatorTwoRotated = true;
            floorCheck.elevatorOneRotated = false;

            lastFloor = lvlFirst - 1;
            firstElevUsed.lastFloor = lastFloor;
            floorCheck.floorNumberPlayer = lastFloor;
        }
        if (floorCheck.elevatorTwoRotated == false)
        {
            RotatedScene.SetActive(true);
            NotRotatedScene.SetActive(false);
            floorCheck.elevatorTwoRotated = true;
            floorCheck.elevatorOneRotated = false;

            lastFloor = lvlFirst - 1;
            firstElevUsed.lastFloor = lastFloor;
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

            if (floorCheck.elevatorTwoRotated == true)
            {
                
                RotatedScene.SetActive(true);
                NotRotatedScene.SetActive(false);
            }
            if(floorCheck.elevatorTwoRotated==false)
            {
                RotatedScene.SetActive(true);
                NotRotatedScene.SetActive(false);
                floorCheck.elevatorTwoRotated = true;
                floorCheck.elevatorOneRotated = false;
                
            }
            

        }   
        if(CurrentFloor<lastFloor)
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

            if (floorCheck.elevatorOneRotated == true)
            {
                RotatedScene.SetActive(true);
                NotRotatedScene.SetActive(false);
                floorCheck.elevatorOneRotated = false;
                floorCheck.elevatorTwoRotated = true;
                

            }
            

        }
        
        anomalyCall.LoadAnomaly();
        OpenDoor();

    }

    public void workDoor()
    {
        elevatorTwoWorksAudioSource.Play();
    }
    public void OpenDoor()
    {
        IsNotPressed();
        animatorTwo.SetTrigger("controlElevator");
        elevatorTwoOpenAudioSource.Play();
        elevatorTwoButtonSource.Play();

    }

    public void CloseDoor()
    {
        IsNotPressed();
        animatorTwo.SetTrigger("controlElevator");
        elevatorTwoCloseAudioSource.Play();
        elevatorTwoButtonSource.Play();

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
        if (other.CompareTag("Player"))
        {
            ButtonInsideRange = false;
        }


    }


}
