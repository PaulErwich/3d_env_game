using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleControl : MonoBehaviour
{
    private GameObject player;
    private PlayerMovement playerScript;
    private Animator playerAnimator;

    private Move_Train trainScript;
    private BoxCollider trainCollider;

    public Camera playerCam;
    public Camera trainCam;

    private bool parented = false;
    private bool inside = false;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerMovement>();
        playerAnimator = player.GetComponent<Animator>();
        trainScript = this.GetComponentInParent<Move_Train>();
        trainCollider = this.GetComponentInParent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (parented)
        {
            player.transform.position = this.transform.position;
            player.transform.rotation = this.transform.rotation;
        }

        if (Input.GetKeyUp("p") && inside)
        {
            if (playerScript.control)
            {
                trainScript.control = true;
                playerScript.control = false;
                player.transform.parent = this.transform;
                playerAnimator.SetFloat("Speed", 0f);
                playerAnimator.SetBool("Backwards", false);
                player.transform.position = this.transform.position;
                parented = true;
                playerCam.enabled = false;
                trainCam.enabled = true;
                player.GetComponent<CapsuleCollider>().enabled = false;
            }
            else if (trainScript.control)
            {
                trainScript.control = false;
                playerScript.control = true;
                player.transform.parent = null;
                parented = false;
                player.transform.position = this.transform.position;
                player.transform.position += Vector3.right * 5;
                playerCam.enabled = true;
                trainCam.enabled = false;
                player.GetComponent<CapsuleCollider>().enabled = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        inside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        inside = false;
    }
}
