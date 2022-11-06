using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wing_movement : MonoBehaviour
{
    private GameObject left_wing_one;
    private GameObject left_wing_two;
    private GameObject right_wing_one;
    private GameObject right_wing_two;
    public float speed = 0.1f;

    public bool complete_left_one = false;
    public bool complete_left_two = false;
    public bool complete_right_one = false;
    public bool complete_right_two = false;

    // Start is called before the first frame update
    void Start()
    {
        left_wing_one = this.gameObject.transform.GetChild(0).gameObject;
        left_wing_two = this.gameObject.transform.GetChild(1).gameObject;
        right_wing_one = this.gameObject.transform.GetChild(2).gameObject;
        right_wing_two = this.gameObject.transform.GetChild(3).gameObject;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        if (!complete_left_one)
        {
            if (left_wing_one.transform.position.z < this.gameObject.transform.position.z + 2.45)
            {
                left_wing_one.transform.position += Vector3.forward * speed * Time.deltaTime;
            }
            else
            {
                complete_left_one = true;
            }
        }
        if (!complete_left_two)
        {
            if (left_wing_two.transform.position.z < this.gameObject.transform.position.z + 4.4)
            {
                left_wing_two.transform.position += Vector3.forward * speed * Time.deltaTime;
            }
            else
            {
                complete_left_two = true;
            }
        }
        if (!complete_right_one)
        {
            if (right_wing_one.transform.position.z > this.gameObject.transform.position.z - 2.45)
            {
                right_wing_one.transform.position -= Vector3.forward * speed * Time.deltaTime;
            }
            else
            {
                complete_right_one = true;
            }
        }
        if (!complete_right_two)
        {
            if (right_wing_two.transform.position.z > this.gameObject.transform.position.z - 4.4)
            {
                right_wing_two.transform.position -= Vector3.forward * speed * Time.deltaTime;
            }
            else
            {
                complete_right_two = true;
            }
        }
    }
}
