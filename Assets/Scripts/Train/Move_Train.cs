using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Train : MonoBehaviour
{
    public float speed = 0.1f;
    public float force = 0.1f;
    public bool control = false;

    public GameObject claw;

    private float minimum = 0.5f;
    private float minimumPos = -0.2f;
    private float current_scale = 0.5f;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float forward = Input.GetAxis("TrainForward");
        float side = Input.GetAxis("TrainSideways");
        float vertical = Input.GetAxis("TrainVertical");
        float roll = Input.GetAxis("TrainRoll");
        float pitch = Input.GetAxis("TrainPitch");

        float clawVertical = Input.GetAxis("ClawVertical");

        if (control)
        {
            MovementManager(forward, side, vertical, roll, pitch);

            ClawControl(clawVertical);
        }
        

        Debug.Log(clawVertical);
    }

    void MovementManager(float forward, float side, float vertical, float roll, float pitch)
    {
        Rigidbody ourBody = this.GetComponent<Rigidbody>();

        if (forward > 0)
        {
            float movement = Mathf.Lerp(0, -0.25f, 1);

            Vector3 moveForward = new Vector3(movement, 0f, 0f);

            moveForward = ourBody.transform.TransformDirection(moveForward);
            ourBody.transform.position += moveForward;
        }

        if (forward < 0)
        {
            float movement = Mathf.Lerp(0, 0.25f, 1);

            Vector3 moveBack = new Vector3(movement, 0f, 0f);

            moveBack = ourBody.transform.TransformDirection(moveBack);
            ourBody.transform.position += moveBack;
        }

        if (vertical > 0)
        {
            ourBody.AddForce(Vector3.up * force, ForceMode.Force);
            ourBody.useGravity = false;
        }
        else if (vertical < 0)
        {
            ourBody.AddForce(Vector3.up * -force, ForceMode.Force);
            ourBody.useGravity = true;
        }
        else
        {
            ourBody.velocity = Vector3.zero;
        }

        if (roll != 0)
        {
            Quaternion deltaRotation = Quaternion.Euler(roll * 1f, 0f, 0f);

            ourBody.MoveRotation(ourBody.rotation * deltaRotation);
        }

        if (pitch != 0)
        {
            Debug.Log(pitch);
            Quaternion deltaRotation = Quaternion.Euler(0f, 0f, pitch * 1f);

            ourBody.MoveRotation(ourBody.rotation * deltaRotation);
        }

        if (side != 0)
        {
            Quaternion deltaRotation = Quaternion.Euler(0f, side * 1f, 0f);

            ourBody.MoveRotation(ourBody.rotation * deltaRotation);
        }
    }

    void ClawControl(float vertical)
    {
        if (vertical > 0)
        {
            current_scale += 0.05f;
            claw.transform.localScale = new Vector3(0.1f, current_scale, 0.1f);
            claw.transform.localPosition = new Vector3(1.85f, -(current_scale / 2), 0);
        }

        if (vertical < 0)
        {
            if (claw.transform.localScale.y > minimum)
            {
                current_scale -= 0.05f;

                if (current_scale < minimum)
                {
                    current_scale = minimum;
                    claw.transform.position = new Vector3(1.85f, minimumPos, 0);
                }
                claw.transform.localScale = new Vector3(0.1f, current_scale, 0.1f);
                claw.transform.localPosition = new Vector3(1.85f, -(current_scale / 2), 0);
            }
        }
    }
}
