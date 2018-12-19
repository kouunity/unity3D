using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatebu : MonoBehaviour {
    public GameObject zidian;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        zidian.transform.RotateAround(transform.position,transform.up,10);
	}
}
