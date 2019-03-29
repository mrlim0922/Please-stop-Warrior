using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class InGameBtnManager : MonoBehaviour {

    public GameObject Lod;

    void Awake()
    {
        Lod.SetActive(false);
    }

    public void SettingBtnDown()
    {
        Lod.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeBtnDown()
    {
        Lod.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitBtnDown()
    {
        Time.timeScale = 1;
        AudioManager.instance.Stop("IngameBgm");
        GameManager.instance.active = false;
        SceneManager.LoadScene("Main");
    }

    public void ResultExitBtn()
    {
        Time.timeScale = 1;
        AudioManager.instance.AllStop();
        SceneManager.LoadScene("Main");
        GameManager.instance.plusGold = 0;
        ScoreManager.instance.currentScore = 0;
    }

    public void ResultResumeBtn()
    {
        Time.timeScale = 1;
        GoldManager.instance.gold += GameManager.instance.plusGold;
        SceneManager.LoadScene("Game");
        GameManager.instance.plusGold = 0;
        ScoreManager.instance.currentScore = 0;
        
    }
}
