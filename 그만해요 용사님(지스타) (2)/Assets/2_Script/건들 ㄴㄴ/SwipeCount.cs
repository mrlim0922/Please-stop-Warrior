using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeCount : MonoBehaviour {

    public Sprite[] sprite; //카운트 스프라이트

    private SpriteRenderer spriteRenderer;

	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	void Update () {
        if (spriteRenderer.sprite != null)
            spriteRenderer.sprite = sprite[SwipeCountManager.instance.SwipeCnt];
	}
}
