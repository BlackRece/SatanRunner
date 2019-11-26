using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VicarScript : MonoBehaviour {
    //public Transform[] target;      //The two places the vicar travels between
    //public float speed;     //Speed of vicar

    //private int current;    //Current position of vicar

    public GameObject Vicar;
    public GameObject Player;
    public Rigidbody rb;    //Rigidbody of water

    public GameObject waterProjectile;
    private float timeBtwShots;
    public float startTimeBtwShots;

    //Vicar movement
    void Update () {
       // if (transform.position != target[current].position) //If vicar is not at the target
        //{
           // Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);    //Change vicar's position to target with a set speed7
            //GetComponent<Rigidbody>().MovePosition(pos);    //Move rigidbody to the position
        //}
        //else
        //{
            //current = (current + 1) % target.Length;    //Sets current target
        //}

        //Water

        if (timeBtwShots <= 0)
        {
            Instantiate(waterProjectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
