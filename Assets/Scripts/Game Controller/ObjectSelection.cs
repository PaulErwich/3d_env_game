using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelection : MonoBehaviour
{
    public GameObject planetCatcher1;
    public GameObject planetCatcher2;
    public GameObject planetCatcher3;
    public GameObject selected;

    // Start is called before the first frame update
    void Start()
    {
        selected = planetCatcher1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("1"))
        {
            selected = planetCatcher1;
        }

        if (Input.GetKeyUp("2"))
        {
            selected = planetCatcher2;
        }

        if (Input.GetKeyUp("3"))
        {
            selected = planetCatcher3;
        }
    }
}
