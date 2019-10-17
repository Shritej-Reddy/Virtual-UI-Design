using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System;
using UnityEngine.UI;
public class ViveSwipeDetector : NetworkBehaviour
{
    [SerializeField]
    SteamVR_TrackedObject trackedObj;
	[SerializeField]
	SteamVR_TrackedObject trackedObj1;
    private const int mMessageWidth = 200;
    private const int mMessageHeight = 64;

    public GameObject[] AllUIObjects;
    public GameObject[] AllTreziCanvas;
    public GameObject[] Trezinos;
    public GameObject TreziCanvas;
    public GameObject ObjectCanvas;
    public GameObject ViewCanvas;
    public GameObject ShareReview;
    public GameObject Settings;
    public GameObject a;
    public GameObject b;
    public GameObject c;
    public GameObject d;
    GameObject z;
    char movement;

    public float rightXMin = 0.3f;
    public float rightXMax = 1.0f;
    public float rightYMin = 0.4f;
    public float rightYMax = 1.0f;

    public float UpXMin = -0.6f;
    public float UpXMax = 0.6f;
    public float UpYMin = 0.8f;
    public float UpYMax = 1.0f;

    public bool m_activate = false;
    int m_IndexNumber;
    int m_IndexNumberSub;
    int x;
	int layerMask;

	RaycastHit hit;

    //Contains all Device4 joystick Analog Values.
    Vector2 axisVal;

    private readonly Vector2 mXAxis = new Vector2(1, 0);
    private readonly Vector2 mYAxis = new Vector2(0, 1);
    private bool trackingSwipe = false;
    public bool checkSwipe = false;
    public bool isLeftSwipe = false;
    public bool isRightSwipe = false;
    public bool isDownSwipe = false;
    public bool isUpSwipe = false;



    private readonly string[] mMessage = {
        "",
        "Swipe Left",
        "Swipe Right",
        "Swipe Top",
        "Swipe Bottom"
    };

    private int mMessageIndex = 0;

    // The angle range for detecting swipe
    private const float mAngleRange = 30;

    // To recognize as swipe user should at lease swipe for this many pixels
    private const float mMinSwipeDist = 0.2f;

    // To recognize as a swipe the velocity of the swipe
    // should be at least mMinVelocity
    // Reduce or increase to control the swipe speed
    private const float mMinVelocity = 4.0f;

    private Vector2 mStartPosition;
    private Vector2 endPosition;
    private UiManager uiManager;
    private float mSwipeStartTime;
    private int index;
    private bool Changed = false;

    void Awake()
    {
        uiManager = GetComponentInChildren<UiManager>();
    }
    // Use this for initialization
    void Start()
    {
        m_IndexNumber = 0;
        m_IndexNumberSub = 0;
        x = 0;
        movement = ' ';
        z = GameObject.Find("Trezi");
        PanelOptionsLoad();
        AllUIObjects[0].transform.SetSiblingIndex(m_IndexNumber);
        Debug.Log("Sibling Index : " + AllUIObjects[0].transform.GetSiblingIndex());
        AllUIObjects[m_IndexNumber].SetActive(false);
		layerMask = 1 << 5;
    }

