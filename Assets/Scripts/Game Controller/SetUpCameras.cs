using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpCameras : MonoBehaviour
{
    public Camera FollowCam;
    public Camera TrainCam;
    public Camera PiPCam;

    // Start is called before the first frame update
    void Start()
    {
        GameObject PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        FollowCam.enabled = true;
        TrainCam.enabled = false;
        PiPCam.enabled = false;
        PlayerCharacter.GetComponent<AudioListener>().enabled = true;
    }

    private void Update()
    {
        if (Input.GetKeyUp("[5]") || Input.GetKeyUp("5"))
        {
            PiPCam.enabled = !PiPCam.enabled;
        }
    }
}
