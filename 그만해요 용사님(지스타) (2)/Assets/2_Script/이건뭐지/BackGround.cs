using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour {

    float speed = 6f;

    private void Update()
    {
        Vector2 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
