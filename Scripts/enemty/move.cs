using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class move : MonoBehaviour {
    [HideInInspector]
    public int blood = 10;
    public Canvas hps;
    Transform pointpos;

    GameObject turnpos;
    Transform nowhittrans;
    Vector3 nowhitpos;
    int num=0;
	// Use this for initialization
	void Start () {
       // pointpos = GameObject.Find("end").transform ;
        //nav.SetDestination(pointpos.position);
        turnpos = GameObject.Find("turn");
        nowhittrans = turnpos.transform.GetChild(num);
        nowhitpos = nowhittrans.position;
       
    }
   
    // Update is called once per frame
    void Update () {
        nowhitpos.y = transform.position.y;
        if (blood <= 0)
        {
            //发送死亡消息
            gamectrl.instance.getScore(10);
            Destroy(gameObject);
        }
        if (transform.position == nowhitpos)
        {
            num++;
            nowhittrans = turnpos.transform.GetChild(num);
            if (nowhittrans != null)
            {
                nowhitpos = nowhittrans.position;
                nowhitpos.y = transform.position.y;
            }
        }
        transform.LookAt(nowhitpos);
        transform.position = Vector3.MoveTowards(transform.position,nowhitpos,10*Time.deltaTime);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "jian")
        {
            Destroy(other.gameObject);
            blood -= 10;
            if (blood > 0)
            {
                hps.GetComponent<hp>().hurt(10);
            }
        }
        else if (other.tag == "faqiu")
        {
            Destroy(other.gameObject);
            blood -= 20;
            if (blood > 0)
            {
                hps.GetComponent<hp>().hurt(20);
            }
        }
        else if (other.tag == "planbu")
        {
            blood -= 15;
            if (blood > 0)
            {
                hps.GetComponent<hp>().hurt(15);
            }
        }
        else if (other.tag == "gate")
        {
            gamectrl.instance.getHurt(1);
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "jian")
        {
            Destroy(other.gameObject);
        }
        else if (other.tag == "faqiu")
        {
            Destroy(other.gameObject);
        }
    }
}
