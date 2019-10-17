using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trezi : MonoBehaviour
{
    public GameObject TreziParent;

    public GameObject Trezi1;
    public GameObject Trezi2;
    public GameObject Trezi3;
    public GameObject Trezi4;

    public Image Trezi1bg;
    public Image Trezi2bg;
    public Image Trezi3bg;
    public Image Trezi4bg;

    public GameObject Trezi5;

    public Image imgTrezi1;
    public Image imgTrezi2;
    public Image imgTrezi3;
    public Image imgTrezi4;

    Color defColor;

    //public Image imgTrezi5;

    public Text textTrezi1;
    public Text textTrezi2;
    public Text textTrezi3;
    public Text textTrezi4;

    //public Text textTrezi5;

    private Vector3[] TreziPosX = new Vector3[6];

    RectTransform a;
    RectTransform b;
    RectTransform c;
    RectTransform d;
    
    //RectTransform e;

    Vector3[] startPosition = new Vector3[6];

    void Awake()
    {
        TreziParent = GameObject.Find("Trezi");

        Trezi1 = GameObject.Find("Trezi1");
        Trezi2 = GameObject.Find("Trezi2");
        Trezi3 = GameObject.Find("Trezi3");
        Trezi4 = GameObject.Find("Trezi4");

        Trezi5 = GameObject.Find("Trezi5");

        Trezi5.SetActive(false);

        defColor = new Color32(32, 32, 32, 255);

        Trezi1bg = GameObject.Find("Trezi1").GetComponent<Image>();
        Trezi2bg = GameObject.Find("Trezi2").GetComponent<Image>();
        Trezi3bg = GameObject.Find("Trezi3").GetComponent<Image>();
        Trezi4bg = GameObject.Find("Trezi4").GetComponent<Image>();

        imgTrezi1 = GameObject.Find("IconTrezi1").GetComponent<Image>();
        imgTrezi2 = GameObject.Find("IconTrezi2").GetComponent<Image>();
        imgTrezi3 = GameObject.Find("IconTrezi3").GetComponent<Image>();
        imgTrezi4 = GameObject.Find("IconTrezi4").GetComponent<Image>();

        //imgTrezi5 = GameObject.Find("IconTrezi5").GetComponent<Image>();

        textTrezi1 = GameObject.Find("textTrezi1").GetComponent<Text>();
        textTrezi2 = GameObject.Find("textTrezi2").GetComponent<Text>();
        textTrezi3 = GameObject.Find("textTrezi3").GetComponent<Text>();
        textTrezi4 = GameObject.Find("textTrezi4").GetComponent<Text>();

        //textTrezi5 = GameObject.Find("textTrezi5").GetComponent<Text>();


        a = GameObject.Find("Trezi1").GetComponent<RectTransform>();
        b = GameObject.Find("Trezi2").GetComponent<RectTransform>();
        c = GameObject.Find("Trezi3").GetComponent<RectTransform>();
        d = GameObject.Find("Trezi4").GetComponent<RectTransform>();

       // e = GameObject.Find("Trezi5").GetComponent<RectTransform>();
    }

    void Start()
    {
        Trezi1.SetActive(true);
        Trezi2.SetActive(true);
        Trezi3.SetActive(true);
        Trezi4.SetActive(true);

        //Trezi5.SetActive(true);

        Trezi1bg.color = defColor;
        Trezi2bg.color = defColor;
        Trezi3bg.color = defColor;
        Trezi4bg.color = defColor;

        imgTrezi1.color = Color.black;
        imgTrezi2.color = Color.black;
        imgTrezi3.color = Color.black;
        imgTrezi4.color = Color.black;
        
        //imgTrezi5.color = Color.white;
        
        textTrezi1.color = Color.black;
        textTrezi2.color = Color.black;
        textTrezi3.color = Color.black;
        textTrezi4.color = Color.black;
        
        //textTrezi5.color = Color.white;


        startPosition[0] = Trezi1.transform.position;
        startPosition[1] = Trezi2.transform.position;
        startPosition[2] = Trezi3.transform.position;
        startPosition[3] = Trezi4.transform.position;

        //startPosition[4] = Trezi5.transform.position;

        startPosition[5] = TreziParent.transform.position;


        //TreziPosX[0] = new Vector3(-0.0505f, 0.0218f, -0.002f);
        //TreziPosX[1] = new Vector3(0.71f, 0.671f, 0f);
        //TreziPosX[2] = new Vector3(0.71f, 1.344f, 0f);
        //TreziPosX[3] = new Vector3(0.71f, 2.066f, 0f);
        //TreziPosX[4] = new Vector3(0.71f, 2.77f, 0f);
        //TreziPosX[5] = new Vector3(0.71f, -0.72f, 0f);
        
    }

    public void enableitem(int m_IndexNumber, char movement)
    {
        int i;
        if (m_IndexNumber == 0)
        {
            Trezi1bg.color = Color.white;
            Trezi2bg.color = defColor;
            Trezi3bg.color = defColor;
            Trezi4bg.color = defColor;
            imgTrezi1.color = Color.black;
            textTrezi1.color = Color.black;
            imgTrezi2.color = Color.white;
            textTrezi2.color = Color.white;
            imgTrezi3.color = Color.white;
            textTrezi3.color = Color.white;
            imgTrezi4.color = Color.white;
            textTrezi4.color = Color.white;

            //imgTrezi5.color = Color.white;
            //textTrezi5.color = Color.white;

            if ((m_IndexNumber == 0) && (movement == 'R'))
            {
                ResetTransformR();
                //a.transform.position = startPosition[0];
                //b.transform.position = startPosition[0];
                //c.transform.position = startPosition[0];
                //d.transform.position = startPosition[0];
                //e.transform.position = startPosition[0];
                //Trezi1.transform.Translate(startPosition[0]);
                //Trezi2.transform.Translate(startPosition[1]);
                //Trezi3.transform.Translate(startPosition[2]);
                //Trezi4.transform.Translate(startPosition[3]);
                //Trezi5.transform.Translate(startPosition[4]);
                //Trezi1.transform.parent.transform.Translate(Vector3.left * 0.035f);
                //a.transform.position = TreziPosX[0];
                //b.transform.position = TreziPosX[0];
                //c.transform.position = TreziPosX[1];
                //d.transform.position = TreziPosX[2];
                //e.transform.position = TreziPosX[3];
            }
            if ((m_IndexNumber == 0) && (movement == 'L'))
            {
                ResetTransformL();
            }

        }
        if (m_IndexNumber == 1)
        {
            Trezi1bg.color = defColor;
            Trezi2bg.color = Color.white;
            Trezi3bg.color = defColor;
            Trezi4bg.color = defColor;
            imgTrezi1.color = Color.white;
            textTrezi1.color = Color.white;
            imgTrezi2.color = Color.black;
            textTrezi2.color = Color.black;
            imgTrezi3.color = Color.white;
            textTrezi3.color = Color.white;
            imgTrezi4.color = Color.white;
            textTrezi4.color = Color.white;

            //imgTrezi5.color = Color.white;
            //textTrezi5.color = Color.white;
            if ((m_IndexNumber == 1) && (movement == 'R'))
            {
                Trezi1.transform.Translate(Vector3.left * 0.05f);
                Trezi2.transform.Translate(Vector3.left * 0.05f);
                Trezi3.transform.Translate(Vector3.left * 0.05f);
                Trezi4.transform.Translate(Vector3.left * 0.05f);

                //Trezi5.transform.Translate(Vector3.left * 0.05f);
                //Trezi1.transform.parent.transform.Translate(Vector3.left * 0.035f);
            }
            if ((m_IndexNumber == 1) && (movement == 'L'))
            {
                Trezi1.transform.Translate(Vector3.right * 0.05f);
                Trezi2.transform.Translate(Vector3.right * 0.05f);
                Trezi3.transform.Translate(Vector3.right * 0.05f);
                Trezi4.transform.Translate(Vector3.right * 0.05f);

                //Trezi5.transform.Translate(Vector3.right * 0.05f);
                //Trezi1.transform.parent.transform.Translate(Vector3.left * 0.035f);
            }
        }
        if(m_IndexNumber == 2)
        {
            Trezi1bg.color = defColor;
            Trezi2bg.color = defColor;
            Trezi3bg.color = Color.white;
            Trezi4bg.color = defColor;
            imgTrezi1.color = Color.white;
            textTrezi1.color = Color.white;
            imgTrezi2.color = Color.white;
            textTrezi2.color = Color.white;
            imgTrezi3.color = Color.black;
            textTrezi3.color = Color.black;
            imgTrezi4.color = Color.white;
            textTrezi4.color = Color.white;

            //imgTrezi5.color = Color.white;
            //textTrezi5.color = Color.white;
            if ((m_IndexNumber == 2) && (movement == 'R'))
            {
                Trezi1.transform.Translate(Vector3.left * 0.05f);
                Trezi2.transform.Translate(Vector3.left * 0.05f);
                Trezi3.transform.Translate(Vector3.left * 0.05f);
                Trezi4.transform.Translate(Vector3.left * 0.05f);

                //Trezi5.transform.Translate(Vector3.left * 0.05f);
                //Trezi1.transform.parent.transform.Translate(Vector3.left * 0.035f);
            }
            if ((m_IndexNumber == 2) && (movement == 'L'))
            {
                Trezi1.transform.Translate(Vector3.right * 0.05f);
                Trezi2.transform.Translate(Vector3.right * 0.05f);
                Trezi3.transform.Translate(Vector3.right * 0.05f);
                Trezi4.transform.Translate(Vector3.right * 0.05f);

                //Trezi5.transform.Translate(Vector3.right * 0.05f);
                //Trezi1.transform.parent.transform.Translate(Vector3.left * 0.035f);
            }
        }
        if (m_IndexNumber == 3)
        {
            Trezi1bg.color = defColor;
            Trezi2bg.color = defColor;
            Trezi3bg.color = defColor;
            Trezi4bg.color = Color.white;
            imgTrezi1.color = Color.white;
            textTrezi1.color = Color.white;
            imgTrezi2.color = Color.white;
            textTrezi2.color = Color.white;
            imgTrezi3.color = Color.white;
            textTrezi3.color = Color.white;
            imgTrezi4.color = Color.black;
            textTrezi4.color = Color.black;

            //imgTrezi5.color = Color.white;
            //textTrezi5.color = Color.white;
            if ((m_IndexNumber == 3) && (movement == 'R'))
            {
                Trezi1.transform.Translate(Vector3.left * 0.05f);
                Trezi2.transform.Translate(Vector3.left * 0.05f);
                Trezi3.transform.Translate(Vector3.left * 0.05f);
                Trezi4.transform.Translate(Vector3.left * 0.05f);

                //Trezi5.transform.Translate(Vector3.left * 0.05f);
                //Trezi1.transform.parent.transform.Translate(Vector3.left * 0.035f);
            }
            if ((m_IndexNumber == 3) && (movement == 'L'))
            {
                Trezi1.transform.Translate(Vector3.left * 0.05f * 3);
                Trezi2.transform.Translate(Vector3.left * 0.05f * 3);
                Trezi3.transform.Translate(Vector3.left * 0.05f * 3);
                Trezi4.transform.Translate(Vector3.left * 0.05f * 3);

                //Trezi5.transform.Translate(Vector3.left * 0.05f * 3);

                //Trezi1.transform.parent.transform.Translate(Vector3.left * 0.035f);
            }
        }
        /*
        if (m_IndexNumber == 4)
        {
            imgTrezi1.color = Color.black;
            textTrezi1.color = Color.black;
            imgTrezi2.color = Color.black;
            textTrezi2.color = Color.black;
            imgTrezi3.color = Color.black;
            textTrezi3.color = Color.black;
            imgTrezi4.color = Color.black;
            textTrezi4.color = Color.black;
            imgTrezi5.color = Color.red;
            textTrezi5.color = Color.red;
            if ((m_IndexNumber == 4) && (movement == 'R'))
            {
                Trezi1.transform.Translate(Vector3.left * 0.05f);
                Trezi2.transform.Translate(Vector3.left * 0.05f);
                Trezi3.transform.Translate(Vector3.left * 0.05f);
                Trezi4.transform.Translate(Vector3.left * 0.05f);
                Trezi5.transform.Translate(Vector3.left * 0.05f);
                //Trezi1.transform.parent.transform.Translate(Vector3.left * 0.035f);
            }
            if ((m_IndexNumber == 4) && (movement == 'L'))
            {
                Trezi1.transform.Translate(Vector3.left * 0.05f * 4);
                Trezi2.transform.Translate(Vector3.left * 0.05f * 4);
                Trezi3.transform.Translate(Vector3.left * 0.05f * 4);
                Trezi4.transform.Translate(Vector3.left * 0.05f * 4);
                Trezi5.transform.Translate(Vector3.left * 0.05f * 4);
                //Trezi1.transform.parent.transform.Translate(Vector3.left * 0.035f);
            }
        }
        */
    }

    public void ResetTransformR()
    {
        TreziParent.transform.Translate(Vector3.right * 0.05f * 3);
    }
    public void ResetTransformL()
    {
        TreziParent.transform.Translate(Vector3.right * 0.05f);
    }
    private void Update()
    {
        
    }
}
