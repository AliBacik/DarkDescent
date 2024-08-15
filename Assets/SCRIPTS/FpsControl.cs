using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsControl : MonoBehaviour
{
    CharacterController controller;
    AudioSource source;

    public AudioClip[] footStepsSounds;

    Vector3 velocity;
    bool isGrounded;


    public Transform ground;
    public float distance = 0.3f;
    public float speed;
    public float jumpHeight;
    public float gravity;
    public LayerMask mask;
    public float timeBetweenSteps;
    float timer;
    public bool isMoving;
    public bool isMovingInput;
    public FixedJoystick FixJoystick;
    
    
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        float horizontal_input = Input.GetAxis("Horizontal");
        float vertical_input = Input.GetAxis("Vertical");

        Vector3 move_input = transform.right * horizontal_input + transform.forward * vertical_input;

        controller.Move(move_input * speed * Time.deltaTime);

        if (horizontal_input != 0 || vertical_input != 0)
        {
            isMovingInput = true;
        }
        else
        {
            isMovingInput = false;
        }

        if (isMovingInput)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                timer = timeBetweenSteps;

                source.clip = footStepsSounds[Random.Range(0, footStepsSounds.Length)];
                source.pitch = Random.Range(0.90f, 1.15f);
                source.Play();
            }
        }
        else
        {
            timer = timeBetweenSteps;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 7.5f;
            timeBetweenSteps = 0.4f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 5.0f;
            timeBetweenSteps = 0.65f;
        }


        //Mobil//

        //float horizontal = FixJoystick.Horizontal;
        //float vertical = FixJoystick.Vertical;

        //Vector3 move = transform.right * horizontal + transform.forward * vertical;

        //controller.Move(move * speed * Time.deltaTime);

        //if (horizontal != 0 || vertical != 0)
        //{
        //    isMoving = true;
        //}
        //else
        //{
        //    isMoving = false;
        //}

        //if (isMoving)
        //{
        //    timer -= Time.deltaTime;

        //    if (timer <= 0)
        //    {
        //        timer = timeBetweenSteps;

        //        source.clip = footStepsSounds[Random.Range(0, footStepsSounds.Length)];
        //        source.pitch = Random.Range(0.90f, 1.15f);
        //        source.Play();
        //    }
        //}
        //else
        //{
        //    timer = timeBetweenSteps;
        //}

        //if (Input.GetKeyDown(KeyCode.LeftShift))
        //{
        //    speed = 7.5f;
        //    timeBetweenSteps = 0.4f;
        //}
        //if (Input.GetKeyUp(KeyCode.LeftShift))
        //{
        //    speed = 5.0f;
        //    timeBetweenSteps = 0.65f;
        //}




    }

    public void RunState()
    {
        speed = 7.5f;
        timeBetweenSteps = 0.4f;
    }
    public void walkState()
    {
        speed = 5.0f;
        timeBetweenSteps = 0.65f;
    }
}
