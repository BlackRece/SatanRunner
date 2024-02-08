using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class train_controller : MonoBehaviour {
    // grab prefab
    public GameObject carriage;

    // grab train length
    public int train_length = 5;
    public float train_speed = 2f;
    public float train_buffer = 2f;

    // create list for train parts (carriages)
    private List<GameObject> train = new List<GameObject>();

    // create carriage offset
    private float offset;

	// Use this for initialization
	void Start () {
        // set default length if invalid lenght set
        if (train_length < 1) { train_length = 5; }

        // set start point
        Vector3 start_pos = Vector3.zero;

        // calculate offset
        offset = train_buffer + carriage.GetComponent<Renderer>().bounds.size.z;
        //Debug.Log(string.Format("carriage size = {0}", offset));

        // loop through list
        for (int i = 0; i < train_length; i++) {
            // calculate position of each carriage
            start_pos.z = i * offset;
            //Debug.Log(string.Format("carriage pos {0} = {1}", i, start_pos));

            // create and store carriage into list at calculated position
            train.Add(Instantiate(carriage, start_pos, Quaternion.identity));
        }
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject cart in train) {
            cart.transform.Translate(Vector3.back * train_speed * Time.deltaTime);
        }
	}
}