    // Update is called once per frame
    void Update()
    {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);
        Vector2 axisVal = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0);

		//SteamVR_Controller.Device device1 = SteamVR_Controller.Input((int)trackedObj1.index);
		//Vector2 axisVal1 = device1.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0);

		//if(axisVal1 != Vector2.zero)
		//{
		//	Debug.Log("Axis  " + trackedObj1.index + ", Value : "+ axisVal1);
		//	Debug.Log("Right Controller In Motion");
		//}
        if (axisVal != Vector2.zero)
        {
            Debug.Log("Axis  " + trackedObj.index + ", Value : "+ axisVal);
        }
        else
        {
            Changed = false;
        }
        WaitForNextInput();

        //Right Movement in Device4 Joystick
        if (!Changed && (axisVal.x > rightXMin) && (axisVal.x < rightXMax))
        {
            if ((axisVal.y > rightYMin) && (axisVal.y < rightYMax))
            {
                moveUIRight();
            }

            if ((axisVal.y < -0.4f) && (axisVal.y > -1.0f))
            {
                moveUIRight();
            }
        }
        

        //Left Movement in Device4 Joystick
        if (!Changed && (axisVal.x < -rightXMin) && (axisVal.x > -rightXMax))
        {
            if ((axisVal.y < -rightYMin) && (axisVal.y > -rightYMax))
            {
                moveUILeft();
            }
            if ((axisVal.x < -rightYMin) && (axisVal.x > -rightYMax))
            {
                moveUILeft();
            }
        }
        

        //Downward Movement in Device4 Joystick
        if (!Changed && (axisVal.y < -0.4f) && (axisVal.y > -1.0f))
        {
            if ((axisVal.x < -0.3f) && (axisVal.x > -1.0f))
            {
                moveUIDown();
            }
            if ((axisVal.x > 0.3f) && (axisVal.x < 1.0f))
            {
                moveUIDown();
            }
            if ((axisVal.x < 0.6f) && (axisVal.x > -0.6f))
            {
                moveUIDown();
            }

        }
        

        //Upward Movement in Device4 Joystick
        if (!Changed && (axisVal.y > 0.4f) && (axisVal.y < 1.0f))
        {
            if ((axisVal.x < -0.3f) && (axisVal.x > -1.0f))
            {
                moveUIUp();
            }
            if ((axisVal.x > 0.3f) && (axisVal.x < 1.0f))
            {
                moveUIUp();
            }
            if ((axisVal.x > -0.6f) && (axisVal.x < 0.6f))
            {
                moveUIUp();
            }
        }

        




        if (GUI.changed)
        {
            transform.SetSiblingIndex(m_IndexNumber);
            Debug.Log("Sibling Index : " + transform.GetSiblingIndex());
        }

        deadZone(device);


        // Touch down, possible chance for a swipe
        if ((int)trackedObj.index != -1 && device.GetTouchDown(Valve.VR.EVRButtonId.k_EButton_Axis0))
        {
            trackingSwipe = true;
            // Record start time and position
            mStartPosition = new Vector2(device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).x,
                device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).y);
            mSwipeStartTime = Time.time;
        }
        // Touch up , possible chance for a swipe
        else if (device.GetTouchUp(Valve.VR.EVRButtonId.k_EButton_Axis0))
        {
            trackingSwipe = false;
            trackingSwipe = true;
            checkSwipe = true;
            Debug.Log("Tracking Finish");
        }
        else if (trackingSwipe)
        {
            endPosition = new Vector2(device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).x,
                                      device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).y);

        }

        if (checkSwipe)
        {
            checkSwipe = false;

            float deltaTime = Time.time - mSwipeStartTime;




            Vector2 swipeVector = endPosition - mStartPosition;

            float velocity = swipeVector.magnitude / deltaTime;
            //   Debug.Log(velocity);
            if (velocity > mMinVelocity &&
                swipeVector.magnitude > mMinSwipeDist)
            {
                // if the swipe has enough velocity and enough distance


                swipeVector.Normalize();

                float angleOfSwipe = Vector2.Dot(swipeVector, mXAxis);
                angleOfSwipe = Mathf.Acos(angleOfSwipe) * Mathf.Rad2Deg;

                // Detect left and right swipe
                if (angleOfSwipe < mAngleRange)
                {
                    //OnSwipeRight();
                }
                else if ((180.0f - angleOfSwipe) < mAngleRange)
                {
                    OnSwipeLeft();
                }
                else
                {
                    // Detect top and bottom swipe
                    angleOfSwipe = Vector2.Dot(swipeVector, mYAxis);
                    angleOfSwipe = Mathf.Acos(angleOfSwipe) * Mathf.Rad2Deg;
                    if (angleOfSwipe < mAngleRange)
                    {
                        OnSwipeTop();
                    }
                    else if ((180.0f - angleOfSwipe) < mAngleRange)
                    {
                        OnSwipeBottom();
                    }
                    else
                    {
                        mMessageIndex = 0;
                    }
                }
            }
        }

    }

    void OnGUI()
    {
        // Display the appropriate message
        GUI.Label(new Rect((Screen.width - mMessageWidth) / 2,
            (Screen.height - mMessageHeight) / 2,
            mMessageWidth, mMessageHeight),
            mMessage[mMessageIndex]);
    }

    private void OnSwipeLeft()
    {
        isRightSwipe = false;
        isDownSwipe = false;
        isLeftSwipe = true;
        // Debug.Log("Swipe Left");
        mMessageIndex = 1;
        uiManager.SwitchObjectsLeft();
    }

    private void OnSwipeRight()
    {
        isLeftSwipe = false;
        isDownSwipe = false;
        isRightSwipe = true;
        uiManager.SwitchObjectsRight();
        //Debug.Log("Swipe right");
        mMessageIndex = 2;
    }

    private void OnSwipeTop()
    {
        isUpSwipe = true;
        uiManager.OnSwipeUp(index);
        // Debug.Log("Swipe Top");
        mMessageIndex = 3;
    }

    private void OnSwipeBottom()
    {
        // ++index;
        // Debug.Log("Swipe Bottom");
        //Debug.Log(index);

        uiManager.OnSwipeDown(index);
        isRightSwipe = false;
        isLeftSwipe = false;
        isDownSwipe = true;
        mMessageIndex = 4;
    }

    void WaitForNextInput()
    {
        if (axisVal.x == 0 && axisVal.y == 0)
            return;
    }
    void WaitForNewInput(SteamVR_Controller.Device dev)
    {

    }
    void deadZone(SteamVR_Controller.Device device)
    {
        if ((axisVal.x <= 0.3f) && (axisVal.x >= -0.3f) && (axisVal.y <= 0.3f) && (axisVal.y >= -0.3f))
        {
            // Debug.Log("Dead Zone");
            WaitForNewInput(device);
        }
    }
    void moveUIRight()
    {

        m_IndexNumberSub = 0;
        Debug.Log("Moved Right");
        if (m_IndexNumber <= AllUIObjects[m_IndexNumber].transform.GetSiblingIndex())
        {
            AllUIObjects[m_IndexNumber].SetActive(false);
            m_IndexNumber++;
            if (m_IndexNumber > 3)
                m_IndexNumber = 0;
            WaitForNextInput();
            AllUIObjects[m_IndexNumber].SetActive(true);
            Changed = true;
            movement = 'R';
            PanelOptionsLoad();
            movement = ' ';
        }
    }
    void moveUILeft()
    {
        m_IndexNumberSub = 0;
        Debug.Log("Moved Left");
        if (m_IndexNumber >= 0)
        {
            AllUIObjects[m_IndexNumber].SetActive(false);
            m_IndexNumber--;
            if (m_IndexNumber < 0)
                m_IndexNumber = 3;
            Debug.Log("Index is : " + m_IndexNumber);
            WaitForNextInput();
            AllUIObjects[m_IndexNumber].SetActive(true);
            Changed = true;
            movement = 'L';
            PanelOptionsLoad();
            movement = ' ';
        }
    }
    void moveUIDown()
    {
        m_IndexNumberSub = (m_IndexNumberSub + 1) % AllTreziCanvas.Length;
        if (m_IndexNumber == 4)
            if (m_IndexNumberSub == 3)
                m_IndexNumberSub = 0;
        if ((m_IndexNumber == 1) || (m_IndexNumber == 3))
            if (m_IndexNumberSub == 4)
                m_IndexNumberSub = 0;
        if ((m_IndexNumber == 0) || (m_IndexNumber == 2))
            if (m_IndexNumberSub == 5)
                m_IndexNumberSub = 0;
        WaitForNextInput();
        movement = 'D';
        PanelOptionsLoad();
        movement = ' ';
        if (m_IndexNumber != 5)
            if (m_IndexNumberSub < 3)
                AllTreziCanvas[m_IndexNumberSub].SetActive(true);
        Debug.Log("Moved down - " + m_IndexNumberSub);
        Changed = true;
    }
    void moveUIUp()
    {
        m_IndexNumberSub = m_IndexNumberSub - 1;
        if (m_IndexNumberSub < 0)
        {
            m_IndexNumberSub = AllTreziCanvas.Length - 1;
        }
        m_IndexNumberSub = (m_IndexNumberSub) % AllTreziCanvas.Length;
        if (m_IndexNumber == 4)
            if (m_IndexNumberSub == 1)
                m_IndexNumberSub = 3;
        if ((m_IndexNumber == 0) || (m_IndexNumber == 1) || (m_IndexNumber == 3))
            if (m_IndexNumberSub == 4)
                m_IndexNumberSub = 3;
        if((m_IndexNumber == 0) || (m_IndexNumber == 2))
            if (m_IndexNumberSub == 5)
                m_IndexNumberSub = 4;
        WaitForNextInput();
        movement = 'U';
        PanelOptionsLoad();
        movement = ' ';
        if (m_IndexNumber != 4)
            if (m_IndexNumberSub < 3)
                AllTreziCanvas[m_IndexNumberSub].SetActive(true);
        Debug.Log("Moved Up - " + m_IndexNumberSub);
        Changed = true;
    }
    void PanelOptionsLoad()
    {
        Trezi tz;
        tz = z.GetComponent<Trezi>();
        if (m_IndexNumber == 0)
        {
            tz.enableitem(m_IndexNumber, movement);
            ChildUI ch = TreziCanvas.GetComponent<ChildUI>();
            image im = new image();
            im.changeColor(m_IndexNumberSub);
            text01 t01 = new text01();
            //t01.changeColorHead(m_IndexNumber);
            t01.changeColor(m_IndexNumberSub);
            AllTreziCanvas[0] = ch.AllChildUIs[0];
            AllTreziCanvas[1] = ch.AllChildUIs[1];
            AllTreziCanvas[2] = ch.AllChildUIs[2];
            AllTreziCanvas[3] = ch.AllChildUIs[3];
            AllTreziCanvas[4] = ch.AllChildUIs[4];
            ch.deactivateObjectOne(m_IndexNumberSub);
            ch.activateObjectOne(m_IndexNumberSub);
        }
        if (m_IndexNumber == 1)
        {
            tz.enableitem(m_IndexNumber, movement);
            ChildUI ch = ObjectCanvas.GetComponent<ChildUI>();
            image1 im = new image1();
            im.changeColor(m_IndexNumberSub);
            text02 t02 = new text02();
            //t02.changeColorHead(m_IndexNumber);
            t02.changeColor(m_IndexNumberSub);
            AllTreziCanvas[0] = ch.AllChildUIs[0];
            AllTreziCanvas[1] = ch.AllChildUIs[1];
            AllTreziCanvas[2] = ch.AllChildUIs[2];
            AllTreziCanvas[3] = ch.AllChildUIs[3];
            ch.deactivateObjectTwo(m_IndexNumberSub);
            ch.activateObjectTwo(m_IndexNumberSub);
        }
        if (m_IndexNumber == 2)
        {
            tz.enableitem(m_IndexNumber, movement);
            ChildUI ch = ViewCanvas.GetComponent<ChildUI>();
            image2 im = new image2();
            im.changeColor(m_IndexNumberSub);
            text03 t03 = new text03();
            //t03.changeColorHead(m_IndexNumber);
            t03.changeColor(m_IndexNumberSub);
            AllTreziCanvas[0] = ch.AllChildUIs[0];
            AllTreziCanvas[1] = ch.AllChildUIs[1];
            AllTreziCanvas[2] = ch.AllChildUIs[2];
            AllTreziCanvas[3] = ch.AllChildUIs[3];
            AllTreziCanvas[4] = ch.AllChildUIs[4];
            ch.deactivateObjectThree(m_IndexNumberSub);
            ch.activateObjectThree(m_IndexNumberSub);
        }
        if (m_IndexNumber == 3)
        {
            tz.enableitem(m_IndexNumber, movement);
            ChildUI ch = ShareReview.GetComponent<ChildUI>();
            image3 im = new image3();
            im.changeColor(m_IndexNumberSub);
            text04 t04 = new text04();
            //t04.changeColorHead(m_IndexNumber);
            t04.changeColor(m_IndexNumberSub);
            AllTreziCanvas[0] = ch.AllChildUIs[0];
            AllTreziCanvas[1] = ch.AllChildUIs[1];
            AllTreziCanvas[2] = ch.AllChildUIs[2];
            AllTreziCanvas[3] = ch.AllChildUIs[3];
            ch.deactivateObjectTwo(m_IndexNumberSub);
            ch.activateObjectTwo(m_IndexNumberSub);
        }
        /*
        if (m_IndexNumber == 4)
        {
            tz.enableitem(m_IndexNumber, movement);
            ChildUI ch = Settings.GetComponent<ChildUI>();
            //ch.setTreziOn(m_IndexNumber);
            image4 im = new image4();
            im.changeColor(m_IndexNumberSub);
            text05 t05 = new text05();
            //t05.changeColorHead(m_IndexNumber);
            t05.changeColor(m_IndexNumberSub);
            AllTreziCanvas[0] = ch.AllChildUIs[0];
            AllTreziCanvas[1] = ch.AllChildUIs[1];
            AllTreziCanvas[2] = ch.AllChildUIs[2];
            try
            {

                AllTreziCanvas[3] = null;
            }
            catch (NullReferenceException ex)
            {
                if (AllTreziCanvas[3] == null)
                { }
                Debug.Log("Forget it");
            }
            ch.deactivateObjectX(m_IndexNumberSub);
            ch.activateObjectX(m_IndexNumberSub);
        }
        */
    }
}