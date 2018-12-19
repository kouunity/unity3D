using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jiantactrl : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!transform.FindChild("set").gameObject.activeInHierarchy)
        {
            Transform bar = transform.FindChild("bar");
            bar.Rotate(0, 1, 0, Space.Self);
        }
    }
}
