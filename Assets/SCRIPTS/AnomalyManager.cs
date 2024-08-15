using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnomalyManager : MonoBehaviour
{
    public List<int> availableAnomalies = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,11,12,13 };
    public List<int> previousAnomalies = new List<int>();
    public bool anomalyLoaded;
    public bool isDoorForceAnomalyActive;

    public GameObject realSceneCandleOne;
    public GameObject realSceneCandleTwo;

    public GameObject fakeSceneCandleOne;
    public GameObject fakeSceneCandleTwo;

    public GameObject KillyouFrame;

    //public GameObject crawler;
    public GameObject crawTrigger;

    public GameObject receptionChairSceneOne;
    public GameObject receptionChairSceneTwo;

    public GameObject TvRealScene;
    public GameObject TvRotatedScene;
    public GameObject TvRealSceneStatic;
    public GameObject TvRotatedSceneStatic;

    public GameObject BellRealScene;
    public GameObject BellRotatedScene;
    public GameObject BellRealSceneAno;
    public GameObject BellRotatedSceneAno;

    public GameObject pumpkinAno;
    public GameObject pumpkinAnoTwo;

    public forcingDoorAnomaly ReelDoor;
    public forcingDoorAnomaly FakeDoor;

    public GameObject sceneOne;
    public GameObject sceneTwo;

    public GameObject anomalyPrefabOne;
    public GameObject anomalyPrefabTwo;
    public GameObject anomalyPrefabThree;

    private int previousFloor = 10;
    public int pickedAnomaly;
    public FloorChecker checkFloor;
    public int floorNumb;
    



    void Start()
    {
        floorNumb = 10;
        anomalyLoaded = false;
        isDoorForceAnomalyActive = false;

    }

    void Update()
    {


        floorNumb = checkFloor.floorNumberPlayer;
        
        // Mevcut kat numaras�n� kontrol ediyoruz.
        if (floorNumb != previousFloor)
        {

            previousFloor = checkFloor.floorNumberPlayer; // �nceki kat numaras�n� g�ncelliyoruz.
        }

    }
    public void ResetAnomalies()
    {
        // Kullan�lan anomaliyi kullan�labilir anomaliler listesine geri ekle
        if (previousAnomalies.Count > 0)
        {
            int lastAnomaly = previousAnomalies[previousAnomalies.Count - 1];
            availableAnomalies.Add(lastAnomaly);
        }

        // Kullan�labilir anomaliler listesini ba�lang�� durumuna geri d�nd�r
        availableAnomalies.Clear();
        availableAnomalies.AddRange(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,11,12,13 });

        // �nceki anomalileri temizle
        previousAnomalies.Clear();

        // Anomali y�klendi�i i�aretini s�f�rla
        anomalyLoaded = false;
    }

    public void LoadAnomaly()
    {
        if (checkFloor.startFloor==false && availableAnomalies.Count > 0)
        {
            // Rastgele bir anomali se�
            int randomIndex = UnityEngine.Random.Range(0, availableAnomalies.Count);
            int selectedAnomaly = availableAnomalies[randomIndex];

            // Se�ilen anomaliyi kaydet
            previousAnomalies.Add(selectedAnomaly);


            // Anomali i�lemini yap (burada i�lem yerine ne yap�laca��n� ekleyin)
            

            // Anomali i�lemini yap
            AnomaliIslemi(selectedAnomaly);

            // Se�ilen anomaliyi kullan�labilir anomaliler listesinden kald�r
            availableAnomalies.Remove(selectedAnomaly);

            pickedAnomaly = selectedAnomaly;


        }
    }

    public void removeAnomaliesFromScene()
    {
        deactiveGnome();
        deactivateScaryFrame();
        DoorForceAnomalyStop();
        pumpkinAnomalyDeactivate();
        deactivateCrawTrigger();
        CandleAnomaliesDeactivate();
        killYouFrameDeactivate();
        DisableAnomalyTvStatic();
        disableBellAnomaly();
        disableChairAnomaly();
        anomalyLoaded = false;
    }

    void AnomaliIslemi(int secilenSayi)
    {
        if (secilenSayi == 1)
        {
            
            // Anomali y�klendi�ini i�aretle
            anomalyLoaded = true;
            activeGnome();
            // Buraya 1 i�in yap�lacak i�lemler eklenebilir
        }
        else if (secilenSayi == 2)
        {
            
            // Anomali y�klendi�ini i�aretle
            anomalyLoaded = false;
            // Buraya 3 i�in yap�lacak i�lemler eklenebilir
        }
        else if (secilenSayi == 3)
        {
            
            // Anomali y�klendi�ini i�aretle
            anomalyLoaded = true;
            ScaryFrame();
            // Buraya 3 i�in yap�lacak i�lemler eklenebilir
        }
        else if (secilenSayi == 4)
        {
            
            // Anomali y�klendi�ini i�aretle
            anomalyLoaded = true;
            isDoorForceAnomalyActive = true;
            StartCoroutine(DoorForceAnomaly());
            // Buraya 4 i�in yap�lacak i�lemler eklenebilir
        }
        else if (secilenSayi == 5)
        {
           
            // Anomali y�klendi�ini i�aretle
            anomalyLoaded = false;
            // Buraya 4 i�in yap�lacak i�lemler eklenebilir
        }
        else if (secilenSayi == 6)
        {
           
            // Anomali y�klendi�ini i�aretle
            anomalyLoaded = true;
            PumpkinAnomaly();
            // Buraya 6 i�in yap�lacak i�lemler eklenebilir
        }
        else if (secilenSayi == 7)
        {
           
            // Anomali y�klendi�ini i�aretle
            anomalyLoaded = true;
            activateCrawTrigger();
            // Buraya 7 i�in yap�lacak i�lemler eklenebilir
        }
        else if (secilenSayi == 8)
        {
           
            // Anomali y�klendi�ini i�aretle
            anomalyLoaded = false;
            // Buraya 4 i�in yap�lacak i�lemler eklenebilir
        }
        else if (secilenSayi == 9)
        {
           
            // Anomali y�klendi�ini i�aretle
            anomalyLoaded = true;
            CandleAnomaliesActivate();
            // Buraya 9 i�in yap�lacak i�lemler eklenebilir
        }
        else if (secilenSayi == 10)
        {
           
            // Anomali y�klendi�ini i�aretle
            anomalyLoaded = true;
            killYouFrameActivate();
            // Buraya 10 i�in yap�lacak i�lemler eklenebilir
        }

        else if (secilenSayi == 11)
        {

            // Anomali y�klendi�ini i�aretle
            anomalyLoaded = true;
            anomalyTvStatic();
            // Buraya 11 i�in yap�lacak i�lemler eklenebilir
        }
        else if (secilenSayi == 12)
        {

            // Anomali y�klendi�ini i�aretle
            anomalyLoaded = true;
            bellAnomaly();
            // Buraya 12 i�in yap�lacak i�lemler eklenebilir
        }
        else if (secilenSayi == 13)
        {

            // Anomali y�klendi�ini i�aretle
            anomalyLoaded = true;
            chairAnomaly();
            // Buraya 13 i�in yap�lacak i�lemler eklenebilir
        }
        else
        {
            Debug.LogError("Tan�ms�z anomali: " + secilenSayi);
        }
    }


    void killYouFrameActivate()
    {
        if (checkFloor.elevatorOneRotated == true && checkFloor.elevatorTwoRotated == false)
        {
            KillyouFrame.SetActive(true);
        }

        if (checkFloor.elevatorOneRotated == false && checkFloor.elevatorTwoRotated == true)
        {
            KillyouFrame.SetActive(true);
            KillyouFrame.transform.position = new Vector3(10.377f, 5.028453f, 5.249f);
            KillyouFrame.transform.rotation = Quaternion.Euler(0, -90f, 0f);


        }
    }

    void killYouFrameDeactivate()
    {
        KillyouFrame.SetActive (false);
    }
    void CandleAnomaliesActivate()
    {
        if (checkFloor.elevatorOneRotated == true && checkFloor.elevatorTwoRotated == false)
        {
            realSceneCandleOne.SetActive(true);
            realSceneCandleTwo.SetActive(false);
            
        }

        if (checkFloor.elevatorOneRotated == false && checkFloor.elevatorTwoRotated == true)
        {
            fakeSceneCandleOne.SetActive(false);
            fakeSceneCandleTwo.SetActive(true);
            


        }
    }

    void CandleAnomaliesDeactivate()
    {
        if (checkFloor.elevatorOneRotated == true && checkFloor.elevatorTwoRotated == false)
        {

            realSceneCandleOne.SetActive(true);
            realSceneCandleTwo.SetActive(true);

        }

        if (checkFloor.elevatorOneRotated == false && checkFloor.elevatorTwoRotated == true)
        {

            fakeSceneCandleOne.SetActive(true);
            fakeSceneCandleTwo.SetActive(true);


        }
    }

    void chairAnomaly()
    {
        if (checkFloor.elevatorOneRotated == true && checkFloor.elevatorTwoRotated == false)
        {
            receptionChairSceneOne.SetActive(false);
            
        }
        if (checkFloor.elevatorOneRotated == false && checkFloor.elevatorTwoRotated == true)
        {
            receptionChairSceneTwo.SetActive(false);
        }
    }

    void disableChairAnomaly()
    {
        receptionChairSceneOne.SetActive(true);
        receptionChairSceneTwo.SetActive(true);
    }
    void bellAnomaly()
    {
        if (checkFloor.elevatorOneRotated == true && checkFloor.elevatorTwoRotated == false)
        {
            BellRealScene.SetActive(false);
            BellRealSceneAno.SetActive(true);
        }
        if (checkFloor.elevatorOneRotated == false && checkFloor.elevatorTwoRotated == true)
        {
            BellRotatedScene.SetActive(false);         
            BellRotatedSceneAno.SetActive(true);
        }
    }

    void disableBellAnomaly()
    {
        BellRealScene.SetActive(true);
        BellRealSceneAno.SetActive(false);
        BellRotatedScene.SetActive(true);
        BellRotatedSceneAno.SetActive(false);
    }
    void anomalyTvStatic()
    {
        if (checkFloor.elevatorOneRotated == true && checkFloor.elevatorTwoRotated == false)
        {
            TvRealScene.SetActive(false);           
            TvRealSceneStatic.SetActive(true); 
            
        }

        if (checkFloor.elevatorOneRotated == false && checkFloor.elevatorTwoRotated == true)
        {
            TvRotatedScene.SetActive(false); 
            TvRotatedSceneStatic.SetActive(true);
        }
    }


    void DisableAnomalyTvStatic()
    {
        
            TvRealScene.SetActive(true);
            TvRealSceneStatic.SetActive(false);       
            TvRotatedScene.SetActive(true); 
            TvRotatedSceneStatic.SetActive(false);
        
    }

    void activateCrawTrigger()
    {
       

        if (checkFloor.elevatorOneRotated == true && checkFloor.elevatorTwoRotated == false)
        {
            crawTrigger.SetActive(true);
        }

        if (checkFloor.elevatorOneRotated == false && checkFloor.elevatorTwoRotated == true)
        {
            crawTrigger.SetActive(true) ;
                       
           
        }
    }

    void deactivateCrawTrigger()
    {
        crawTrigger.SetActive(false);
    }
    void pumpkinAnomalyDeactivate()
    {
        pumpkinAno.SetActive(false);
        pumpkinAnoTwo.SetActive(false);
    }
    void PumpkinAnomaly()
    {
        
        if (checkFloor.elevatorOneRotated == true && checkFloor.elevatorTwoRotated == false)
        {
            pumpkinAno.SetActive(true);
            pumpkinAnoTwo.SetActive(false);
        }

        if (checkFloor.elevatorOneRotated == false && checkFloor.elevatorTwoRotated == true)
        {
            pumpkinAnoTwo.SetActive(true);
            pumpkinAno.SetActive(false);

        }
    }


    void ScaryFrame()
    {
        Transform FrameOne = sceneOne.transform.Find("FrameToReplace");
        Transform FrameTwo = sceneTwo.transform.Find("FrameToReplace");


        if (checkFloor.elevatorOneRotated == true && checkFloor.elevatorTwoRotated == false)
        {
            anomalyPrefabTwo.SetActive(true);
            FrameOne.gameObject.SetActive(false);


        }

        if (checkFloor.elevatorOneRotated == false && checkFloor.elevatorTwoRotated == true)
        {
            anomalyPrefabThree.SetActive(true);
            FrameTwo.gameObject.SetActive(false);
            
        }

    }

    void deactivateScaryFrame()
    {
        Transform FrameOne = sceneOne.transform.Find("FrameToReplace");
        Transform FrameTwo = sceneTwo.transform.Find("FrameToReplace");
        anomalyPrefabTwo.SetActive(false);
        anomalyPrefabThree.SetActive(false);
        FrameOne.gameObject.SetActive(true);
        FrameTwo.gameObject.SetActive(true);
    }
    void activeGnome()
    {
        Transform gnomeOne = sceneOne.transform.Find("garden_gnome");
        Transform gnomeTwo = sceneTwo.transform.Find("garden_gnome");

        if (checkFloor.elevatorOneRotated == true && checkFloor.elevatorTwoRotated == false)
        {
            anomalyPrefabOne.SetActive(true);
            gnomeOne.gameObject.SetActive(false);
        }

        if (checkFloor.elevatorOneRotated == false && checkFloor.elevatorTwoRotated == true)
        {
            anomalyPrefabOne.SetActive(true);
            anomalyPrefabOne.transform.position = new Vector3(-5.03f, 1.51f, 10.51f);
            anomalyPrefabOne.transform.rotation = Quaternion.Euler(-90, 80.4f, 0f);
            gnomeTwo.gameObject.SetActive(false);
        }

    }

    void deactiveGnome()
    {
        Transform gnomeOne = sceneOne.transform.Find("garden_gnome");
        Transform gnomeTwo = sceneTwo.transform.Find("garden_gnome");
        anomalyPrefabOne.SetActive(false);
        gnomeOne.gameObject.SetActive(true);
        gnomeTwo.gameObject.SetActive(true);
    }

    public IEnumerator DoorForceAnomaly()
    {
        

        if (checkFloor.elevatorOneRotated == true && checkFloor.elevatorTwoRotated == false)
        {
            while (isDoorForceAnomalyActive==true)
            {
                ReelDoor.DoorPlay();
                yield return new WaitForSeconds(1.5f);
                ReelDoor.DoorStop();
            }
            

        }

        if (checkFloor.elevatorOneRotated == false && checkFloor.elevatorTwoRotated == true)
        {
            while (isDoorForceAnomalyActive == true)
            {
                FakeDoor.DoorPlay();
                yield return new WaitForSeconds(1.5f);
                FakeDoor.DoorStop();
            }

        }

    }

    public void DoorForceAnomalyStop()
    {
       
        if (checkFloor.elevatorOneRotated == true && checkFloor.elevatorTwoRotated == false)
        {


            isDoorForceAnomalyActive = false;




        }

        if (checkFloor.elevatorOneRotated == false && checkFloor.elevatorTwoRotated == true)
        {


            isDoorForceAnomalyActive = false;


        }

    }
}