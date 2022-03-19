using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Side_Camera_Motion : MonoBehaviour
{
    public GameObject targetObject;
    public Vector3 cameraOffset;
    public Transform targetObject2;
    public Transform targetObject3;
    public Transform targetObject4;
    public Transform targetObject5;
    // Start is called before the first frame update
    void Start()
    {
        //cameraOffset = transform.position - targetObject.transform.position;
        cameraOffset = new Vector3(-372,400,-3500);
        Debug.Log(cameraOffset);
        targetObject = GameObject.FindGameObjectWithTag("Platform1");
        Vector3 newPosition = targetObject.transform.position + cameraOffset;
        transform.position = newPosition;
        transform.LookAt(targetObject2);
    }

    // Update is called once per frame
    void LateUpdate()
    {
                     if(PlayerMotion.platform1_on ==true){
                        targetObject = GameObject.FindGameObjectWithTag("Platform1");
                        cameraOffset = new Vector3(-372,400,-3500);
                        Vector3 newPosition = targetObject.transform.position + cameraOffset;
                        transform.position = newPosition;
                        transform.LookAt(targetObject2);
                    }
                    else if(PlayerMotion.platform2_on ==true){
                        targetObject = GameObject.FindGameObjectWithTag("Platform2");
                        cameraOffset = new Vector3(-372,192,100);
                        Vector3 newPosition = targetObject.transform.position + cameraOffset;
                        transform.position = newPosition;
                        transform.LookAt(targetObject3);
                    }
                    else if(PlayerMotion.platform3_on ==true){
                        targetObject = GameObject.FindGameObjectWithTag("Platform3");
                        cameraOffset = new Vector3(-372,192,100);
                        Vector3 newPosition = targetObject.transform.position + cameraOffset;
                        transform.position = newPosition;
                        transform.LookAt(targetObject4);
                    }
                    else if(PlayerMotion.platform4_on ==true){
                        targetObject = GameObject.FindGameObjectWithTag("Platform4");
                        cameraOffset = new Vector3(-372,192,100);
                        Vector3 newPosition = targetObject.transform.position + cameraOffset;
                        transform.position = newPosition;
                        transform.LookAt(targetObject5);
                    }
                    else{
                        targetObject = GameObject.FindGameObjectWithTag("Platform1");
                        cameraOffset = new Vector3(-372,400,-3500);
                        Vector3 newPosition = targetObject.transform.position + cameraOffset;
                        transform.position = newPosition;
                        transform.LookAt(targetObject2);
                    }


    }
}
