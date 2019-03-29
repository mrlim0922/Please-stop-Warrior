using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Text scoreResultText;

    void Update()
    {
        scoreText.text = "Score : " + ScoreManager.instance.currentScore.ToString();
        scoreResultText.text = ScoreManager.instance.currentScore.ToString();
    }
}
