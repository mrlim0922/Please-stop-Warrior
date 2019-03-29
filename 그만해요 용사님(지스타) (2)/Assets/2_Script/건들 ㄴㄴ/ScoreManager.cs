using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance;

    #region Singleton
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }
    #endregion Singleton

    public int currentScore;
    private static int MaxScore;

	void Start () {
        instance = this;
	}
	
    public void MaxScoreCheck()
    {
        if (currentScore > MaxScore)
            MaxScore = currentScore;
    }

   
    // 타일 사용시
    public void UseTileScore(int _num)
    {
        if (_num == 2)
            currentScore += 50;
        else if (_num == 3)
            currentScore += 150;
        else if (_num == 4)
            currentScore += 400;
        else if (_num == 5)
            currentScore += 1050;
        else if (_num == 6)
            currentScore += 2500;
        else if (_num == 7)
            currentScore += 6000;
    }

    // 타일 조합시
    public void CombiTileScore(int _num)
    {
        if (_num == 2)
            currentScore += 50;
        else if (_num == 3)
            currentScore += 120;
        else if (_num == 4)
            currentScore += 350;
        else if (_num == 5)
            currentScore += 800;
        else if (_num == 6)
            currentScore += 1650;
        else if (_num == 7)
            currentScore += 3750;
    }
}
