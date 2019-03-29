using UnityEngine;
using System.Collections;

public class DestroySelf : MonoBehaviour
{
    public float DestroyTime = 1f;
    void Start()
    {
        Destroy(gameObject, DestroyTime);
    }
}

