using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public int type;
    public float speed = 1f; // 이동속도

    public float atkDelay; //공격 딜레이

    public Animator anim;

    private bool action = false;
    
	void Update () {
        transform.Translate(-speed * Time.deltaTime, 0, 0);

        if(speed == 0 && !action)
        {
            Filp();
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && type != 1)
        {
            speed = 0;
        }
        else if(collision.CompareTag("Long") && type == 1)
        {
            speed = 0;
        }
    }

    private void Filp()
    {
        action = true;
        anim.SetTrigger("Attack");
        StartCoroutine(WaitCoroutine());
    }
    
    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        PlayerStat.instance.Hit(GetComponent<EnemyStat>().atk);

        yield return new WaitForSecondsRealtime(atkDelay);
        action = false;
    }
}
