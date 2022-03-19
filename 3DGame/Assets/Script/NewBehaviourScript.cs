using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    /*public float Speed=400f;
    public GameObject Obj;
    private CharacterController characterController;
    private bool check = false;
    private float time_0 = 0;*/
    public static float score_prev_level = 0;
    public GameObject cam1;
    public GameObject cam2;
    // Start is called before the first frame update
    void Start()
    {
        //Obj = GameObject.FindGameObjectWithTag("Hope");
        //characterController = Obj.GetComponent<CharacterController>();
        //Obj = GameObject.Find("Cube");
        //Debug.Log(Obj.name);
    }

    // Update is called once per frame
    void Update()
    {
        score_prev_level = Score_5000.score;
        /*float ySpeed = Physics.gravity.y;
        if(PlayerMotion.hope_on){
            if(check == false){
                time_0 = Time.time;
                check = true;
            }
            Vector3 dist = new Vector3(0,Speed*Time.deltaTime+ySpeed*((Time.time - time_0)/200),Speed* Time.deltaTime)*10;
            characterController.Move(dist);
        }*/
        
        //Obj.transform.Translate(dist);
        
        //print("Test");
    }
}
