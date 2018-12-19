using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttel : MonoBehaviour {
    [HideInInspector]
    public GameObject enemty;
    [HideInInspector]
    public GameObject father;
   // float startime;
    // Use this for initialization
    void Start () {
       // startime = Time.time;
	}


    // Update is called once per frame
    void Update () {
        if (enemty != null)
        {
            //float speed = (Time.time-startime) / 1f;
            transform.LookAt(enemty.transform);
           // transform.position = Vector3.Slerp(transform.position,enemty.transform.position,speed );
            transform.Translate((enemty.transform.position - transform.position).normalized, Space.World);
        }

        if(enemty == null)
        {
            Destroy(gameObject);
        }
    }
}
