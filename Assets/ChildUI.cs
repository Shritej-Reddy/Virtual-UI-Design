using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildUI : MonoBehaviour {

    public GameObject[] AllChildUIs;
    public GameObject[] icon;
    public GameObject[] text;
    public GameObject[] activationObject;
    public GameObject[] Trezino;
    public GameObject[] TrezinoP;
    int i;
	// Use this for initialization
	void Start () {
        i = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void activateObjectOne(int a)
    {
        if(a != 5)
            activationObject[a].SetActive(true);
    }
    public void activateObjectTwo(int a)
    {
        if (a != 4)
            activationObject[a].SetActive(true);
    }
    public void activateObjectThree(int a)
    {
        if (a != 5)
            activationObject[a].SetActive(true);
    }

    public void activateObjectX(int a)
    {
        if (a <= 2)
            activationObject[a].SetActive(true);
    }

    public void deactivateObjectOne(int a)
    {
        if((i >= 0) && (i <= 5))
        {
            for (i = 0; i < 5; i++)
            {
                if (i != a)
                    activationObject[i].SetActive(false);
            }
        }

        else if(i == 5)
        {
            for(i = 0; i < 2; i++)
            {
                if (i != a)
                    activationObject[i].SetActive(false);
            }
        }

    }
    public void deactivateObjectTwo(int a)
    {
        if ((i >= 0) && (i <= 4))
        {
            for (i = 0; i < 4; i++)
            {
                if (i != a)
                    activationObject[i].SetActive(false);
            }
        }

        else if (i == 4)
        {
            for (i = 0; i < 2; i++)
            {
                if (i != a)
                    activationObject[i].SetActive(false);
            }
        }

    }
    public void deactivateObjectThree(int a)
    {
        if ((i >= 0) && (i <= 5))
        {
            for (i = 0; i < 5; i++)
            {
                if (i != a)
                    activationObject[i].SetActive(false);
            }
        }

        else if (i == 5)
        {
            for (i = 0; i < 2; i++)
            {
                if (i != a)
                    activationObject[i].SetActive(false);
            }
        }
    }

    public void deactivateObjectX(int a)
    {
        if ((i >= 0) && (i <= 3))
        {
            for (i = 0; i < 3; i++)
            {
                if (i != a)
                    activationObject[i].SetActive(false);
            }
        }

        else if (i == 5)
        {
            for (i = 0; i < 2; i++)
            {
                if (i != a)
                    activationObject[i].SetActive(false);
            }
        }

    }
    public void setTreziOn(int a)
    {
        /*for(i = 0; i < TrezinoP.Length; i++)
        {
            //TrezinoP[i].SetActive(true);
        }
        for(i = 0; i < TrezinoP.Length; i++)
        {
            if(i != a)
            {
                
                
            }
        }
        for (i = 0; i < Trezino.Length; i++)
        {
            Trezino[i].SetActive(true);
        }
        */
    }
}
