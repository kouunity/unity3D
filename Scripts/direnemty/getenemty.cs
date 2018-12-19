using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getenemty : MonoBehaviour {
    public GameObject enemtyprefab;
    public Transform enemtyparent;

    public Text enemtynums;
    int enemtynum;
	// Use this for initialization
	void Start () {
        enemtynum = detime.instance.enemtynums;
    }
    void spwanenemty() {
        GameObject enemty = Instantiate(enemtyprefab);
        enemty.transform.parent = enemtyparent;
        Vector3 offect = new Vector3(0,0,2);
        enemty.transform.position = transform.position+offect;       
    }
    float gettime = 0;
	// Update is called once per frame
	void Update () {
        
        gettime += Time.deltaTime;
        if (detime.instance.cangetenemty)
        {
            if (enemtynum > 0)
            {
                enemtynums.gameObject.SetActive(true);          
                if (gettime >= 2)
                {
                    spwanenemty();
                    gettime = 0;
                    enemtynum--;
                }
                enemtynums.text = string.Format("第" + detime.instance.bonum + "波剩余敌人数：" + enemtynum.ToString("0"));
            }
            else {
                if (detime.instance.bonum < 2)
                {
                    if (enemtyparent.childCount==0)
                    {
                        enemtynums.gameObject.SetActive(false);
                        detime.instance.gameObject.SetActive(true);
                        detime.instance.init(1);
                        enemtynum = 5;
                    }
                  
                }
                else if (detime.instance.bonum == 2&&enemtynum==0)
                {
                    detime.instance.cangetenemty = false;
                    detime.instance.enemtynums = 0;
                }
            }
        }
    }
}
