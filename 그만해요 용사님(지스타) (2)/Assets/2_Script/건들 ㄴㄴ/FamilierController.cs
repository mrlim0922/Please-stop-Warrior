using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilierController : MonoBehaviour {

    public static FamilierController instance;

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

    private void Start()
    {
        instance = this;
    }

    public GameObject[] fire; // 공격 종류
    public Animator anim;

    private bool shot = false;

    // 공격 함수
    private void Shot(float _delay, int _num) 
    {
        StartCoroutine(WaitDelay(_delay, _num));     
    }

    public void CreateSkill(int _skillNum)
    {
        if (_skillNum == 2)
        {
            anim.SetTrigger("Skill1");
            Shot(0.5f, 0);
        }
        else if (_skillNum == 3)
        {
            anim.SetTrigger("Skill1");
            Shot(0.5f, 1);
        }
        else if (_skillNum == 4)
        {
            anim.SetTrigger("Skill2");
            Shot(0.5f, 2);
        }
        
        else if(_skillNum == 5)
        {
            anim.SetTrigger("Skill2");
            Shot(0.5f, 3);
        }
        else if (_skillNum == 6)
        {
            anim.SetTrigger("Skill3");
            PlayerStat.instance.hpUp(30);
            Shot(0.6f, 4);
        }
        else
        {
            anim.SetTrigger("Skill4");
            Shot(0.5f, 5);
        }
    }

    IEnumerator WaitDelay(float _time, int num)
    {
        yield return new WaitForSeconds(_time);
        shot = true;

        if (shot == true && num < 4)
        {
            Vector3 pos = transform.position;
            pos.x += 1f;

            Instantiate(fire[num], pos, transform.rotation);
        }

        else if(shot == true && num == 5)
        {
            Vector3 pos = transform.position;
            pos.x += 5.5f;

            Instantiate(fire[num], pos, transform.rotation);
        }

        else
            Instantiate(fire[num], transform.position, transform.rotation);

        shot = false;
    }
}
