using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameractrl : MonoBehaviour {

    public Transform cen;
	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(1))
        {
            transform.LookAt(cen);
            transform.RotateAround(cen.position, cen.up, Input.GetAxis("Mouse X"));
        }
	}
}
