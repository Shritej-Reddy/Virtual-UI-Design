using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Properties : MonoBehaviour {


    [SerializeField]
    Image icon;

    [SerializeField]
    GameObject activationObject;
    [SerializeField]
    Text text;

	// Use this for initialization
	void Start () {
		
	}
	
	

    public void OnObjectSelected()
    {
        //activationObject.SetActive(true);
        icon.color = Color.green;
        text.color = Color.green;
        //TODO
    }

    public void OnObjectDeSelected()
    {
        activationObject.SetActive(false);
        icon.color = Color.white;
        text.color = Color.white;
    }

    //public void Res
}
