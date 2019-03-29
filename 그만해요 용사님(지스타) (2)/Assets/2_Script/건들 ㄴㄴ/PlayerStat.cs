using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStat : MonoBehaviour {

    public static PlayerStat instance;

    #region Singleton
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            //DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }
    #endregion Singleton

    public int hp = 300000;
    public double atk;

    private int currentHp;

    public Slider hpBar;

    public Animator anim;
    public GameObject ResultUI;
    public Text goldText;

    private float time;

    private void Start()
    {
        ResultUI.SetActive(false);
        instance = this;
        hp = Stat.instance.hp;
        atk = Stat.instance.atk;
        currentHp = hp;
        time = 2f;
        hpBar.maxValue = currentHp;
    }

    private void Update()
    {
        time -= Time.deltaTime;

        hpBar.value = currentHp;

        if (time < 0)
        {
            time = 2f;
            currentHp -= 3;
        }

        if(currentHp <= 0)
        {
            Die();
        }
    }

    public void Hit(int _enemyAtk)
    {
        currentHp -= _enemyAtk;

        if (currentHp <= 0)
        {
            Die();
        }
    }

    public void hpUp(int _num)
    {
        if (currentHp + _num > hp)
            currentHp = hp;

        else
            currentHp += _num;
    }

    private void Die()
    {
        GoldManager.instance.gold += GameManager.instance.plusGold;
        anim.SetBool("Die", true);
        GameManager.instance.active = false;
        ResultUI.SetActive(true);
        AudioManager.instance.Stop("IngameBgm");
        AudioManager.instance.Play("ResultIntro");
        StartCoroutine(ResultBgmOn());
        
        Time.timeScale = 0;
        goldText.text = GameManager.instance.plusGold.ToString();
        Destroy(this.gameObject);
    }

    IEnumerator ResultBgmOn()
    {
        yield return new WaitForSeconds(4f);
        AudioManager.instance.AllStop();
        AudioManager.instance.Play("ResultBGM");
    }
}
