using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainHallTrigger : MonoBehaviour
{

    public GameObject HallCanvas;
    public GameObject HallInfoCanvas;
    public GameObject mobController;
    public FpsControl fpsControl;
   

    public static bool playerInHallRange;
    public bool singleCheck = false;
    public bool Pressed;
    // Start is called before the first frame update
    void Start()
    {
        
        HallCanvas.SetActive(false);
        HallInfoCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInHallRange == true&&singleCheck==false)
        {
            AudioSource source = fpsControl.GetComponent<AudioSource>();
            
            source.enabled = false;
            fpsControl.speed = 0f;
            StartCoroutine(appearCanvas());

            Cursor.lockState = CursorLockMode.Confined;

            //mobController.SetActive(false);
            HallInfoCanvas.SetActive(true);
            
        }
    }

    IEnumerator appearCanvas()
    {
        HallCanvas.SetActive (true);
        yield return new WaitForSeconds(3.5f);
        HallCanvas.SetActive(false);
        gameObject.SetActive(false);
        
    }

    public void IsPressed()
    {
        AudioSource source = fpsControl.GetComponent<AudioSource>();
        source.enabled = true;
        //mobController.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        fpsControl.speed = 5f;
        HallInfoCanvas.SetActive(false);
        

    }

  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInHallRange = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInHallRange = false;
            singleCheck = true;
        }
    }
}
