using System;
using UnityEngine;

public abstract class SwipeReceiver : MonoBehaviour
{
    //override this
    protected virtual void OnSwipeLeft()
    {
        SwipeManager.Instance.swipeDirection = Swipe.None;
    }

    //override this
    protected virtual void OnSwipeRight()
    {
        SwipeManager.Instance.swipeDirection = Swipe.None;
    }

    //override this
    protected virtual void OnSwipeUp()
    {
        SwipeManager.Instance.swipeDirection = Swipe.None;
    }

    //override this
    protected virtual void OnSwipeDonw()
    {
        SwipeManager.Instance.swipeDirection = Swipe.None;
    }

    protected virtual void Update()
    {
        switch (SwipeManager.Instance.swipeDirection)
        {
            case Swipe.Up:
                OnSwipeUp();
                break;
            case Swipe.Down:
                OnSwipeDonw();
                break;
            case Swipe.Left:
                OnSwipeLeft();
                break;
            case Swipe.Right:
                OnSwipeRight();
                break;
        }
    }
}

