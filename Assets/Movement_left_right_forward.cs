using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_left_right_forward : MonoBehaviour {

    public float player_x = -7;
    public float player_y = 14;
    public float player_z = -51;
    public float jump_countdown = 0;

    public GameObject player;

    // Use this for initialization
    void Start () {
        player_x = player.transform.position.x;
        player_y = player.transform.position.y;
        player_z = player.transform.position.z;
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            player_z = 1 * Time.deltaTime;
            transform.Translate(player_x, player_y, player_z);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            player_z = (1 * Time.deltaTime) * -1;
            transform.Translate(player_x, player_y, player_z);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            player_x = 1 * Time.deltaTime;
            transform.Translate(player_x, player_y, player_z);
        }

        if (Input.GetKeyDown(KeyCode.D))
        { 
            player_x = 1 * Time.deltaTime;
            transform.Translate(player_x, player_y, player_z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(" space pressed");
            if (jump_countdown == 0)
            {
                player_y = player_y + 1;
                transform.Translate(player_x, player_y, player_z);
                jump_countdown = jump_countdown + 1000;
            }

            if (jump_countdown > 0)
            {
                jump_countdown = jump_countdown - 1;
            }

        }

    }
}
