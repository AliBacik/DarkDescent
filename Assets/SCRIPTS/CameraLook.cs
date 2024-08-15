using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    //public FixedJoystick joystick;
    public FloatingJoystick FloatStick;

    [Range(0.1f, 500)]
    public float sens=0.5f;
    public Transform body;

    float xRot = 0f;
    float xRot_input = 0f;

    private void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        float rotX_input = Input.GetAxisRaw("Mouse X") * sens ;
        float rotY_input = Input.GetAxisRaw("Mouse Y") * sens ;
        xRot_input -= rotY_input;
        xRot_input = Mathf.Clamp(xRot_input, -80f, 80);
        transform.localRotation = Quaternion.Euler(xRot_input, 0f, 0f);
        body.Rotate(Vector3.up * rotX_input);
        ///Mobil///
        //float rotX = FloatStick.Horizontal * sens * Time.deltaTime;
        //float rotY = FloatStick.Vertical * sens * Time.deltaTime;
        //xRot -= rotY;
        //xRot = Mathf.Clamp(xRot, -80f, 80);
        //transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        //body.Rotate(Vector3.up * rotX);

    }

}
