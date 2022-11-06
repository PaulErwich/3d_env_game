using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollyZoom : MonoBehaviour
{
    public Transform target;
    public Camera zoomCamera;

    private float initHeightAtDistance;
    public bool dollyZoomEnabled;

    // Calculate the frustrum height at a given distance from the camera
    float FrustrumHeightAtDistance(float distance)
    {
        return 2.0f * distance * Mathf.Tan(zoomCamera.fieldOfView * 0.5f * Mathf.Deg2Rad);
    }

    // Calculate the FOV required to get a given frustrum height at a given distance
    float FOVForHeightAndDistance(float height, float distance)
    {
        return 2.0f * Mathf.Atan(initHeightAtDistance * 0.5f / distance) * Mathf.Rad2Deg;
    }

    void StartDollyZoomEffect()
    {
        var distance = Vector3.Distance(transform.position, target.position);
        initHeightAtDistance = FrustrumHeightAtDistance(distance);
        transform.LookAt(target.transform);
        dollyZoomEnabled = true;
    }

    void StopDollyZoomEffect()
    {
        dollyZoomEnabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartDollyZoomEffect();
    }

    // Update is called once per frame
    void Update()
    {
        if (dollyZoomEnabled)
        {
            var currDistance = Vector3.Distance(transform.position, target.position);
            zoomCamera.fieldOfView = FOVForHeightAndDistance(initHeightAtDistance, currDistance);
        }

        if ((Input.GetKey("[")) || (Input.GetKey("]")))
        {
            transform.Translate(Input.GetAxis("AltVertical") * Vector3.forward * Time.deltaTime);
        }
    }
}
