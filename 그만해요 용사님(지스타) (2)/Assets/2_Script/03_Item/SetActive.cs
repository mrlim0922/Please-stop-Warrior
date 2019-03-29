using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour {

    #region Singleton

    public static SetActive instance;

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

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void SetActiveTrue()
    {
        gameObject.SetActive(true);
    }

    public void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }
}
