using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startgame : MonoBehaviour {
    public GameObject first;
	// Use this for initialization
	void Start () {
		
	}
    public void onclick() {
        first.SetActive(true);
        transform.gameObject.SetActive(false);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
