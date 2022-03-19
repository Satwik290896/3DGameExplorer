using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    public Transform targetObject;
    public Transform targetObject2;
    public Vector3 cameraOffset;
    public Camera cam;
    public Vector3 off = new Vector3(0, 0, 500);
    public Vector3 pos;
    public bool LookAtTarget = false;
    // Start is called before the first frame update
    void Start()
    {
        //cameraOffset = transform.position - targetObject.transform.position;
        cameraOffset = new Vector3(-10,105,-96);
        Debug.Log(cameraOffset);
        cam = GetComponent<Camera>();
        pos = targetObject.transform.position + off;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Vector3 newPosition_offset = targetObject.transform.position + cameraOffset - transform.position;
        float val = 60;
        if(LeftRotate_Button.lr_on ==true){
            val = -60;
        }
        else if(RightRotate_Button.rr_on ==true){
            val = 60;
        }
        if((LeftRotate_Button.lr_on ==true) || (RightRotate_Button.rr_on ==true)){
            cameraOffset = Quaternion.AngleAxis(val*Time.deltaTime, Vector3.up)*cameraOffset;
        }
        
        transform.position = Vector3.Lerp(transform.position, targetObject.transform.position + cameraOffset, 0.1f);
        transform.LookAt(targetObject2);
        if(LookAtTarget){
            
        }

        pos = targetObject.transform.position + off;
        Ray ray = cam.ScreenPointToRay(pos);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
        //Debug.Log("Casting");
    }
}
