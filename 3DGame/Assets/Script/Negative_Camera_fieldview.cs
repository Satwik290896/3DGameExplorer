using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class Negative_Camera_fieldview : MonoBehaviour
{
    public GameObject Obj;
    public Animator animator;
    public AnimatorStateInfo animStateInfo;
    private CharacterController characterController;

    public float speed = 3000f;
    public bool isJumpedPressed = false;
    /// <summary>
    /// The position (X and Y distance) finger moved in previous frame
    /// </summary>
    public Vector2 fingerDeltaPosition;

    public Image JumpButton;
    public int JumpButtonFingerID = -1;

        public GameObject Obj1_cam;
    public GameObject Obj2_cam;
    public GameObject cam;
    public Camera cam_camera;

    private bool IsInRect(RectTransform rect, Vector2 screenPoint)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(rect, screenPoint);
    }

    void Start()
    {
        Obj = GameObject.FindGameObjectWithTag("Player");
        animator = Obj.GetComponent<Animator>();
        characterController = Obj.GetComponent<CharacterController>();
        animStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        Debug.Log(animStateInfo.nameHash);
        //Obj = GameObject.Find("Cube");
        //Debug.Log(Obj.name);
    }

    // Update is called once per frame
    void Update()
    {
                if(Obj1_cam.activeSelf == true)
        {
            cam = Obj1_cam;
        }
        else if(Obj2_cam.activeSelf == true){
            cam = Obj2_cam;
        }
        cam_camera = cam.GetComponent<Camera>();

        foreach (Touch _touch in TouchScreenInputWrapper.touches)
        {
            if (_touch.phase == TouchPhase.Began)
            {
                if (IsInRect(JumpButton.rectTransform, _touch.position))
                {
                    //Jump button pressed
                    Debug.Log("Jump button pressed");
                    isJumpedPressed = true;
                    JumpButtonFingerID = _touch.fingerId;
                    cam_camera.fieldOfView = cam_camera.fieldOfView + (30f)*Time.deltaTime;
                    GetComponent<Image>().color = Color.yellow;
                    
                }
            }
            else if (_touch.phase == TouchPhase.Stationary)
            {
                if (IsInRect(JumpButton.rectTransform, _touch.position))
                {
                    //Jump button pressed
                    Debug.Log("Jump button touched continuously");
                    isJumpedPressed = true;
                    JumpButtonFingerID = _touch.fingerId;
                    cam_camera.fieldOfView = cam_camera.fieldOfView + (30f)*Time.deltaTime;
                    GetComponent<Image>().color = Color.yellow;
                    
                }
            }
            
            else if (_touch.phase == TouchPhase.Ended || _touch.phase == TouchPhase.Canceled)
            {
                if (_touch.fingerId == JumpButtonFingerID)
                {
                    //Jump button released
                    Debug.Log("Jump button released");
                    JumpButtonFingerID = -1;
                    isJumpedPressed = false;
                    
                    GetComponent<Image>().color = Color.white;
                }
            }

            fingerDeltaPosition = _touch.deltaPosition;
        }

    }
}
