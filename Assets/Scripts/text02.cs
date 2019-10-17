using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text02
{
    Text text5;
    Text text6;
    Text text7;
    Text text8;
    //Text textTrezi2;

    public text02()
    {
        //textTrezi2 = GameObject.Find("textTrezi2").GetComponent<Text>();
        text5 = GameObject.Find("text5").GetComponent<Text>();
        text6 = GameObject.Find("text6").GetComponent<Text>();
        text7 = GameObject.Find("text7").GetComponent<Text>();
        text8 = GameObject.Find("text8").GetComponent<Text>();

        //textTrezi2.color = Color.white;
        text5.color = Color.white;
        text6.color = Color.white;
        text7.color = Color.white;
        text8.color = Color.white;
    }

    public void changeColor(int a)
    {
        a++;
        if (a > 4)
            a = 0;
        if ((text5) && (a == 1))
        {
            text5.color = Color.green;

        }
        if ((text6) && (a == 2))
        {
            text6.color = Color.green;

        }
        if ((text7) && (a == 3))
        {
            text7.color = Color.green;

        }
        if ((text8) && (a == 4))
        {
            text8.color = Color.green;

        }
    }

    /*
    public void changeColorHead(int a)
    {
        if ((textTrezi2) && (a == 1))
        {
            textTrezi2.color = Color.red;
        }
    }
    */
}
