using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI roundtxt;
    [SerializeField]
    private TextMeshProUGUI turnScoretxt, totalRoundScoretxt;

    public int turn1ScoreInt;
    public int turn2ScoreInt;

    [SerializeField]
    private int totalRoundScoreInt;

    public int turns;
    // Update is called once per frame
    void Update()
    {
        turnScoretxt.text = turn1ScoreInt.ToString() + " | " + turn2ScoreInt.ToString();
        totalRoundScoreInt = turn1ScoreInt + turn2ScoreInt;
        switch (turns)
        {
            case 0:
                roundtxt.text = "Turn 1";
                break;
            case 1:
                roundtxt.text = "Turn 2";
                break;
            case 2:
                totalRoundScoretxt.text = totalRoundScoreInt.ToString();
                break;
        }

    }

}
