using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
    public bool turning = true;
    public float turnSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        if (turning == true)
        {
            this.transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed);
        }
    }
}
