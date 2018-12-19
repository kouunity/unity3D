using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getbuttrl : MonoBehaviour {
    public GameObject burtlpre;
    public Transform rotapos;
    // Use this for initialization
     float spwantime = 0;
	void Start () {
		
	}
    void spwan() {
        GameObject verbut = Instantiate(burtlpre);
        Rigidbody rgb = verbut.GetComponent<Rigidbody>();
        verbut.transform.position = transform.position;
        //判断炮口朝向
        Transform inta = transform.parent;
        if (inta.gameObject.name == "faqiu")
        {
            inta = inta.parent;
        }
        if (Mathf.Approximately(inta.eulerAngles.y, 0f))//left
        {
            verbut.transform.position = transform.position + new Vector3(3, 0, 0);//左移3
            rgb.AddRelativeForce(0, -5000, 0);
        }
        else if (Mathf.Approximately(inta.eulerAngles.y, 270f))//forward
        {
            //转向
            verbut.transform.position = transform.position + new Vector3(0, 0, 3);//前移3
            verbut.transform.eulerAngles = new Vector3(90,0, 0);
            rgb.AddRelativeForce(0, 5000, 0);
        }
        else if (Mathf.Approximately(inta.eulerAngles.y, 90f))//back
        {
            //转向
            verbut.transform.eulerAngles = new Vector3(90, 0, 0);
            verbut.transform.position = transform.position + new Vector3(0, 0, -3);//后移3
            rgb.AddRelativeForce(0, -5000, 0);
        }
        else if (Mathf.Approximately(inta.eulerAngles.y, 180f))//right
        {
            verbut.transform.position = transform.position + new Vector3(-4, 0, 0);//右移4
            rgb.AddRelativeForce(0, 5000, 0);
        }  
    }
	// Update is called once per frame
	void Update () {
        if (transform.parent.name != "faqiu")
        {
            transform.RotateAround(rotapos.position,transform.parent.right,10);
        }
        if (transform.parent.name != "faqiu")
        {
            if (!transform.parent.FindChild("set").gameObject.activeInHierarchy)
            {
                spwantime += Time.deltaTime;
                if (spwantime >= 4)
                {
                    spwan();
                    spwantime = 0;
                }
            }
        }
        else if (transform.parent.name == "faqiu")
        {       
            spwantime += Time.deltaTime;
            if (spwantime >= 4)
            {
                 spwan();
                 spwantime = 0;
            }
        }
       
    }
}
