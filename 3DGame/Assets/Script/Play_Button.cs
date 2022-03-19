using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class Play_Button : MonoBehaviour
{
    public GameObject Obj;
    public Animator animator;

    public bool isJumpedPressed = false;
    /// <summary>
    /// The position (X and Y distance) finger moved in previous frame
    /// </summary>
    public Vector2 fingerDeltaPosition;

    public Image JumpButton;
    public int JumpButtonFingerID = -1;

    public CanvasGroup canvasGroup;

    private bool IsInRect(RectTransform rect, Vector2 screenPoint)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(rect, screenPoint);
    }

    void Start()
    {
        Obj = GameObject.FindGameObjectWithTag("Player");
        animator = Obj.GetComponent<Animator>();
        //Obj = GameObject.Find("Cube");
        //Debug.Log(Obj.name);
        canvasGroup = GetComponent<CanvasGroup>(); 
        canvasGroup.alpha = 1f;
        Debug.Log("Starttttttttt Playyyyyyyyy");
        /*if(Restart_Button.application_reboots == false){
            Time.timeScale = 0;
        }*/
        
        //canvasGroup.blocksRaycasts = false;
        //Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Restart_Button.application_reboots == true){
            canvasGroup.alpha = 1f;
            Time.timeScale = 0;
        }*/
        foreach (Touch _touch in TouchScreenInputWrapper.touches)
        {
            if (_touch.phase == TouchPhase.Began)
            {
                if (IsInRect(JumpButton.rectTransform, _touch.position))
                {
                    //Jump button pressed
                    Debug.Log("Play button pressed");
                    isJumpedPressed = true;
                    JumpButtonFingerID = _touch.fingerId;
                    canvasGroup.alpha = 0f;
                    Time.timeScale = 1;
                    //canvasGroup.blocksRaycasts = true;
                    //Application.Quit();
                    //Application.LoadLevel(0);
                    
                }
            }
            else if (_touch.phase == TouchPhase.Ended || _touch.phase == TouchPhase.Canceled)
            {
                if (_touch.fingerId == JumpButtonFingerID)
                {
                    //Jump button released
                    Debug.Log("Play button released");
                    JumpButtonFingerID = -1;
                    isJumpedPressed = false;
                    Time.timeScale = 1;
                }
            }

            fingerDeltaPosition = _touch.deltaPosition;
        }

    }
}