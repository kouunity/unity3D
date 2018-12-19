using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hp : MonoBehaviour {
    public Slider hpui;
	// Use this for initialization
	void Start () {
        hpui.maxValue = 100;
        hpui.value = 100;
	}
    public void hurt(int gethurt) {
        hpui.value -= gethurt;
    }
	// Update is called once per frame
	void Update () {
        transform.rotation = Camera.main.transform.rotation;
	}
}
