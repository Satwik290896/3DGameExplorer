using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Time_score : MonoBehaviour
{
    public TextMeshProUGUI t;
    public static float last_finished_time = 0;
    public static float time_to_display = 0;
    //float time=0;
    // Start is called before the first frame update
    void Start()
    {
        t = gameObject.GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMotion.final_stage_on == true && Restart_Button.application_reboots == true){
            last_finished_time = Time.time;
        }
        time_to_display = Time.time-last_finished_time;
        t.text = "Time: " + time_to_display.ToString();
    }
}
