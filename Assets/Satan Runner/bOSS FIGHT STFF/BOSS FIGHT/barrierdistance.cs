using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrierdistance : MonoBehaviour
{


    public GameObject devil;
    public Renderer rend;
    public Collider col;

	// Use this for initialization
	void Start ()
    {
        rend = GetComponent<Renderer>();
        col = GetComponent<Collider>();
        rend.enabled = false;
        col.enabled = false;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Vector3.Distance(devil.transform.position, this.transform.position) < 7)
        {
            rend.enabled = true;
            col.enabled = true;
        }
	}
}
