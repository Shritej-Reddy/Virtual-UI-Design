using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text04
{
    Text text14;
    Text text15;
    Text text16;
    Text text17;
    //Text textTrezi4;

    public text04()
    {
        //textTrezi4 = GameObject.Find("textTrezi4").GetComponent<Text>();
        text14 = GameObject.Find("text14").GetComponent<Text>();
        text15 = GameObject.Find("text15").GetComponent<Text>();
        text16 = GameObject.Find("text16").GetComponent<Text>();
        text17 = GameObject.Find("text17").GetComponent<Text>();

        //textTrezi4.color = Color.white;
        text14.color = Color.white;
        text15.color = Color.white;
        text16.color = Color.white;
        text17.color = Color.white;
    }

    public void changeColor(int a)
    {
        a++;
        if (a > 4)
            a = 0;
        if ((text14) && (a == 1))
        {
            text14.color = Color.green;

        }
        if ((text15) && (a == 2))
        {
            text15.color = Color.green;

        }
        if ((text16) && (a == 3))
        {
            text16.color = Color.green;

        }
        if ((text17) && (a == 4))
        {
            text17.color = Color.green;

        }
    }

    /*
    public void changeColorHead(int a)
    {
        if ((textTrezi4) && (a == 3))
        {
            textTrezi4.color = Color.red;
        }
    }
    */
}
