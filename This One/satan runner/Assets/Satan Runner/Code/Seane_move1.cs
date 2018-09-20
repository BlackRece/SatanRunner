using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seane_move1 : MonoBehaviour {

    public float respawncounter = 700f;
    public float jump_made = 0f;
    //public float move_distance = 0f;

    // Use this for initialization
    void Start()
    {
        jump_made = 1f;
        respawncounter = 900f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, -0.5f));
        //move_distance = move_distance + 0.5f;

        if (respawncounter < 0)
        {
           transform.Translate(new Vector3(0, 0, 450));
           respawncounter = 900f;
            jump_made += 0.1f;

        }

        respawncounter -= 1;
    }
}
