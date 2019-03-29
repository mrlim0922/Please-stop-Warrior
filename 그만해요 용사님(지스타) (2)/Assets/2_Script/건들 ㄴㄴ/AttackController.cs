using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour {

    public int type; // 스킬 타입

    public float speed = 3f;
    public GameObject eff; // 터지는 이펙

    private bool isExplosion = false; // 한 번 체크후 삭제
    private bool isAttack = false;

    private PlayerStat thePlayer;

    private PolygonCollider2D theCollider;

    private void Start()
    {
        thePlayer = FindObjectOfType<PlayerStat>();
        theCollider = GetComponent<PolygonCollider2D>();
    }

    void Update () {
		if(type < 4)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            if (transform.position.x >= 6)
                Destroy(gameObject);
        }
	}

    // 공격 타입
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("Enemy") || collision.CompareTag("Boss")) && !isExplosion)
        {
            AudioManager.instance.Play("Hit");
            Instantiate(eff, collision.transform.position, collision.transform.rotation);
        }

        if (type == 0)
        {
            if ((collision.CompareTag("Enemy") || collision.CompareTag("Boss")) && !isExplosion)
            {
                isExplosion = true;
                collision.GetComponent<EnemyStat>().Hit(thePlayer.atk * 0.85);
                Destroy(gameObject);
            }
        }

        else if (type == 1)
        {
            if ((collision.CompareTag("Enemy") || collision.CompareTag("Boss")) && !isExplosion)
            {
                collision.GetComponent<EnemyStat>().Hit(thePlayer.atk * 1.2);

                isExplosion = true;
                Destroy(gameObject);
            }
        }

        else if (type == 2 || type == 3)
        {
            if ((collision.CompareTag("Enemy") || collision.CompareTag("Boss")) && !isAttack)
            {
                if(type == 2)
                    collision.GetComponent<EnemyStat>().Hit(thePlayer.atk * 0.8);

                if(type == 3)
                    collision.GetComponent<EnemyStat>().Hit(thePlayer.atk * 1.25);

                StartCoroutine(AttackDelay());
            }
        }

        else if(type == 5)
        {
            if(collision.CompareTag("Enemy"))
            {
                PlayerStat.instance.hpUp(100);
                collision.GetComponent<EnemyStat>().Hit(9999);
            }

            else if(collision.CompareTag("Boss"))
            {
                PlayerStat.instance.hpUp(100);
                collision.GetComponent<EnemyStat>().Hit(thePlayer.atk * 8);
            }
        }
    }

    IEnumerator AttackDelay()
    {
        isAttack = true;
        theCollider.enabled = false;
        yield return new WaitForSeconds(0.7f);
        theCollider.enabled = true;
        isAttack = false;
    }
}
