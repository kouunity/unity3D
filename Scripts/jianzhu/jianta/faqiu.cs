using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faqiu : MonoBehaviour {
    public Transform circlepos;
    float theta = 0f;
    // Use this for initialization
    void Start () {

		
	}
	// Update is called once per frame
	void Update () {
        theta+=2;

        float x = Mathf.Cos(theta * Mathf.Deg2Rad) * 2;
        float y = Mathf.Sin(theta * Mathf.Deg2Rad) * 2;
        float z = Mathf.Sin(theta * Mathf.Deg2Rad * 10);

        var pos = new Vector3(x, z, y);
        transform.position = pos + circlepos.position;
    }
}
