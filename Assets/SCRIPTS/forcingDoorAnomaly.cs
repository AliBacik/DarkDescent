using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forcingDoorAnomaly : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource doorForceAnomaly;



    public void DoorPlay()
    {
        doorForceAnomaly.Play();
    }
    public void DoorStop()
    {
 
        doorForceAnomaly.Stop();
    }
}