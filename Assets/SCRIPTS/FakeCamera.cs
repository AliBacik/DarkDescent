using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeCamera : MonoBehaviour
{

    public GameObject fakeCamera;
    public GameObject realCam;
    public GameObject controller;

    // Start is called before the first frame update
    void Start()
    {
        fakeCamera.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(camDis());
    }

    IEnumerator camDis()
    {
        yield return new WaitForSeconds(11.0f);
        fakeCamera.SetActive(false);
        realCam.SetActive(true);
        gameObject.SetActive(false);
        //MOBÝLE//
        //controller.SetActive(true);
    }
}
