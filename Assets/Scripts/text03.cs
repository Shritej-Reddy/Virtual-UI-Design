using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text03
{
    Text text9;
    Text text10;
    Text text11;
    Text text12;
    Text text13;
    //Text textTrezi3;

    public text03()
    {
        //textTrezi3 = GameObject.Find("textTrezi3").GetComponent<Text>();
        text9 = GameObject.Find("text9").GetComponent<Text>();
        text10 = GameObject.Find("text10").GetComponent<Text>();
        text11 = GameObject.Find("text11").GetComponent<Text>();
        text12 = GameObject.Find("text12").GetComponent<Text>();
        text13 = GameObject.Find("text13").GetComponent<Text>();

        //textTrezi3.color = Color.white;
        text9.color = Color.white;
        text10.color = Color.white;
        text11.color = Color.white;
        text12.color = Color.white;
        text13.color = Color.white;
    }

    public void changeColor(int a)
    {
        a++;
        if (a > 5)
            a = 0;
        if ((text9) && (a == 1))
        {
            text9.color = Color.green;

        }
        if ((text10) && (a == 2))
        {
            text10.color = Color.green;

        }
        if ((text11) && (a == 3))
        {
            text11.color = Color.green;

        }
        if ((text12) && (a == 4))
        {
            text12.color = Color.green;

        }
        if ((text13) && (a == 5))
        {
            text13.color = Color.green;

        }
    }

    /*
    public void changeColorHead(int a)
    {
        if ((textTrezi3) && (a == 2))
        {
            textTrezi3.color = Color.red;
        }
    }
    */
}
