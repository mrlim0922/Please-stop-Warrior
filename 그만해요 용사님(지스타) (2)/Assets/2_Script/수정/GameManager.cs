using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

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

    //public GameObject Lod;

    public float goldTime;
    public float stageTile;
    public int plusGold;
    public bool active;
    
    private void Start()
    {
        instance = this;
        //Lod.SetActive(false);
    }

    private void Update()
    {
        //골드
        if (active)
            goldTime += Time.deltaTime;

        if(goldTime > 1f)
        {
            goldTime = 0;
            plusGold += 3;
        }

        if (Die)
        {
            Time.timeScale = 0;
            //Lod.SetActive(true);
        }
    }

    public bool Die = false;

    public bool GetDie()
    {
        return Die;
    }
}
