using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//block을 움직이는 스크립트

public class BlockController : SwipeReceiver

{
    private bool isPause = false;

    private SwipeCountManager swipeManager;
    private NumberBlockManegement blockManegement;

    private void Start()
    {
        swipeManager = FindObjectOfType<SwipeCountManager>();
        blockManegement = GetComponent<NumberBlockManegement>();
    }

    protected override void Update()
    {
        base.Update();

        if (!isPause && swipeManager.SwipeCnt > 0)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                swipeManager.SwipeCnt--;
                blockManegement.ToUp();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                swipeManager.SwipeCnt--;
                blockManegement.ToDown();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                swipeManager.SwipeCnt--;
                blockManegement.ToLeft();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                swipeManager.SwipeCnt--;
                blockManegement.ToRight();
            }

            StartCoroutine(CC());
        }

        StartCoroutine(CC());
    }

    private IEnumerator CC()
    {
        yield return new WaitForEndOfFrame();

        if (!(blockManegement.CanBlockMove() || blockManegement.IsBlockMove))
        {
            Pause();

            //OverUI.SetActive(true);
        }
    }

    protected override void OnSwipeUp()
    {
        base.OnSwipeUp();

        if (!isPause && swipeManager.SwipeCnt > 0)
        {
            swipeManager.SwipeCnt--;
            AudioManager.instance.Play("Swipe");
            blockManegement.ToUp();
        }
    }

    protected override void OnSwipeDonw()
    {
        base.OnSwipeDonw();

        if (!isPause && swipeManager.SwipeCnt > 0)
        {
            swipeManager.SwipeCnt--;
            AudioManager.instance.Play("Swipe");
            blockManegement.ToDown();
        }
    }

    protected override void OnSwipeLeft()
    {
        base.OnSwipeLeft();

        if (!isPause && swipeManager.SwipeCnt > 0)
        {
            swipeManager.SwipeCnt--;
            AudioManager.instance.Play("Swipe");
            blockManegement.ToLeft();
        }
    }

    protected override void OnSwipeRight()
    {
        base.OnSwipeRight();

        if (!isPause && swipeManager.SwipeCnt > 0)
        {
            swipeManager.SwipeCnt--;
            AudioManager.instance.Play("Swipe");
            blockManegement.ToRight();
        }
    }

    public void Pause()
    {
        isPause = true;
    }

    public void Resume()
    {
        isPause = false;
    }
}
