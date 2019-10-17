using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class image2
{
    Image img10;
    Image img11;
    Image img12;
    Image img13;
    Image img14;
    //Image imgTrezi3;

    public image2()
    {
        img10 = GameObject.Find("Icon10").GetComponent<Image>();
        img11 = GameObject.Find("Icon11").GetComponent<Image>();
        img12 = GameObject.Find("Icon12").GetComponent<Image>();
        img13 = GameObject.Find("Icon13").GetComponent<Image>();
        img14 = GameObject.Find("Icon14").GetComponent<Image>();
        //imgTrezi3 = GameObject.Find("IconTrezi3").GetComponent<Image>();

        img10.color = Color.white;
        img11.color = Color.white;
        img12.color = Color.white;
        img13.color = Color.white;
        img14.color = Color.white;
        //imgTrezi3.color = Color.red;

    }

    public void changeColor(int a)
    {
        a++;
        if (a > 5)
            a = 0;
        //if ((imgTrezi3) && (a == 0))
        //{
        //    imgTrezi3.color = Color.red;
        //}
        if ((img10) && (a == 1))
        {
            img10.color = Color.green;

        }
        if ((img11) && (a == 2))
        {
            img11.color = Color.green;

        }
        if ((img12) && (a == 3))
        {
            img12.color = Color.green;

        }
        if ((img13) && (a == 4))
        {
            img13.color = Color.green;

        }
        if ((img14) && (a == 5))
        {
            img14.color = Color.green;

        }
    }
}
