using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeCountManager : MonoBehaviour {

    public static SwipeCountManager instance;

    #region Singleton
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
           // DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }
    #endregion Singleton

    public int SwipeCnt = 15; // 스와이프 횟수
    public int blockCnt = 0;  // 블럭 개수

    private float SwipeTime = 1f; // 충전시간


    void Start () {
        instance = this;
        StartCoroutine(SwipeCountUp());
	}

    IEnumerator SwipeCountUp()
    {
        while(true)
        {
            yield return new WaitForSeconds(SwipeTime);
            if (SwipeCnt < 15)
                SwipeCnt++;
        }
    }

    public void CountUp(int _num)
    {
        if (SwipeCnt + _num > 15)
            SwipeCnt = 15;

        else
            SwipeCnt += _num;
    }
}
