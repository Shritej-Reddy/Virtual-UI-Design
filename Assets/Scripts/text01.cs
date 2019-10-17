using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text01
{
    Text text1;
    Text text2;
    Text text3;
    Text text4;
    Text text5;
    //Text textTrezi1;

    public text01()
    {
        //textTrezi1 = GameObject.Find("textTrezi1").GetComponent<Text>();
        text1 = GameObject.Find("text1").GetComponent<Text>();
        text2 = GameObject.Find("text2").GetComponent<Text>();
        text3 = GameObject.Find("text3").GetComponent<Text>();
        text4 = GameObject.Find("text4").GetComponent<Text>();
        text5 = GameObject.Find("text5").GetComponent<Text>();

        //textTrezi1.color = Color.white;
        text1.color = Color.white;
        text2.color = Color.white;
        text3.color = Color.white;
        text4.color = Color.white;
        text5.color = Color.white;
    }

    public void changeColor(int a)
    {
        a++;
        if (a > 5)
            a = 0;
        //if((textTrezi1) && (a ==0))
        //{
        //    textTrezi1.color = Color.red;
        //}
        if ((text1) && (a == 1))
        {
            text1.color = Color.green;

        }
        if ((text2) && (a == 2))
        {
            text2.color = Color.green;

        }
        if ((text3) && (a == 3))
        {
            text3.color = Color.green;

        }
        if ((text4) && (a == 4))
        {
            text4.color = Color.green;

        }
        if ((text5) && (a == 5))
        {
            text5.color = Color.green;

        }
    }
    /*
    public void changeColorHead(int a)
    {
        if ((textTrezi1) && (a == 0))
        {
            textTrezi1.color = Color.red;
        }
    }
    */
}
