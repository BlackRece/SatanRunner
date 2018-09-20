using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_left_right_forward : MonoBehaviour {


    //need to fix jump glich and direction of movement


    public float player_x;
    public float player_y;
    public float player_z;
    public float jump_countdown = 0;
    public float jump_counter = 100;

    public GameObject player;

    // Use this for initialization
    void Start () {
      
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(-0.1f, 0, 0));
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0.1f, 0, 0));
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(0, 0, 0.1f));
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(0, 0, -0.1f));
        }

        if (Input.GetKey(KeyCode.Space))
        {
            jump_counter = 100;
            Debug.Log(" space pressed");
            if (jump_countdown < 0)
            {
                Debug.Log("test 2");
                if (jump_counter > 0)
                {
                    Debug.Log("test 3");
                    transform.Translate(0, 0.01f, 0);
                    jump_counter -= 1;

                }
                jump_countdown = jump_countdown + 1000;
            }

        }

          jump_countdown = jump_countdown - 1;

    }
}
