using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Board : MonoBehaviour
{
    public TextMeshProUGUI Score;
    public static int score=5000;
    public static float time_val = 0;
    public static float last_finished_time = 0;
    // Start is called before the first frame update
    void Start()
    {
        Score = gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        score = Score_5000.score;
        time_val = Time_score.time_to_display;
        Score.text = "Score: " + score.ToString() + "\nTime Elapsed: "+(time_val);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMotion.final_stage_on == true && Restart_Button.application_reboots == true){
            score = 5000;
            last_finished_time = Time.time;
        }

        if(PlayerMotion.red_blue_obstacle == true){
            score = score-1;
        }

        score = Score_5000.score;
        time_val = Time_score.time_to_display;
        Score.text = "Score: " + score.ToString() + "\nTime Elapsed: "+(time_val);
    }
}
