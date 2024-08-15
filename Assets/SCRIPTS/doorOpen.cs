using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpen : MonoBehaviour
{
    public bool playerInRange;
    public GameObject door;
    public Animator animator;
    public bool isOpened = false;

    [Header("Audio")]
    [SerializeField] private AudioSource doorOpenAudioSource = null;
    [SerializeField] private float openDelay = 0;
    [Space(10)]
    [SerializeField] private AudioSource doorCloseAudioSource = null;
    [SerializeField] private float closeDelay = 0;
    public bool Pressed;
   

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

   
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && playerInRange && CompareTag("door") && PlayerInteractions.objectPickedUp == true)
        {
            if (isOpened == false)
            {
                OpenDoor();
            }
            else
            {
                CloseDoor();
            }
        }

        if (Pressed && playerInRange && CompareTag("door") && PlayerInteractions.objectPickedUp == true)
        {
           
                if (isOpened == false)
                {
                    OpenDoor();
                    
                }
                else
                {
                    CloseDoor();
                   
                }

            
           
        }
    }

   

    public void OpenDoor()
    {
        IsNotPressed();
        animator.SetTrigger("Open");
        doorOpenAudioSource.PlayDelayed(openDelay);
        isOpened = true;
    }

    public void CloseDoor()
    {
        IsNotPressed();
        animator.SetTrigger("Open");
        doorCloseAudioSource.PlayDelayed(closeDelay);
        isOpened = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
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
