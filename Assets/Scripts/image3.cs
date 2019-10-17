using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class image3
{
    Image img15;
    Image img16;
    Image img17;
    Image img18;
    //Image imgTrezi4;

    public image3()
    {
        img15 = GameObject.Find("Icon15").GetComponent<Image>();
        img16 = GameObject.Find("Icon16").GetComponent<Image>();
        img17 = GameObject.Find("Icon17").GetComponent<Image>();
        img18 = GameObject.Find("Icon18").GetComponent<Image>();
        //imgTrezi4 = GameObject.Find("IconTrezi4").GetComponent<Image>();

        img15.color = Color.white;
        img16.color = Color.white;
        img17.color = Color.white;
        img18.color = Color.white;
        //imgTrezi4.color = Color.red;
    }

    public void changeColor(int a)
    {
        a++;
        if (a > 4)
            a = 0;
        //if ((imgTrezi4) && (a == 0))
        //{
        //    imgTrezi4.color = Color.red;
        //}
        if ((img15) && (a == 1))
        {
            img15.color = Color.green;

        }
        if ((img16) && (a == 2))
        {
            img16.color = Color.green;

        }
        if ((img17) && (a == 3))
        {
            img17.color = Color.green;

        }
        if ((img18) && (a == 4))
        {
            img18.color = Color.green;

        }
    }
}
