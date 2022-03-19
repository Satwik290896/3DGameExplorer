using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private bool check = false;
    private CharacterController characterController;
    public float Speed=0.09f;
    private float time_0 = 0;
    private bool oscillate = true;
    private Vector3 dist;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float ySpeed = Physics.gravity.y;
        if(PlayerMotion.hope_on){
            if(check == false){
                time_0 = Time.time;
                check = true;
            }
            if(oscillate == true){
                dist = new Vector3(0,Speed*Time.deltaTime*10+ySpeed*((Time.time - time_0)*3),5*Speed* Time.deltaTime)/10;
                oscillate = false;
            }
            else{
                dist = new Vector3(0,Speed*Time.deltaTime*2+ySpeed*((Time.time - time_0)),15*Speed* Time.deltaTime)/40;
                oscillate = true;
            }
            
            characterController.Move(dist);
        }
        
    }
}
