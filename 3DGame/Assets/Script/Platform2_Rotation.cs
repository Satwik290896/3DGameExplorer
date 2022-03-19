using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform2_Rotation : MonoBehaviour
{
    public float P2_R_Speed = 20f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.down * P2_R_Speed * Time.deltaTime);
    }
}
