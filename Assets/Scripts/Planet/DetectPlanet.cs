using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlanet : MonoBehaviour
{
    public float hoverEnergy = 30f;
    public GameObject myParent;
    public float movementSpeed = 0.05f;
    private ObjectSelection chosenObject;

    private void Awake()
    {
        GameObject GameCon = GameObject.FindGameObjectWithTag("GameController");
        chosenObject = GameCon.GetComponent<ObjectSelection>();

        myParent = this.transform.parent.gameObject;

        Vector3 lookPos = myParent.transform.position;
        Vector3 newLookPos = new Vector3(lookPos.x, this.transform.position.y, lookPos.z);
        this.transform.LookAt(newLookPos);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (chosenObject.selected == this.gameObject)
        {
            moveCatcher();
        }
    }

    

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Planet"))
        {
            Debug.Log("Hit by: " + other);
            Rigidbody holder = other.GetComponent<Rigidbody>();

            Vector3 turn = new Vector3(0.3f, 0.3f, 0.3f);
            holder.AddRelativeTorque(turn);

            Animator anim = holder.transform.parent.gameObject.GetComponent<Animator>();
            Debug.Log("Parent animator is: " + anim);

            anim.speed = 0;
            holder.isKinematic = false;
            holder.useGravity = true;
            holder.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            holder.AddForce(Vector3.up * hoverEnergy, ForceMode.Acceleration);
        }
    }

    void moveCatcher()
    {
        Debug.Log("here");
        float movement = 0.0f;

        if (Input.GetKey("o"))
        {
            movement = movementSpeed;
        }

        if (Input.GetKey("i"))
        {
            movement = -movementSpeed;
        }

        if (movement != 0)
        {
            Vector3 moving = new Vector3(0.0f, 0.0f, movement);
            this.transform.Translate(moving);
        }
    }
}
