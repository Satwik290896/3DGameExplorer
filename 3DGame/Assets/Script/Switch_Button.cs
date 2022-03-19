using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class Switch_Button : MonoBehaviour
{
    public GameObject Obj1_cam;
    public GameObject Obj2_cam;
    public static bool switch_cam_on = false;

    public bool isJumpedPressed = false;
    /// <summary>
    /// The position (X and Y distance) finger moved in previous frame
    /// </summary>
    public Vector2 fingerDeltaPosition;

    public Image JumpButton;
    public int JumpButtonFingerID = -1;
    private bool IsInRect(RectTransform rect, Vector2 screenPoint)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(rect, screenPoint);
    }

    void Start()
    {
                        Obj1_cam.SetActive(true);
                        Obj2_cam.SetActive(false);
        //Obj = GameObject.Find("Cube");
        //Debug.Log(Obj.name);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Touch _touch in TouchScreenInputWrapper.touches)
        {
            if (_touch.phase == TouchPhase.Began)
            {
                if (IsInRect(JumpButton.rectTransform, _touch.position))
                {
                    //Jump button pressed
                    Debug.Log("Switch button pressed");
                    isJumpedPressed = true;
                    JumpButtonFingerID = _touch.fingerId;
                    if(switch_cam_on == false){
                        Obj2_cam.SetActive(true);
                        Obj1_cam.SetActive(false);

                        switch_cam_on = true;

                    }
                    else{
                        Obj1_cam.SetActive(true);
                        Obj2_cam.SetActive(false);
                        switch_cam_on = false;
                    }
                    GetComponent<Image>().color = Color.yellow;
                    
                }
            }
            else if (_touch.phase == TouchPhase.Stationary)
            {
                if (IsInRect(JumpButton.rectTransform, _touch.position))
                {
                    //Jump button pressed
                    Debug.Log("Switch button touched continuously");
                    isJumpedPressed = true;
                    JumpButtonFingerID = _touch.fingerId;
                    GetComponent<Image>().color = Color.yellow;
                }
            }
            
            else if (_touch.phase == TouchPhase.Ended || _touch.phase == TouchPhase.Canceled)
            {
                if (_touch.fingerId == JumpButtonFingerID)
                {
                    //Jump button released
                    Debug.Log("Switch button released");
                    JumpButtonFingerID = -1;
                    isJumpedPressed = false;
                    GetComponent<Image>().color = Color.white;
                }
            }

            fingerDeltaPosition = _touch.deltaPosition;
        }

    }

}