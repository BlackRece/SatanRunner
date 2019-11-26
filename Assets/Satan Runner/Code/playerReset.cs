using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerReset : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnCollisionEnter (Collision col){ 
       
        if (col.gameObject.name == "cageFloor" || col.gameObject.name == "Vicar" || col.gameObject.tag == "Water(Clone)")
        { 
            Debug.Log("hello");
            transform.position = new Vector3(-6.852f, 13.8f, -51.423f);
            SceneManager.LoadScene("devil game");

        }

        if (col.gameObject.tag == "PopBoi")
        {
            Debug.Log("hello");
            //transform.position = new Vector3(-6.852f, 13.8f, -51.423f);
            SceneManager.LoadScene("menu");

        }
    }
}