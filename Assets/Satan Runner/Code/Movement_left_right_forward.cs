using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_left_right_forward : MonoBehaviour {


    //need to fix jump glich and direction of movement


    public float player_x;
    public float player_y;
    public float player_z;
    public float jump_cooldown = 0.01f;
    float jump_elapsed = 0;
    bool canJump = true;
    

    public GameObject player;

    //RaycastHit hit;

    //int layerMask = 1 << 8;

    // Use this for initialization
    void Start () {
      
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (!canJump)
        {
            jump_elapsed += Time.deltaTime;
            if (jump_elapsed <= jump_cooldown)
            {
                canJump = true;
                jump_elapsed = 0;
            }

        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(-4.5f * Time.deltaTime , 0, 0));
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(4.5f * Time.deltaTime, 0, 0));
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(0, 0, -4.5f * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(0, 0, 4.5f * Time.deltaTime));
        }


        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (canJump)
            {
                canJump = false;
                Debug.Log(" space pressed");

                Debug.Log("test 2");


                Debug.Log("test 3");
                //transform.Translate(0, 2f, 0);


                Rigidbody rb = player.GetComponent<Rigidbody>();
                rb.velocity = new Vector3(0, 12.5f, 0);
                //rb.AddForce(new Vector3(0, 25000f, 0));
            }
 


                    
        }

        



    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Train")
            canJump = true;
    }



    //    }

    //    //if (jump_countdown > 0)
    //    //{
    //        //jump_countdown = jump_cooldown - 1;
    //    //}
    //}

    private Vector3 Vector3Int(int v1, float v2, int v3)
    {
        throw new NotImplementedException();
    }

}
