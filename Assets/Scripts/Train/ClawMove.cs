using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawMove : MonoBehaviour
{
    public GameObject partOne;
    public GameObject partTwo;
    public GameObject partThree;
    public GameObject partFour;

    public Move_Train tranScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dropRock = Input.GetAxis("DropRock");

        if (dropRock > 0)
        {
            foreach (Transform child in this.transform)
            {
                if (child.tag == "Boulder")
                {
                    child.gameObject.transform.parent = null;
                    child.GetComponent<Rigidbody>().useGravity = true;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        float clawOpen = Input.GetAxis("ClawOpen");

        

        if (tranScript.control)
        {
            MoveClaw(clawOpen);
        }
    }

    void MoveClaw(float clawOpen)
    {
        if (clawOpen > 0)
        {
            partOne.transform.Rotate(-1, 0, 0, Space.Self);
            partTwo.transform.Rotate(1, 0, 0, Space.Self);
            partThree.transform.Rotate(0, 0, -1, Space.Self);
            partFour.transform.Rotate(0, 0, 1, Space.Self);
        }

        if (clawOpen < 0)
        {
            partOne.transform.Rotate(1, 0, 0, Space.Self);
            partTwo.transform.Rotate(-1, 0, 0, Space.Self);
            partThree.transform.Rotate(0, 0, 1, Space.Self);
            partFour.transform.Rotate(0, 0, -1, Space.Self);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boulder")
        {
            other.transform.parent = this.transform;
            other.GetComponent<Rigidbody>().useGravity = false;
        }
    }
}
