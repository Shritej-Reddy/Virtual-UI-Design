using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertiesManager : MonoBehaviour
{
    public Properties[] properties;
    public Properties currentProperty;

    void Awake()
    {
        properties = transform.GetComponentsInChildren<Properties>();
        currentProperty = properties[0];
        currentProperty.OnObjectSelected();
    }


    public void OnSelected()
    {
        gameObject.SetActive(true);
        currentProperty.OnObjectDeSelected();
        currentProperty = properties[0];
        currentProperty.OnObjectSelected();
    }


}
