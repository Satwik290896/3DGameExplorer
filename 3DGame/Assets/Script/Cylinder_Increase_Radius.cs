using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder_Increase_Radius : MonoBehaviour
{
    public float Scale_Radius_Speed;
    private bool set_200_100;
    // Start is called before the first frame update
    void Start()
    {
        Scale_Radius_Speed = 60f;
        //Debug.Log(transform.localScale);
        set_200_100 = true;
    }

    // Update is called once per frame
    void Update()
    {
        float Scaled = Scale_Radius_Speed*Time.deltaTime;
        
        if(transform.localScale.x < 101f){
            set_200_100 = true;
        }
        if(transform.localScale.x > 220f){
            set_200_100 = false;
        }

        if(set_200_100 == true){
            transform.localScale += new Vector3(Scaled, 0, Scaled);
        }
        else{
            transform.localScale -= new Vector3(Scaled, 0, Scaled);
        }
        
        //Debug.Log(PlayerMotion.hope_on);
    }
}
