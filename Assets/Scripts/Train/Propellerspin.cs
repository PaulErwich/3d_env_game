using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propellerspin : MonoBehaviour
{
    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void FixedUpdate()
    {
        this.transform.Rotate(0, speed, 0, Space.Self);
    }
}
