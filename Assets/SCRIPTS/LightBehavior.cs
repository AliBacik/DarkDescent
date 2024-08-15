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
        if (elevatorBreakTrigger.singleCheck == true) // eðer asansör arýza verirse ýþýklarý zaman aralýgýnda kapat
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
        // Tüm ýþýklarýn durumunu deðiþtir
        foreach (Light light in allLights)
        {
            light.enabled = false;
     
        }


        // isOpened durumuna göre fog ayarlarýný deðiþtir
        if (isOpened)
        {

            // Iþýklar kapalýysa, fog'u daha karanlýk yap
            RenderSettings.fogColor = Color.black; // Fog rengini deðiþtir
            RenderSettings.fogDensity = 0.1f;      // Fog yoðunluðunu deðiþtir
            
        }
           

        isOpened=false;




    }
}
