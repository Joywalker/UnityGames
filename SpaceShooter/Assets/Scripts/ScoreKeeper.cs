using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    public int score;
    private Text myScore;

    private void Start()
    {
        //Gets Text UI that holds the score in the Game Scene, and sets it to 0
        myScore = GetComponent<Text>();
        myScore.text = "0";

    }
    //Sums the score points
    public void ScorePoints(int points)
    {
        this.score += points;
        myScore.text= score.ToString();
    }

    //Resetting score
    private void Reset()
    {
        score = 0;
        myScore.text = score.ToString();
    }
}
