using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameGround : MonoBehaviour {

    float speed = 6f;

    public Sprite[] sprite; //카운트 스프라이트

    private SpriteRenderer spriteRenderer;
    private StageManager stageManager;

    void Start()
    {
        AudioManager.instance.Play("IngameBgm");
        spriteRenderer = GetComponent<SpriteRenderer>();
        stageManager = FindObjectOfType<StageManager>();
    }

    void Update()
    {
        spriteRenderer.sprite = sprite[stageManager.GetStageLevel()];
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }

    private void OnBecameInvisible()
    {
        transform.Translate(37.8f, 0, 0);
    }
}
