using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public AudioClip shoutingClip;
    public float speedDampTime = 0.01f;
    public float sensitivityX = 1.0f;
    public float animationSpeed = 1.5f;
    public float audioPitch = 0.27f;

    private float elapsedTime = 0;
    private bool noBackMov = true;

    private Animator anim;
    private HashIDs hash;

    public bool control = true;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();
        anim.SetLayerWeight(1, 1f);
    }

    private void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical");
        bool sneak = Input.GetButton("Sneak");
        float turn = Input.GetAxis("Turn");

        elapsedTime += Time.deltaTime;

        if (control)
        {
            Rotating(turn);
            MovementManager(v, sneak);
        }
        
    }

    private void Update()
    {
        bool shout = Input.GetButtonDown("Attract");
        anim.SetBool(hash.shoutingBool, shout);
        AudioManagement(shout);
    }

    void MovementManager(float vertical, bool sneaking)
    {
        anim.SetBool(hash.sneakingBool, sneaking);

        if (vertical > 0)
        {
            anim.SetFloat(hash.speedFloat, animationSpeed, speedDampTime, Time.deltaTime);
            anim.SetBool("Backwards", false);

            noBackMov = true;
        }
        
        if (vertical < 0)
        {
            if (noBackMov == true)
            {
                elapsedTime = 0;
                noBackMov = false;
            }

            anim.SetFloat(hash.speedFloat, -animationSpeed, speedDampTime, Time.deltaTime);
            anim.SetBool("Backwards", true);

            Rigidbody ourBody = this.GetComponent<Rigidbody>();
            float movement = Mathf.Lerp(0f, -0.025f, elapsedTime);
            Vector3 moveBack = new Vector3(0.0f, 0.0f, movement);
            moveBack = ourBody.transform.TransformDirection(moveBack);
            ourBody.transform.position += moveBack;
        }

        if (vertical == 0)
        {
            anim.SetFloat(hash.speedFloat, 0.00f);
            anim.SetBool(hash.backwardsBool, false);

            noBackMov = true;
        }
    }

    void Rotating(float mouseXInput)
    {
        // Access avatars rigid body
        Rigidbody ourBody = this.GetComponent<Rigidbody>();

        // First check to see if we have roataion data that needs to be applied
        if (mouseXInput != 0)
        {
            // If so we use mouseX value to create a Euler angle which provides rotation in the Y axis
            // Which is then turned to a Quaternion
            Quaternion deltaRotation = Quaternion.Euler(0f, mouseXInput * sensitivityX, 0f);

            // And then applied to turn the avatar via the rigidbody
            ourBody.MoveRotation(ourBody.rotation * deltaRotation);
        }
    }

    void AudioManagement(bool shout)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().pitch = audioPitch;
                GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            GetComponent<AudioSource>().Stop();
        }

        if (shout)
        {
            AudioSource.PlayClipAtPoint(shoutingClip, transform.position);

            GameObject thisAudio = GameObject.Find("One shot audio");

            if (thisAudio.name == "Z2 - V2 - Angry - Free - 1")
            {
                thisAudio.GetComponent<AudioSource>().pitch = audioPitch;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!control)
        {
            if (collision.gameObject.tag == "TrainCollider")
            {
                Physics.IgnoreCollision(collision.collider, this.GetComponent<BoxCollider>());
            }
        }
    }

}
