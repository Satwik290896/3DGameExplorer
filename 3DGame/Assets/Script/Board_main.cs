using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board_main : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>(); 
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(PlayerMotion.final_stage_on){
            Show();
        }
        else{
            Hide();
        }
    }
    
    void Hide() {
        canvasGroup = GetComponent<CanvasGroup>(); 
        canvasGroup.alpha = 0f; //this makes everything transparent
        canvasGroup.blocksRaycasts = false; //this prevents the UI element to receive input events
        //gameObject.SetActive(false);
        //this.GetComponent<Button>().interactable = false;
    }
    void Show() {
         canvasGroup = GetComponent<CanvasGroup>(); 
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        //gameObject.SetActive(true);
        //this.GetComponent<Button>().interactable = true;
     }
}
