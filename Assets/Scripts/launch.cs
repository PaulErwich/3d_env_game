using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launch : MonoBehaviour
{
    public GameObject projectile;
    public float projectileForce = 800f;
    GameObject missile;
    public bool missileIsLive = false;

    private void FixedUpdate()
    {
        bool fire = Input.GetButton("Fire");
        bool instantiate = Input.GetButton("Instantiate");

        if (instantiate && !missileIsLive)
        {
            missile = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
            missile.GetComponent<Rigidbody>().useGravity = false;
            missileIsLive = true;
        }
        if (fire && missileIsLive)
        {
            missile.GetComponent<Rigidbody>().AddForce(missile.transform.right * projectileForce, ForceMode.Acceleration);
            missile.GetComponent<Rigidbody>().useGravity = true;
            missileIsLive = false;
        }
    }
}
