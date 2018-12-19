using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planbu : MonoBehaviour {
     float destime=0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        destime += Time.deltaTime;
        if (destime >= 1)
        {
            Destroy(transform.gameObject);
        }
		
	}
}
