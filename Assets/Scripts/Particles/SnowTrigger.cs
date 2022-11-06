using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowTrigger : MonoBehaviour
{
    public GameObject boulder;
    private GameObject new_boulder;

    private ParticleSystem snowChild;
    private float timer = 0f;
    private int boulder_count = 0;

    private void Awake()
    {
        snowChild = this.GetComponentInChildren<ParticleSystem>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2 && boulder_count < 100)
        {
            int scale = Random.Range(5, 15);
            new_boulder = Instantiate(boulder, this.transform.position, this.transform.rotation);
            new_boulder.transform.localScale = new Vector3(scale, scale, scale);
            new_boulder.GetComponent<Rigidbody>().mass *= scale;

            timer = 0;
            boulder_count++;
        }
    }
}
