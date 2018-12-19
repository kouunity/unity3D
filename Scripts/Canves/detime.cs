using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detime : MonoBehaviour {
    public static detime instance;
    [HideInInspector]
    public bool cangetenemty ;
    [HideInInspector]
    public float timestart;
    float timemax ;
    [HideInInspector]
    public float nowtime ;
    [HideInInspector]
    public int enemtynums ;//第一波敌人五十
    [HideInInspector]
    public int bonum ;
    float timeadd = 0;

    private void Awake()
    {
        instance = this;
        init(0);
    }
    public void init(int num)
    {
        timestart = 0;
        cangetenemty = false;
        if (num == 0)
        {
            timemax = 10;
            nowtime = 10;
            enemtynums = 10;
            bonum = 1;
        }
        else if (num == 1)
        {
            timemax = 5;
            nowtime = 5;
            enemtynums = 5;
            bonum = 2;
        }

    }

    // Update is called once per frame
    void Update () {
        timeadd += Time.deltaTime;
        if (timeadd >= 1)
        {
            timestart++;
            timeadd = 0;
        }
        nowtime = timemax - timestart;
        transform.GetComponent<Text>().text = string.Format("第"+bonum+"波倒计时:"+ nowtime.ToString("0"));
        if (nowtime <= 0)
        {
            //生成敌人
            cangetenemty = true;
            transform.gameObject.SetActive(false);
        }	
	}
}
