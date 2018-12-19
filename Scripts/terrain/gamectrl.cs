using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamectrl : MonoBehaviour
{
    public static gamectrl instance;
    public GameObject jiantaprefab;
    public GameObject xianzhenprefab;
    public GameObject enemtyparent;

    public Text gameover;

    public Text doller;
    int dollernum = 1000;

    public Text scoretext;
    int scorenum = 0;
    public Slider Hp;
    bool canset = true;

    string nowta = "jianta";
    private void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start()
    {
        Hp.maxValue = 10;
        Hp.value = 10;
    }
    public void getHurt(int num)
    {
        Hp.value -= num;
        if (Hp.value <= 0)
        {
            gameover.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void chose(int num)
    {
        switch (num)
        {
            case 0:
            {
                 nowta = "jianta";
            }
            break;
            case 1:
            {
                 nowta = "inta";
            }
            break;
        }
    }
    public void getScore(int num)
    {
        //加分
        scorenum += num;
        scoretext.text = string.Format("得分:{0}", scorenum);
        //加钱
      
        dollernum += num;
        doller.text = string.Format("金币:{0}", dollernum);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 100);
            //展开升级面板
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("lvup")))
            {
                GameObject ta = hit.collider.gameObject;
                Transform jianta = ta.transform.parent;
                //升级面板
                Transform lvup = jianta.FindChild("lvupcom");
                //生成面板
                Transform setface = jianta.FindChild("set");
                Transform desface = jianta.FindChild("destroy");
                //判断是否为预设箭塔
                if (setface.gameObject.activeInHierarchy)
                {
                    return;
                }
                //判断是否展开销毁面板
                if (desface.gameObject.activeInHierarchy)
                {
                    return;
                }
                lvup.gameObject.SetActive(true);
                return;
            }
            //确定升级
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("yes(lv)")))
            {
                //获取箭塔各个组件
                GameObject yes = hit.collider.gameObject;
                Transform jianta = yes.transform.parent.parent;
                Transform faqiu = jianta.FindChild("faqiu");
                //取消升级面板
                yes.transform.parent.gameObject.SetActive(false);
                //消耗金币
                if (dollernum < 10)
                {
                    return;
                }
                dollernum -= 10;
                doller.text = string.Format("金币:{0}", dollernum);
                faqiu.gameObject.SetActive(true);
                return;
            }
            //取消升级
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("no(lv)")))
            {
                GameObject no = hit.collider.gameObject;
                //取消升级面板
                no.transform.parent.gameObject.SetActive(false);
                return;
            }
            //确定生成
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("yes(set)")))
            {
                //可以继续生成
                canset = true;
                //获取箭塔的各个组件
                GameObject yes = hit.collider.gameObject;
                Transform setface = yes.transform.parent;
                Transform jianta = setface.parent;
                Transform canvas = jianta.FindChild("Canvas");
                Transform mydoller = canvas.GetChild(0);
                //判断金币是否足够
                if (dollernum < 100)
                {
                    Destroy(jianta.gameObject);
                    return;
                }
                //取消设置生成面板
                setface.gameObject.SetActive(false);

                //消耗金币
                dollernum -= 100;
                doller.text = string.Format("金币:{0}", dollernum);
                //取消箭塔的金币消耗值面板
                mydoller.gameObject.SetActive(false);
                return;
            }
            //取消生成
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("no(set)")))
            {
                GameObject no = hit.collider.gameObject;
                Transform jianta = no.transform.parent.parent;
                Destroy(jianta.gameObject);
                canset = true;
                return;
            }
            //展开销毁面板
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("des")))
            {
                GameObject ta = hit.collider.gameObject;
                Transform jianta = ta.transform.parent;
                Transform des = jianta.FindChild("destroy");
                Transform setface = jianta.FindChild("set");
                Transform lvface = jianta.FindChild("lvupcom");
                //判断是否为预设箭塔
                if (setface.gameObject.activeInHierarchy)
                {
                    return;
                }
                //判断是否展开升级面板
                if (lvface.gameObject.activeInHierarchy)
                {
                    return;
                }
                des.gameObject.SetActive(true);
                return;
            }
            //确定销毁
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("yes(des)")))
            {
                //获取箭塔
                GameObject yes = hit.collider.gameObject;
                Transform setface = yes.transform.parent;
                Transform jianta = setface.parent;
                //销毁箭塔
                Destroy(jianta.gameObject);

                //返回金币
                dollernum += 50;
                doller.text = string.Format("金币:{0}", dollernum);
                return;
            }
            //取消销毁
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("no(des)")))
            {
                GameObject no = hit.collider.gameObject;
                //取消销毁面板
                no.transform.parent.gameObject.SetActive(false);
                return;
            }
            //生成预设箭塔
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("wall")))
            {
                //无法在箭塔底座附近生成新塔
                if (!Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("dizuo")))
                {
                    if (canset)
                    {
                        if (nowta == "jianta")
                        {
                            GameObject ta = Instantiate(jiantaprefab);
                            ta.transform.parent = this.transform.parent;
                            ta.transform.position = hit.point + new Vector3(0, 2.3f, 0);
                            //点击生成或取消生成前，无法新建箭塔，且当前箭塔无法攻击
                            canset = false;
                        }
                    }
                }
            }
            //生成内置箭阵
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("inside")))
            {
                if (canset)
                {
                    if (nowta == "inta")
                    {
                        GameObject dir = hit.collider.gameObject;
                        GameObject ta = Instantiate(xianzhenprefab);
                        ta.transform.parent = this.transform.parent;
                        ta.transform.position = hit.point;
                        //得到所有對號組件和金錢標誌
                        Transform setface = ta.transform.FindChild("set");
                        Transform lvface = ta.transform.FindChild("lvupcom");
                        Transform desface = ta.transform.FindChild("destroy");
                        Transform doface = ta.transform.FindChild("Canvas");

                        //判断位置改变朝向  
                        if (dir.tag == "left")
                        {
                            ta.transform.eulerAngles = new Vector3(0,0,0);
                            setface.transform.eulerAngles=new Vector3(-90,0,0);
                            lvface.transform.eulerAngles = new Vector3(-90, 0,0);
                            desface.transform.eulerAngles = new Vector3(-90, 0,0);
                            doface.transform.eulerAngles = new Vector3(0, 0,0);

                        }
                        else if (dir.tag == "right")
                        {
                            ta.transform.eulerAngles = new Vector3(0, 180, 0);
                            setface.transform.eulerAngles = new Vector3(-90, 180, 0);
                            lvface.transform.eulerAngles = new Vector3(-90, 180, 0);
                            desface.transform.eulerAngles = new Vector3(-90, 180, 0);
                            doface.transform.eulerAngles = new Vector3(0, 180, 0);

                        }
                        else if (dir.tag == "forward")
                        {
                            ta.transform.eulerAngles = new Vector3(0, -90, 0);
                            setface.transform.eulerAngles = new Vector3(-90, -90, 0);
                            lvface.transform.eulerAngles = new Vector3(-90, -90, 0);
                            desface.transform.eulerAngles = new Vector3(-90, -90, 0);
                            doface.transform.eulerAngles = new Vector3(0, 0, 0);
                        }
                        else if (dir.tag == "back")
                        {
                            ta.transform.eulerAngles = new Vector3(0, 90, 0);
                            setface.transform.eulerAngles = new Vector3(-90, 90, 0);
                            lvface.transform.eulerAngles = new Vector3(-90, 90, 0);
                            desface.transform.eulerAngles = new Vector3(-90, 90, 0);
                            doface.transform.eulerAngles = new Vector3(0, 90, 0);
                        }
                        //点击生成或取消生成前，无法新建箭塔，且当前箭塔无法攻击
                        canset = false;
                    }

                }
            }
        }
        //遍历场景，无敌人则胜利
        if (detime.instance.bonum == 2)
        {
            if (detime.instance.cangetenemty == false&&detime.instance.enemtynums==0)//第二波敌人生成完毕
            {
                //遍历场景
                if (enemtyparent.transform.childCount == 0)//无敌人
                {
                    //显示胜利
                    if (Hp.value > 0)
                    {
                        gameover.gameObject.SetActive(true);
                        gameover.text = string.Format("胜利");
                        Time.timeScale = 0;
                    }
                }
            }
        }
    }
}
