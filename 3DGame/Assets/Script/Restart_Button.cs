using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class Restart_Button : MonoBehaviour
{
    public GameObject Obj;
    public Animator animator;
    public CanvasGroup canvasGroup;
    public GameObject Play_Obj;
    public static bool restart_success = false;

    public bool isJumpedPressed = false;
    /// <summary>
    /// The position (X and Y distance) finger moved in previous frame
    /// </summary>
    public Vector2 fingerDeltaPosition;
    public Button restart;
    public static bool restart_hide_show = false; //False for hiding
    public static bool application_reboots = false;
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
        canvasGroup = GetComponent<CanvasGroup>(); 
        Play_Obj = GameObject.FindGameObjectWithTag("Play");
        //GetComponent<Image>().enabled=false;
        //GetComponent<Image>().interactable=false;
        //Obj = GameObject.Find("Cube");
        //Debug.Log(Obj.name);
        //restart.interactable = false;
        //canvasGroup.alpha = 1f; 
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMotion.restart_on == true || PlayerMotion.final_stage_on == true){
            Show();
            
            Time.timeScale = 0;
            
        }
        else{
            Hide();
        }

        foreach (Touch _touch in TouchScreenInputWrapper.touches)
        {
            if (_touch.phase == TouchPhase.Began)
            {
                if (IsInRect(JumpButton.rectTransform, _touch.position))
                {
                    //Jump button pressed
                    Debug.Log("Restart button pressed");
                    isJumpedPressed = true;
                    JumpButtonFingerID = _touch.fingerId;
                    

                    Time.timeScale = 1;

                    //Application.Quit();
                    if(PlayerMotion.platform1_on ==true && restart_hide_show==true){
                        application_reboots = true;
                        Application.LoadLevel(0);
                        Play_Obj.GetComponent<CanvasGroup>().alpha = 1f;
                    }
                    else if(PlayerMotion.platform2_on ==true && restart_hide_show==true){
                        application_reboots = true;
                        Application.LoadLevel(1);
                        Play_Obj.GetComponent<CanvasGroup>().alpha = 1f;
                    }
                    else if(PlayerMotion.platform3_on ==true && restart_hide_show==true){
                        application_reboots = true;
                        Application.LoadLevel(2);
                        Play_Obj.GetComponent<CanvasGroup>().alpha = 1f;
                    }
                    else if(PlayerMotion.platform4_on ==true && restart_hide_show==true){
                        application_reboots = true;
                        Application.LoadLevel(3);
                        Play_Obj.GetComponent<CanvasGroup>().alpha = 1f;
                    }
                    else if(restart_hide_show==true){
                        application_reboots = true;
                        Application.LoadLevel(0);
                        Play_Obj.GetComponent<CanvasGroup>().alpha = 1f;
                    }
                    else{
                        application_reboots = false;
                    }
                    
                    Hide();
                    PlayerMotion.restart_on = false;
                    
                    //restart_success = true;
                }
            }
            else if (_touch.phase == TouchPhase.Ended || _touch.phase == TouchPhase.Canceled)
            {
                if (_touch.fingerId == JumpButtonFingerID)
                {
                    //Jump button released
                    Debug.Log("Restart button released");
                    JumpButtonFingerID = -1;
                    isJumpedPressed = false;
                    Hide();
                    Time.timeScale = 1;
                }
            }

            fingerDeltaPosition = _touch.deltaPosition;
        }

    }

    void LateUpdate(){
        //restart_success = false;
        if(application_reboots == true){
            application_reboots = false;
            PlayerMotion.final_stage_on = false;
        }
    }

    void Hide() {
        canvasGroup = GetComponent<CanvasGroup>(); 
        canvasGroup.alpha = 0f; //this makes everything transparent
        canvasGroup.blocksRaycasts = false; //this prevents the UI element to receive input events
        restart_hide_show = false;
        //gameObject.SetActive(false);
        //this.GetComponent<Button>().interactable = false;
    }
     void Show() {
         canvasGroup = GetComponent<CanvasGroup>(); 
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        restart_hide_show = true;
        //gameObject.SetActive(true);
        //this.GetComponent<Button>().interactable = true;
     }
}