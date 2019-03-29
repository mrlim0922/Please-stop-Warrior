using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGround : MonoBehaviour {

    float speed = 6f;

    private void Start()
    {
        AudioManager.instance.Play("MainBgm");
    }

    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }

    private void OnBecameInvisible()
    {
        Debug.Log("No Camera");
        transform.Translate(32.4f, 0, 0);
    }
}
