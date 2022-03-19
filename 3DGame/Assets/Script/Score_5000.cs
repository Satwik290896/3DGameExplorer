using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score_5000 : MonoBehaviour
{
    public TextMeshProUGUI Score;
    public static int score=5000;
    public static float last_finished_time = 0;
    // Start is called before the first frame update
    void Start()
    {
        Score = gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        Score.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMotion.final_stage_on == true && Restart_Button.application_reboots == true){
            score=5000;
            last_finished_time = Time.time;
        }
        if(PlayerMotion.red_blue_obstacle == true || PlayerMotion.red_blue_obstacle_2 == true){
            score = score-1;
        }
        Score.text = "Score: " + score.ToString();
    }
}
