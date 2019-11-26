using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile:MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector3 aim;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerTag").transform;
        aim = new Vector3(player.position.x, player.position.y, player.position.z);
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("PlayerTag").transform.position.z > GameObject.FindGameObjectWithTag("VicarTag").transform.position.z - 10)
        {
            transform.position = Vector3.MoveTowards(transform.position, aim, speed * Time.deltaTime);
        }
        else
        {
            DestroyProjectile();
        }
        
        if(transform.position.x == aim.x && transform.position.y == aim.y && transform.position.z == aim.z)
        {
            DestroyProjectile();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerTag"))
        {
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}