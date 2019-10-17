using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class image1
{
    Image img06;
    Image img07;
    Image img08;
    Image img09;
    //Image imgTrezi2;

    public image1()
    {
        img06 = GameObject.Find("Icon06").GetComponent<Image>();
        img07 = GameObject.Find("Icon07").GetComponent<Image>();
        img08 = GameObject.Find("Icon08").GetComponent<Image>();
        img09 = GameObject.Find("Icon09").GetComponent<Image>();
        //imgTrezi2 = GameObject.Find("IconTrezi2").GetComponent<Image>();

        img06.color = Color.white;
        img07.color = Color.white;
        img08.color = Color.white;
        img09.color = Color.white;
        //imgTrezi2.color = Color.red;

    }

    public void changeColor(int a)
    {
        a++;
        if (a > 4)
            a = 0;
        //if ((imgTrezi2) && (a == 0))
        //{
        //    imgTrezi2.color = Color.red;
        //}
        if ((img06) && (a == 1))
        {
            img06.color = Color.green;

        }
        if ((img07) && (a == 2))
        {
            img07.color = Color.green;

        }
        if ((img08) && (a == 3))
        {
            img08.color = Color.green;

        }
        if ((img09) && (a == 4))
        {
            img09.color = Color.green;

        }
    }
}
