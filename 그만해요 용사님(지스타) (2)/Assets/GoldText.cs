using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldText : MonoBehaviour
{
    Text goldText;

    private void Awake()
    {
        goldText = GetComponent<Text>();
    }

    void Update()
    {
        goldText.text = goldText.text = GameManager.instance.plusGold.ToString();
    }
}
