using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popebarrelmove : MonoBehaviour {

    public Rigidbody rb;
    public Camera cam;
    public GameObject devil;
    private float counter;
    public Renderer rend;
    public Collider col;
    public GameObject Wave;



    // Use this for initialization
    void Start ()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        counter = 0;
        rend = GetComponent<Renderer>();
        col = GetComponent<Collider>();
        rb.angularVelocity = Vector3.zero;
        //rend.enabled = false;
        //col.enabled = false;
        //this.GetComponent<Rigidbody>().useGravity = false;

    }
	
	// Update is called once per frame
	void Update ()
    {

        if (counter < 0)
        {
            rend.enabled = true;
            col.enabled = true;
            this.GetComponent<Rigidbody>().useGravity = true;
            Rigidbody clone;
            clone = Instantiate(rb, transform.position, transform.rotation, Wave.transform);
            rend.enabled = false;
            col.enabled = false;
            this.GetComponent<Rigidbody>().useGravity = false;
            clone.velocity = new Vector3(0, 0, -20);
            
            counter = 5;
        }

        if (Vector3.Distance(devil.transform.position, this.transform.position) < 70 && (counter <= 0))
        {
            counter = 5;
        }

        if (counter > 0)
        {
            counter -= Time.deltaTime;
        }


        



        if (this.transform.position.z < cam.transform.position.z)
        {
            Destroy(gameObject);
        }
	}
    
}
