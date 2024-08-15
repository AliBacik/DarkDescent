using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class elevatorBreakTrigger : MonoBehaviour
{

    [SerializeField] private AudioSource malfunction = null;
    [SerializeField] private AudioSource electricity = null;

    public GameObject mainHallPlane;
    public GameObject breakTrigger;
    public doorOpen InteractableDoor;
    public bool PlayerInRangeTrigger;
    public static bool MalfunctionController;
    public static bool singleCheck;
    public GameObject warning;
    public bool Pressed;
    // Start is called before the first frame update
    void Start()
    {
        singleCheck = false;
        PlayerInRangeTrigger = false; 
        warning.SetActive(false);
        MalfunctionController=false;
        Pressed = false;
}

    // Update is called once per frame
    void Update()
    {
        if (PlayerInRangeTrigger == true && singleCheck == false && Input.GetKeyDown(KeyCode.E))
        {
            malfunction.Play();
            electricity.Play();

            if (InteractableDoor.isOpened == false)
            {
                InteractableDoor.Pressed = false;
                InteractableDoor.enabled = false;
            }
            else
            {
                InteractableDoor.CloseDoor();
                InteractableDoor.Pressed = false;
                InteractableDoor.enabled = false;
            }


            mainHallPlane.SetActive(false);
            StartCoroutine(warningCanvas());
            singleCheck = true;
            //Collider col = GetComponent<Collider>();
            //col.enabled = false;
        }

        //////////////////Mobil//////////////////////

        if (PlayerInRangeTrigger == true && singleCheck == false && Pressed)
        {
            malfunction.Play();
            electricity.Play();

            if (InteractableDoor.isOpened == false)
            {              
                InteractableDoor.Pressed = false;
                InteractableDoor.enabled = false;
            }
            else
            {
                InteractableDoor.CloseDoor();
                InteractableDoor.Pressed = false;
                InteractableDoor.enabled = false;
            }        
            
            mainHallPlane.SetActive(false);
            StartCoroutine(warningCanvas());
            singleCheck = true;
           // Collider col = GetComponent<Collider>();
            //col.enabled = false;
        }
    }

    IEnumerator warningCanvas()
    {
        warning.SetActive(true);
        yield return new WaitForSeconds(6f);
        warning.SetActive(false) ;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BreakTrigger"))
        {       
            
             PlayerInRangeTrigger = true;
             MalfunctionController= true;
             

        }
        
    
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BreakTrigger"))
        {
            
            PlayerInRangeTrigger = false;
            MalfunctionController = false;



        }
        
    }


    public void IsPressed()
    {
        Pressed = true;

    }

    public void IsNotPressed()
    {
        Pressed = false;
    }


}
