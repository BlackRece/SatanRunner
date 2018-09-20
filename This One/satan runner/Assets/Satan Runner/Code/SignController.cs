using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignController : MonoBehaviour {
    public GameObject sign_center;
    public GameObject sign_left;
    public GameObject sign_right;
    public GameObject tmpsign;
    public float sign_distance;
    public float sign_speed;
    public bool enableSigns = true;
    public Vector3 startLeft;
    public Vector3 startRight;
    public Vector3 startCenter;
    public Vector3 startPos;
    public Vector3 endPos;
    public int leftSignCount;
    public int rightSignCount;
    public int centerSignCount;
    public int totalSignCount;

    private List<GameObject> hazards = new List<GameObject>();
    // Use this for initialization
    void Start () {
        // set default number of signs
        if(leftSignCount==0) { leftSignCount = 5; }
        if(rightSignCount==0) { rightSignCount = 5; }
        if (centerSignCount == 0) { centerSignCount = 5; }
        if (totalSignCount == 0) { totalSignCount = 5; }

        // starting pos of signs
        if (startPos== Vector3.zero) { startPos = new Vector3(-12.5f, 14f, 165f); }
        if (startLeft == Vector3.zero) { startLeft = new Vector3(-12.5f, 14f, 165f); }
        if (startRight == Vector3.zero) { startRight = new Vector3(-12.5f, 14f, 165f); }
        if (startCenter == Vector3.zero) { startCenter = new Vector3(-12.5f, 14f, 165f); }


        // set move distance if not set
        if (sign_distance == 0) { sign_distance = 5; }

        // set move speed if not set
        if (sign_speed == 0) { sign_speed = 1.25f; }

        //GameObject tmp = sign_center;
        //sign_center.transform.Rotate(new Vector3(0, 90f, 0));
        //sign_left.transform.Rotate(new Vector3(0, 90f, 0));
        //sign_right.transform.Rotate(new Vector3(0, 0f, 0));

        // add signs to array
        FillRndArray();
        /*
        FillArray(leftSignCount, sign_left, startLeft);
        FillArray(rightSignCount, sign_right, startRight);
        FillArray(centerSignCount, sign_center, startCenter);
        */
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(string.Format("signpos@{0}, endpos@{1}", tmpsign.transform.position, endPos));
        if (enableSigns) {
            foreach (GameObject tmp in hazards) {

                if (tmp.transform.position.z.CompareTo(endPos.z) < 0) {
                    Vector3 resetPos = tmp.transform.position;
                    resetPos.z = startPos.z;
                    tmp.transform.position = resetPos;
                } else {
                    Vector3 movePos = Vector3.back;
                    //movePos.z *= Time.deltaTime* sign_speed;
                    tmp.transform.Translate(Vector3.back);
                }
            }
        }
	}

    void FillArray(int counter, GameObject sign, Vector3 pos) {
        // add certain number of signs
        for (int i = 0; i < counter; i++) {
            // add sign
            hazards.Add(Instantiate<GameObject>(sign, pos, Quaternion.identity));

            // increase position by distance for next iteration
            pos.z += sign_distance;

            //Debug.Log(string.Format("signpos@{0}", hazards[i].transform.position, endPos));
        }
    }

    void FillRndArray() {
        int counter = leftSignCount + rightSignCount + centerSignCount;

        for(int i = 0; i<3; i++) {
            int rnd = (int)Random.Range(1, 3);

            if (i == 1)
            {
                hazards.Add(Instantiate<GameObject>(sign_left, startLeft, Quaternion.identity));
            } else if (i == 2)
            {
                hazards.Add(Instantiate<GameObject>(sign_center, startCenter, Quaternion.identity));
            } else
            {
                hazards.Add(Instantiate<GameObject>(sign_right, startRight, Quaternion.identity));
            }

            // update/increase position
            // long handed method
            startLeft.z += sign_distance;
            startRight.z += sign_distance;
            startCenter.z += sign_distance;
        }
    }
}
