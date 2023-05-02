using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{

    public static ScoreTracker instance;
    public int score;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(SurvivalTime.instance != null)
        {
            score = SurvivalTime.instance.finalScore;
        }
        else
        {
            GameObject.FindGameObjectWithTag("final score").GetComponent<TextMeshProUGUI>().text = "SCORE: " + (score * 10);
        }
    }
}
