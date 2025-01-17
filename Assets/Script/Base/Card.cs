using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Card : MonoBehaviour {
    GameObject a;
    TMP_Text number;
    Text labNum3;
    int _iCard;
    AtlasMgr atMgr;

    // Use this for initialization
    void Start() {
        //		initParas ();
    }

    // Update is called once per frame
    void Update() {
    }

    void initParas() {
        number = transform.Find("Text").GetComponent<TMP_Text>();
        labNum3 = transform.GetChild(1).GetComponent<Text>();
        atMgr = new AtlasMgr();
    }

    void initShow(bool bShow) {
        number.gameObject.SetActive(bShow);
        labNum3.gameObject.SetActive(!bShow);
    }

    public int getCardNumber() {
        return _iCard;
    }

    public void init(int iCard) {
        initParas();
        _iCard = iCard;
        var iCardNum = iCard % 100;
        var iCardType = (int)Mathf.Floor(iCard / 100);
        if (iCardNum > 13) {
            initShow(false);
            var strColor = iCardNum % 2 == 1 ? "D94432FF" : "191919FF"; // 15红14黑
            if (labNum3.transform.childCount > 0) {
                labNum3.text = "<color=#" + strColor + ">" + "JOKER" + "</color>";
                labNum3.transform.GetChild(0).GetComponent<Text>().text = "<color=#" + strColor + ">" + "robot\n工\n作\n室" + "</color>";
            } else {
                //				var str = iCardNum == 16 ? "小王" : "大王";
                labNum3.text = "<color=#" + strColor + ">" + "JK" + "</color>";
            }
        } else {
            initShow(true);
            var iColor = iCardType % 2 == 1 ? 0 : 1;
            number.text = getCardNum(iCardNum, iColor);
            var str = "huase_" + (iCardType - 1).ToString();
        }
    }

    string getCardNum(int iCard, int iColor) {
        string[] CardNum = { "A", "J", "Q", "K" };
        string str;
        if (iCard == 1)
            str = CardNum[0];
        else if (iCard > 10)
            str = CardNum[iCard - 10];
        else
            str = iCard.ToString();
        string strColor = iColor == 0 ? "D94432FF" : "191919FF"; // 0红1黑
        str = "<color=#" + strColor + ">" + str + "</color>";
        return str;
    }
}
