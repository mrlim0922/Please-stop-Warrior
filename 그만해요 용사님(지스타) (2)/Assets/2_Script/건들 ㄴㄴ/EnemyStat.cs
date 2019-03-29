using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour {

    private PolygonCollider2D theCollider;
    private SpriteRenderer spriteRenderer;

    public Animator anim;

    public double hp; // 최고hp
    public int atk; //공격력
    public int tag;

    public int gold = 100;
    public int score = 500;

    private double currentHp; //현 hp

    private void Start()
    {
        theCollider = GetComponent<PolygonCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        currentHp = hp;
    }

    public void Hit(double _playerAtk)
    {
        double plyaerAtk = _playerAtk;

        currentHp -= plyaerAtk;

        StartCoroutine(UnBeatTime());

        if (currentHp <= 0)
        {
            anim.SetBool("Die", true);
            ScoreManager.instance.currentScore += score;
            SwipeCountManager.instance.CountUp(2);
            GoldManager.instance.gold += gold;
            theCollider.enabled = false;

            Destroy(this.gameObject, 1f);

            if (tag == 1)
                StageManager.FindObjectOfType<StageManager>().ChangeStage();

            if (tag == 2)
                StageManager.FindObjectOfType<StageManager>().ChangeStage3();


        }
    }

    IEnumerator UnBeatTime()
    {
        int countTime = 0;

       // theCollider.enabled = false;

        while(countTime < 5)
        {
            if (countTime % 2 == 0)
                spriteRenderer.color = new Color32(255, 255, 255, 150);
            else
                spriteRenderer.color = new Color32(255, 255, 255, 200);

            yield return new WaitForSeconds(0.1f);

            countTime++;
        }

        spriteRenderer.color = new Color32(255, 255, 255, 255);
        //theCollider.enabled = true;
    }
}
