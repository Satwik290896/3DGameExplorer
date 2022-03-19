using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class Projectile_Launch : MonoBehaviour
{
    public GameObject Obj;
    public Animator animator;
    public AnimatorStateInfo animStateInfo;
    private CharacterController characterController;
    public CanvasGroup canvasGroup;

    public float speed = 3000f;
    public static bool pro_launch_on = false;
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
        Obj = GameObject.FindGameObjectWithTag("Player");
        animator = Obj.GetComponent<Animator>();
        characterController = Obj.GetComponent<CharacterController>();
        animStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        Debug.Log(animStateInfo.nameHash);
        canvasGroup = GetComponent<CanvasGroup>(); 
        canvasGroup.alpha = 0f; //this makes everything transparent
        canvasGroup.blocksRaycasts = false; //this prevents the UI element to receive input events
        //Obj = GameObject.Find("Cube");
        //Debug.Log(Obj.name);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMotion.hope_on == true){
                canvasGroup.alpha = 0.7f; //this makes everything transparent
                canvasGroup.blocksRaycasts = true; //this prevents the UI element to receive input events
        }
        else{
                    canvasGroup.alpha = 0f; //this makes everything transparent
        canvasGroup.blocksRaycasts = false; //this prevents the UI element to receive input events
        }

        foreach (Touch _touch in TouchScreenInputWrapper.touches)
        {
            if (_touch.phase == TouchPhase.Began)
            {
                if (IsInRect(JumpButton.rectTransform, _touch.position))
                {
                    //Jump button pressed
                    Debug.Log("Launch button pressed");
                    isJumpedPressed = true;
                    JumpButtonFingerID = _touch.fingerId;
                    if(PlayerMotion.hope_on == true){
                        pro_launch_on = true;
                    }
                    GetComponent<Image>().color = Color.yellow;
                    
                }
            }
            else if (_touch.phase == TouchPhase.Stationary)
            {
                if (IsInRect(JumpButton.rectTransform, _touch.position))
                {
                    //Jump button pressed
                    Debug.Log("Launch button touched continuously");
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
                    Debug.Log("Launch button released");
                    JumpButtonFingerID = -1;
                    isJumpedPressed = false;
                    if(PlayerMotion.hope_on == true){
                        pro_launch_on = false;
                    }
                    GetComponent<Image>().color = Color.white;
                }
            }

            fingerDeltaPosition = _touch.deltaPosition;
        }

    }

    /*void LateUpdate(){
            if(cha_forward_on == true){
                    Vector3 movementDirection = new Vector3(0, 0, 1);
                    characterController.Move(movementDirection * 50 * Time.deltaTime);
                    animStateInfo = animator.GetCurrentAnimatorStateInfo(0);
                    Debug.Log(animStateInfo.nameHash);
            }
    }*/
}