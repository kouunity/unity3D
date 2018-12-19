using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class area : MonoBehaviour {
    public GameObject paokou;
    public GameObject jiantaprefab;
    public GameObject faqiuprefab;
    [HideInInspector]
    public GameObject jian;
    public GameObject faqiu;

    public GameObject set;
    GameObject enemty;

    public float curTime;
    public float AttackCoolDown;
    // Use this for initialization
    void Start()
    {

    }
    public void spwan() {
        //判断箭塔是否为预设箭塔还是已经生成的箭塔
        //为预设箭塔则返回
        if (set.activeInHierarchy)
        {
            return;
        }
        Vector3 offset = new Vector3(0,4,0);
        if (faqiu.activeInHierarchy)
        {
            jian = Instantiate(faqiuprefab);
        }
        else
        {
            jian = Instantiate(jiantaprefab);
        }
        jian.transform.position = paokou.transform.position+offset;
        jian.transform.GetComponent<buttel>().enemty = enemty;
        jian.transform.GetComponent<buttel>().father = this.gameObject;
    }
    // Update is called once per frame
	void Update () {
        curTime -= Time.deltaTime;
        if(enemty != null && curTime <= 0){
            spwan();
            curTime = AttackCoolDown;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemty")
        {
            enemty = other.gameObject;
        }
        //spwan();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "enemty")
        {
            enemty = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "enemty")
        {
            enemty = null;
        }
    }
}
