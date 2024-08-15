using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class elevatorButtonOut : MonoBehaviour
{

    [Header("Audio")]
    [SerializeField] private AudioSource elevatorOpenAudioSource = null;

    [Space(10)]
    [SerializeField] private AudioSource elevatorCloseAudioSource = null;

    [Space(10)]
    [SerializeField] private AudioSource elevatorButtonSource = null;


    
    public bool isOpenedDoor; // kapý kapalý baþlar
    public bool playerInRangeOfOutButton;
    public GameObject elevator;
    public Animator animator;
    public bool Pressed;




    // Start is called before the first frame update
    void Start()
    {    
        Pressed = false;
        isOpenedDoor = false;
        elevator = GameObject.Find("Elevator");
        Animator otherAnimator = elevator.GetComponent<Animator>();
        playerInRangeOfOutButton = false;
    }

    void Update()
    {

        
        //Debug.Log("isOpenedDoor" + isOpenedDoor);
        //if (Input.GetKeyDown(KeyCode.E) && playerInRangeOfOutButton)
        //{
        //    if (isOpenedDoor == false)

        //    {
        //        OpenDoor();
        //        isOpenedDoor = true; // kapý açýldý

                
        //    }
        //else if (Input.GetKeyDown(KeyCode.E) && playerInRangeOfOutButton)
        //    {
        //        if (isOpenedDoor == true)

        //        {
        //            CloseDoor();
        //            isOpenedDoor = false; // kapý kapandý

                    
        //        }
        //    }


        //}

        //////////////////////////////////MOBÝL////////////////////////////
        ///

        if(playerInRangeOfOutButton)
        {
            if(Pressed)
            {
                if (isOpenedDoor == false)

                {
                    OpenDoor();
                    isOpenedDoor = true; // kapý açýldý


                }
                else if (Pressed && playerInRangeOfOutButton)
                {
                    if (isOpenedDoor == true)

                    {
                        CloseDoor();
                        isOpenedDoor = false; // kapý kapandý


                    }
                }
            }
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


    void OpenDoor()
    {
        IsNotPressed();
        animator.SetTrigger("controlElevator");
        elevatorOpenAudioSource.Play();
        elevatorButtonSource.Play();
        
    }

    void CloseDoor()
    {

        IsNotPressed();
        animator.SetTrigger("controlElevator");
        elevatorCloseAudioSource.Play();
        elevatorButtonSource.Play();
        

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRangeOfOutButton = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRangeOfOutButton = false;
        }
    }
}
