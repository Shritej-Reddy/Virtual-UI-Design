using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class image
{
    Image img01;
    Image img02;
    Image img03;
    Image img04;
    Image img05;
    //Image imgTrezi1;

    public image()
    {
        img01 = GameObject.Find("Icon01").GetComponent<Image>();
        img02 = GameObject.Find("Icon02").GetComponent<Image>();
        img03 = GameObject.Find("Icon03").GetComponent<Image>();
        img04 = GameObject.Find("Icon04").GetComponent<Image>();
        img05 = GameObject.Find("Icon05").GetComponent<Image>();
        //imgTrezi1 = GameObject.Find("IconTrezi1").GetComponent<Image>();


        img01.color = Color.white;
        img02.color = Color.white;
        img03.color = Color.white;
        img04.color = Color.white;
        img05.color = Color.white;
        //imgTrezi1.color = Color.red;

    }

    public void changeColor(int a)
    {
        a++;
        if (a > 5)
            a = 0;
        //if ((imgTrezi1) && (a == 0))
        //{
        //    imgTrezi1.color = Color.red;
        //}
        if ((img01) && (a == 1))
        {
            img01.color = Color.green;

        }
        if ((img02) && (a == 2))
        {
            img02.color = Color.green;

        }
        if ((img03) && (a == 3))
        {
            img03.color = Color.green;

        }
        if ((img04) && (a == 4))
        {
            img04.color = Color.green;

        }
        if ((img05) && (a == 5))
        {
            img05.color = Color.green;

        }
    }
}
