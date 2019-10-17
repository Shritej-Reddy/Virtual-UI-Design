using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

    [SerializeField] private GameObject parent;
    [SerializeField] private GameObject[] canvasGameObjects;
    private GameObject currentSelectedObjectCanvas;
    private Transform[] currentObjectCanvasChildren;
    private Transform[] currentObjectPropertyChildren;
    private int rightSwipeCount;
    private int leftSwipeCount;
    private bool isSwiping = true;
    private int activeObjectIndex;
    private int currentObjectIndex = 1;
    public int index;

    private  ViveSwipeDetector swipeDetector;

    public PropertiesManager[] propertiesManager;

    PropertiesManager currentPropertyManager;

    private void Awake()
    {
        swipeDetector = GetComponentInParent<ViveSwipeDetector>();
    }

    void Start()
    {
        if (currentSelectedObjectCanvas != null)
        {
            currentSelectedObjectCanvas = null;
        }
        canvasGameObjects[currentObjectIndex].SetActive(true);
        currentObjectCanvasChildren = canvasGameObjects[currentObjectIndex].GetComponentsInChildren<Transform>();
        activeObjectIndex = currentObjectIndex;

        SetPropertiesManager();
        
        //currentProperty.OnObjectSelected();
        //transform.GetComponentInChildren<Properties>();
    }

    void SetPropertiesManager()
    {
        propertiesManager = transform.GetComponentsInChildren<PropertiesManager>();
        for (int i = 0; i < propertiesManager.Length; i++)
        {
            propertiesManager[i].gameObject.SetActive(false);
        }
        currentPropertyManager = propertiesManager[index];
        currentPropertyManager.OnSelected();
        //currentPropertyManager.gameObject.SetActive(true);
    }

  



    //public void SwitchObjectsRight()
    //{
    //    canvasGameObjects[currentObjectIndex].SetActive(false);
    //    if (currentObjectIndex == 4)
    //    { currentObjectIndex = -1; }


    //        currentSelectedObjectCanvas = canvasGameObjects[currentObjectIndex + 1];
    //        currentSelectedObjectCanvas.SetActive(true);
    //        currentObjectIndex++;
    //    //}

    //    activeObjectIndex = currentObjectIndex;
    //    currentObjectCanvasChildren = canvasGameObjects[activeObjectIndex].GetComponentsInChildren<Transform>();
    //}

    public void SwitchObjectsRight()
    {

        currentPropertyManager.gameObject.SetActive(false);
        currentObjectIndex++;
        if (currentObjectIndex >= propertiesManager.Length)
        {
            currentObjectIndex = 0;
        }
        currentPropertyManager = propertiesManager[currentObjectIndex];
        // currentPropertyManager.gameObject.SetActive(true);
        currentPropertyManager.OnSelected();

        index = 0;


    }

    public void SwitchObjectsLeft()
    {

        currentPropertyManager.gameObject.SetActive(false);
        currentObjectIndex--;
        if (currentObjectIndex < 0)
        {
            currentObjectIndex = propertiesManager.Length-1;
        }
        currentPropertyManager = propertiesManager[currentObjectIndex];
        // currentPropertyManager.gameObject.SetActive(true);
        currentPropertyManager.OnSelected();
        index = 0;

    }

    //public void SwitchObjectsLeft()
    //{
    //    canvasGameObjects[currentObjectIndex].SetActive(false);
    //    if (currentObjectIndex == 0)
    //    {
    //        currentObjectIndex = 5;
    //    }
        
    //    currentSelectedObjectCanvas = canvasGameObjects[currentObjectIndex - 1];
    //    currentSelectedObjectCanvas.SetActive(true);

    //    currentObjectIndex--;

    //    activeObjectIndex = currentObjectIndex;
    //    currentObjectCanvasChildren = canvasGameObjects[activeObjectIndex].GetComponentsInChildren<Transform>();
    //}

    public void OnSwipeDown(int index1)
    {
        index++;
        if (index > currentPropertyManager.properties.Length - 1)
        {
            index = 0;
        }

        //if (index != 0)
        //{
     //   Debug.Log("OnSwipeDown " + index);

        currentPropertyManager.currentProperty.OnObjectDeSelected();
        currentPropertyManager.currentProperty = currentPropertyManager.properties[index];
        currentPropertyManager.currentProperty.OnObjectSelected();

        //}   

    }

    public void OnSwipeUp(int index1)
    {
        index--;
        if (index < 0 )
        {
            index = currentPropertyManager.properties.Length - 1;
        }

        //if (index != 0)
        //{
        //   Debug.Log("OnSwipeDown " + index);

        currentPropertyManager.currentProperty.OnObjectDeSelected();
        currentPropertyManager.currentProperty = currentPropertyManager.properties[index];
        currentPropertyManager.currentProperty.OnObjectSelected();

        //}   

    }

    //void ResetColor
}

//foreach (Transform childProperty in currentObjectCanvasChildren)
//        {
//            currentObjectPropertyChildren = childProperty.GetComponentsInChildren<Transform>();

//            foreach (Transform currentObjectProperty in currentObjectPropertyChildren)
//            {
//               if(currentObjectProperty.tag=="Panel")
//                {
//                    Debug.Log(currentObjectProperty.gameObject);
//                    currentObjectProperty.gameObject.SetActive(true);
//                }
//            }

//        }
//    GameObject property = currentObjectProperty.gameObject;
//    GameObject[] panelObjects = GameObject.FindGameObjectsWithTag("Panel");

//    foreach (GameObject panelToShow in panelObjects)
//    {
//        panelToShow.SetActive(true);
//    }
