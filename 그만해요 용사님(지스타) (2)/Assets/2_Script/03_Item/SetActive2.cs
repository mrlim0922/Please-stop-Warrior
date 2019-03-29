using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive2 : MonoBehaviour
{
    #region Singleton

    public static SetActive2 instance;

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

    public void SetActiveTrue2()
    {
        gameObject.SetActive(true);
    }

    public void SetActiveFalse2()
    {
        gameObject.SetActive(false);
    }
}
