using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sign_controller : MonoBehaviour {
    public GameObject sign_left;
    public GameObject sign_right;
    public GameObject sign_middle;

    public int sign_speed = 1;
    public int sign_space = 20;

    public int left_count = 1;
    public int right_count = 1;
    public int mid_count = 1;

    public Vector3 start_pos = Vector3.zero;

    private List<GameObject> signs = new List<GameObject>();
    private Camera cam;
    private int sign_total;

	// Use this for initialization
	void Start () {
        // get camera
        cam = Camera.main;

        // calculate starting pos
        start_pos.z = 30 * 5;

        // fill list of signs
        for(int i = 0; i < left_count; i++) {
            signs.Add(Instantiate(sign_left, start_pos, Quaternion.identity));
        }

        for(int i = 0; i < right_count; i++) {
            signs.Add(Instantiate(sign_right, start_pos, Quaternion.identity));
        }

        for(int i = 0; i < mid_count; i++) {
            signs.Add(Instantiate(sign_middle, start_pos, Quaternion.identity));
        }

        // loop through all signs
        foreach (GameObject sign in signs) {
            // deactivate/hide sign
            sign.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
        //local vars
        float cam_pos = cam.transform.position.z;
        float sign_pos = 0;
        float test = 0;
        GameObject currSign, lastSign;

        // count number of active signs
        int active_signs = 0;

		// loop through all signs
        foreach(GameObject sign in signs) {
            // check if sign active
            if (sign.activeSelf) {
                // move each sign
                sign.transform.Translate(Vector3.back * sign_space * Time.deltaTime);

                // increase active sign counter
                active_signs++;

                // if current sign past player/camera
                currSign = sign;
                sign_pos = currSign.transform.position.z;
                test = sign_pos.CompareTo(cam_pos);
                //Debug.Log(string.Format("cam@ {0} : sign@ {1} : test = {2}", cam_pos, sign_pos, test));
                if (test <= 0) {
                    // deactivate/hide sign
                    sign.SetActive(false);

                    // reset sign_pos to last sign
                    //sign_pos = last_sign.z;
                } else {
                    // if current sign is futher away than last sign
                    test = sign_pos.CompareTo(lastSign.transform.position.z);
                    Debug.Log(string.Format("curr sign@{0} - last sign@{1} - test = {2}", sign_pos, lastSign.transform.position.z, test));
                    if(test > 0) {
                        Debug.Log(string.Format("new last sign"));
                        // set current sign as last sign
                        last = sign.transform.position;
                    }
                }
            }
        }

        Debug.Log(string.Format("active signs = {0}", active_signs));

        // check if all signs are active
        if (active_signs < signs.Count) {
            /*
            switch (active_signs) {
                case 0:
                    // pick a random sign
                    int rnd_sign = Random.Range(0, signs.Count);

                    // activate chosen sign
                    signs[rnd_sign].SetActive(true);

                    // position chosen sign
                    signs[rnd_sign].transform.position = start_pos;

                    break;
                case 1:
                    if (test >= 0) {
                        Debug.Log(string.Format("next sign pos={0}", sign.transform.position.z + sign_space));
                    }
                    break;
            }
            */
            // if no signs are active
            if (active_signs < 1) {
                // pick a random sign
                int rnd_sign = Random.Range(0, signs.Count);

                // activate chosen sign
                signs[rnd_sign].SetActive(true);

                // position chosen sign
                signs[rnd_sign].transform.position = start_pos;
            }
        }
        /*
            // if 2 or more signs
        } else if (active_signs >= 2) {
            // set check var
            sign_pos = cam_pos;

            // loop through all signs (again :( )
            foreach(GameObject sign in signs) {
                // if active
                if (sign.activeSelf) {
                    // check distance from camera
                    test = sign.transform.position.z.CompareTo(cam_pos + sign_space);
                    Debug.Log(string.Format("active sign test = {0}", test));
                    if (test >= 0) {
                        Debug.Log(string.Format("next sign pos={0}", sign.transform.position.z + sign_space));
                    }
                    else {
                        //sign_pos = sign.transform.position.z;
                    }
                }
            }
        }*/
    }
}
