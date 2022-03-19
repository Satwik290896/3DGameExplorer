using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class TouchScreenControlExample : MonoBehaviour
{
    public GameObject Obj;
    public Camera cam;
    public GameObject cam_Obj;
    public Animator animator;
     private CharacterController characterController;

    public bool isJumpedPressed = false;
    public static bool cha_jump_on = false;
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
        Obj = GameObject.FindGameObjectWithTag("Player");
        animator = Obj.GetComponent<Animator>();
        characterController = Obj.GetComponent<CharacterController>();

        cam_Obj = GameObject.FindGameObjectWithTag("MainCamera");
        if(cam_Obj.active == true){
            cam = cam_Obj.GetComponent<Camera>();
        }
        
        //characterController = Obj.GetComponent<CharacterController>();
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
                    Debug.Log("Jump button pressed");
                    isJumpedPressed = true;
                    JumpButtonFingerID = _touch.fingerId;
                    cha_jump_on = true;
                    if(cam_Obj.active == true){
                                Ray ray = cam.ScreenPointToRay(transform.position);
                                Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
                    }
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
                    cha_jump_on = true;
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
                   
                    cha_jump_on = false;
                    GetComponent<Image>().color = Color.white;
                }
            }

            fingerDeltaPosition = _touch.deltaPosition;
        }

    }

    void LateUpdate(){
        if(cha_jump_on){
            
            Vector3 movementDirection = new Vector3(0, 1, 0);
            characterController.Move(movementDirection * 1300 * Time.deltaTime);
            animator.SetBool("IsJump",true);
        }
        else{
            
            Vector3 movementDirection = new Vector3(0, -1, 0);
            characterController.Move(movementDirection * 500 * Time.deltaTime);
            animator.SetBool("IsJump",false);
        }
        
    }
}