using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phoneRing : MonoBehaviour
{

    [Header("Audio")]
    [SerializeField] private AudioSource phoneRingSource = null;
    // Start is called before the first frame update

    public GameObject talk;
    
    void Start()
    {
        talk.SetActive(false);
        StartCoroutine(ringPlay());
        StartCoroutine(canvasAppear());
        
    }

    IEnumerator ringPlay()
    {
        yield return new WaitForSeconds(4f); // Wait for 3 second
        phoneRingSource.Play(); // Deactivate the pickup alert
    }

    IEnumerator canvasAppear()
    {
        yield return new WaitForSeconds(5f); // Wait for 3 second
        talk.SetActive(true); // Deactivate the pickup alert
    }

}
