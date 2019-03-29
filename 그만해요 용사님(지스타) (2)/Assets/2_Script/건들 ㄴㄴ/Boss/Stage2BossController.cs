using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2BossController : MonoBehaviour
{

    public float speed = 1f; // 이동속도

    public float atkDelay; //공격 딜레이

    public Animator anim;

    private bool action = false;
    public GameObject att;

    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);

        if (speed == 0 && !action)
        {
            Filp();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Long"))
        {
            speed = 0;
        }
    }

    private void Filp()
    {
        action = true;
        anim.SetTrigger("Attack");
        //StartCoroutine(WaitCoroutine());
    }

    /*IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(0.5f);

        Vector2 pos = new Vector2(GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y);
        pos.y += 2.3f;
        pos.x += 0.3f;

        Instantiate(att, pos, GameObject.Find("Player").transform.rotation);

        PlayerStat.instance.Hit(GetComponent<EnemyStat>().atk);

        yield return new WaitForSecondsRealtime(atkDelay);
        action = false;
    }*/
}
