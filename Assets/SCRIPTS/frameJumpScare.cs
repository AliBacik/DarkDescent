using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frameJumpScare : MonoBehaviour
{

    public float playerRotationSpeed = 100f; // Oyuncunun dönme hýzý
    public GameObject jumpscare; // Jumpscare objesi

    private bool jumpscareTriggered = false;

    void Update()
    {
        if (jumpscareTriggered)
        {
            StartCoroutine(RotatePlayerTowardsJumpscare());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            jumpscareTriggered = true;
        }
    }

    IEnumerator RotatePlayerTowardsJumpscare()
    {
       
        // Oyuncuyu jumpscare'e doðru döndür
        Vector3 directionToJumpscare = jumpscare.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(directionToJumpscare);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, playerRotationSpeed * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        jumpscare.SetActive(false);
    }
    
}
