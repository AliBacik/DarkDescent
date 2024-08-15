using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceSFX : MonoBehaviour
{

    public GameObject rainLoopAmbience;
    public GameObject WindyAmbience;
    // Start is called before the first frame update
    void Start()
    {
        rainLoopAmbience.SetActive(true);
        WindyAmbience.SetActive(true);
    }

  
}
