using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove : MonoBehaviour
{
    public GameObject inner_door_left;
    public GameObject inner_door_right;
    public float speed = 0.1f;
    public bool complete_left = false;
    public bool complete_right = false;

    private float elapsedTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        elapsedTime += Time.deltaTime;

        Movement();
    }

    void Movement()
    {
        if (!complete_left)
        {
            if (inner_door_left.transform.position.z < this.gameObject.transform.position.z + 1.1)
            {
                inner_door_left.transform.position += Vector3.forward * speed * Time.deltaTime;
            }
            else
            {
                complete_left = true;
            }
        }
        
        if (!complete_right)
        {
            if (inner_door_right.transform.position.z > this.gameObject.transform.position.z - 1.1)
            {
                inner_door_right.transform.position -= Vector3.forward * speed * Time.deltaTime;
            }
            else
            {
                complete_right = true;
            }
        }
    }
}
