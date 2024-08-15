using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crawlerTrigger : MonoBehaviour
{
    public GameObject Crawler;
    public AudioSource scream;
    public FloorChecker checkRotate;
    void Start()
    {
        Crawler.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Crawler.SetActive(true);
            scream.Play();
            StartCoroutine(DestroyObject());

        }


        if (checkRotate.elevatorOneRotated == true && checkRotate.elevatorTwoRotated == false)
        {
            Crawler.SetActive(true);
            Crawler.transform.rotation = Quaternion.Euler(0, 180f, 0f);
        }

        if (checkRotate.elevatorOneRotated == false && checkRotate.elevatorTwoRotated == true)
        {
            Crawler.SetActive(true) ;

            
        }
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(1.5f);
        Crawler.SetActive(false);
        gameObject.SetActive(false);
    }
}
