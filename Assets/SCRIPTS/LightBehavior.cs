using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehavior : MonoBehaviour
{

    public GameObject lights;
    public GameObject bulbOne;
    public GameObject bulbTwo;
    public GameObject bulbThree;
    private Light[] allLights;
    public bool isOpened = true;
    
    void Start()
    {
        allLights =lights.GetComponentsInChildren<Light>();     
        
    }

    private void Update()
    {
        if (elevatorBreakTrigger.singleCheck == true) // e�er asans�r ar�za verirse ���klar� zaman aral�g�nda kapat
        {
            StartCoroutine(MyCoroutine());
        }
        
    }

    IEnumerator MyCoroutine()
    {
        
        yield return new WaitForSeconds(0.1f);
        bulbOne.SetActive(false);
        bulbTwo.SetActive(false);
        bulbThree.SetActive(false);
        // T�m ���klar�n durumunu de�i�tir
        foreach (Light light in allLights)
        {
            light.enabled = false;
     
        }


        // isOpened durumuna g�re fog ayarlar�n� de�i�tir
        if (isOpened)
        {

            // I��klar kapal�ysa, fog'u daha karanl�k yap
            RenderSettings.fogColor = Color.black; // Fog rengini de�i�tir
            RenderSettings.fogDensity = 0.1f;      // Fog yo�unlu�unu de�i�tir
            
        }
           

        isOpened=false;




    }
}
