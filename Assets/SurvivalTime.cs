using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SurvivalTime : MonoBehaviour
{
    public static SurvivalTime instance;

    [SerializeField]
    TextMeshProUGUI text;
    float time;

    public int extraScore;

    public int finalScore;

    private void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        finalScore = Mathf.RoundToInt(time * 5) + extraScore;
        time += Time.deltaTime; ;
        text.text = "SCORE: " + Mathf.RoundToInt(time * 5) + extraScore;
    }
}
