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
    public float sign_speed;
    public bool enableSigns = true;
    public Vector3 startPos = new Vector3();
    

    private List<GameObject> hazards = new List<GameObject>();
    private Vector3 sign_move;

	// Use this for initialization
	void Start () {
        // starting pos of signs
        if (startPos == Vector3.zero) { startPos = new Vector3(-12.5f, 14f, 165f); }

        // set move distance if not set
        if (sign_distance == 0) { sign_distance = 5; }

        // set move speed if not set
        if (sign_speed == 0) { sign_speed = 1.25f; }

        //GameObject tmp = sign_center;
        sign_center.transform.Rotate(new Vector3(0, 90f, 0));
        sign_left.transform.Rotate(new Vector3(0, 90f, 0));
        sign_right.transform.Rotate(new Vector3(0, 90f, 0));

        sign_center.transform.position = startPos;
        //Debug.Log(string.Format("sign_center {0}", startPos));

        startPos.z += sign_distance;
        sign_left.transform.position = startPos;
        //Debug.Log(string.Format("sign_left {0}", startPos));

        startPos.z += sign_distance;
        sign_right.transform.position = startPos;
        //Debug.Log(string.Format("sign_right {0}", startPos));

        // add signs to list
        hazards.Add(Instantiate(sign_center, startPos, Quaternion.identity) as GameObject);
        hazards.Add(Instantiate(sign_left, startPos, Quaternion.identity) as GameObject);
        hazards.Add(Instantiate(sign_right, startPos, Quaternion.identity) as GameObject);

        // Debug.Log(string.Format("number of signs :{0}", hazards.Count));
    }
	
	// Update is called once per frame
	void Update () {
        //debug - test movement
        //hazards[0].transform.Translate (Vector3.forward);
        
        if (enableSigns) {

            Vector3 tmp = new Vector3(0, 0, 0);
            Vector3 player_pos = GameObject.FindGameObjectWithTag("PlayerTag").transform.position;
            //Debug.Log(player_pos.ToString());

            // sign counter
            int sc = hazards.Count;

            if (sc > 0) {
                foreach (GameObject sign_obj in hazards) {
                    // get current sign's pos
                    tmp = sign_obj.transform.position;
                    
                    // get sample of new pos
                    tmp.z -= sign_distance;

                    // test if sample pos would move sign past player's view
                    //if (player_pos.z > tmp.z) {
                    int past_player = player_pos.z.CompareTo(tmp.z);
                    Debug.Log(string.Format("past_player={0}, player_pos={1}, tmp.z={2}", past_player, player_pos.z, tmp.z));

                    if (past_player > 0) {
                        // if so, set translation vector
                        sign_move = new Vector3(0, 0, (float)sign_distance * sign_speed * Time.deltaTime);
                        Debug.Log(string.Format("sign_move = {0}", sign_move));

                        // move sign
                        sign_obj.transform.Translate(sign_move);

                    } else {
                        // otherwise, reset sign pos to starting pos
                        sign_obj.transform.position = startPos;
                        Debug.Log(string.Format("startpos@{0}, sign_obj@{1}", startPos, sign_obj.transform.position));
                        //tmp.z = 165f;

                        /*
                        Destroy(sign_obj);
                        hazards.Remove(sign_obj);
                        */

                    }

                    //sign_obj.transform.position = tmp;
                    //Debug.Log(string.Format("player@{0} - tmp@{1} - sign@{2}",player_pos, tmp, sign_obj.transform.position));

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
