using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  SignController
 *  
 *  controls the placement of and movement of signs
 * 
 *  by: Maurice Thompson-Hamilton
 * */

public class SignController : MonoBehaviour {

    public GameObject sign_center;
    public GameObject sign_left;
    public GameObject sign_right;
    public float sign_distance;
    public bool enableSigns = true;
    public Vector3 startPos = new Vector3();

    private List<GameObject> hazards = new List<GameObject>();

	// Use this for initialization
	void Start () {
        // starting pos of signs
        if (startPos == Vector3.zero) { startPos = new Vector3(-12.5f, 14f, 165f); }

        //GameObject tmp = sign_center;
        sign_center.transform.Rotate(new Vector3(0, 90f, 0));
        sign_left.transform.Rotate(new Vector3(0, 90f, 0));
        sign_right.transform.Rotate(new Vector3(0, 90f, 0));

        sign_center.transform.position = startPos;
        startPos.x += sign_distance;
        sign_left.transform.position = startPos;
        startPos.x += sign_distance;
        sign_right.transform.position = startPos;

        Debug.Log(startPos.ToString());

        // add signs to list
        hazards.Add((GameObject)Instantiate(sign_center, startPos, Quaternion.identity));
        hazards.Add((GameObject)Instantiate(sign_left, startPos, Quaternion.identity));
        hazards.Add((GameObject)Instantiate(sign_right, startPos, Quaternion.identity));

        // Debug.Log(string.Format("number of signs :{0}", hazards.Count));
    }
	
	// Update is called once per frame
	void Update () {
        if (enableSigns) {

            Vector3 tmp = new Vector3(0, 0, 0);
            Vector3 player_pos = GameObject.FindGameObjectWithTag("PlayerTag").transform.position;
            //Debug.Log(player_pos.ToString());

            // sign counter
            int sc = hazards.Count;

            if (sc > 0) {
                foreach (GameObject sign_obj in hazards) {
                    tmp = sign_obj.transform.position;

                    tmp.z -= sign_distance;

                    if (player_pos.z > tmp.z) {
                        tmp.z -= sign_distance;

                    } else {
                        tmp.z = 165f;

                        /*
                        Destroy(sign_obj);
                        hazards.Remove(sign_obj);
                        */
                    }

                    sign_obj.transform.position = tmp;

                    /* if visible
                     * - move towards player camera
                     * - if behind player
                     * - - remove sign (Destroy?)
                     * else 
                     * */
                }
            }
        }
	}
}
