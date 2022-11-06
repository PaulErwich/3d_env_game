using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawFollow : MonoBehaviour
{
    public GameObject clawConnector;
    public float scale = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scale = clawConnector.transform.localScale.y;

        this.transform.localPosition = new Vector3(1.85f,
            clawConnector.transform.localPosition.y - (scale / 2) - 0.05f, 0);
    }
}
