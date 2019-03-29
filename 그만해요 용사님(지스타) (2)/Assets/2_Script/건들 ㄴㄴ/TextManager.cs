using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    static public bool SetActive = false;

    public GameObject TextObject;

    public Text EquipItemAttackText;
    public Text EquipItemHPText;
    public Text EquipAvilityText;
    public Text EquipCurrentHP;
    public Text EquipCurrentAttack;

    public Text PriceText;
    public Text NameText;
    public Text AvilityText;
    public Text StatText;
    public Text IncreaseText;

    public Text goldText;
    public Text UpgradeGold;
    //public Text FlagText;
    public Text playerAtk;
    public Text playerHp;
    public Text CurrentAtk;
    public Text CurrentHp;
    public Text NowAtk;
    public Text NowHp;
    public Text NextAtk;
    public Text NextHp;
    public Text LevelText;
    public Text InfoLevelText;

    void Update()
    {
        TextObject.SetActive(SetActive);

        double atk = Stat.instance.atk + 5;
        double hp = Stat.instance.hp + 7;
        goldText.text = GoldManager.instance.gold.ToString();
        UpgradeGold.text = GoldManager.instance.UpgradeGold.ToString();
        playerAtk.text = Stat.instance.atk.ToString();
        playerHp.text = Stat.instance.hp.ToString();
        CurrentAtk.text = Stat.instance.atk.ToString();
        CurrentHp.text = Stat.instance.hp.ToString();
        NowHp.text = Stat.instance.hp.ToString();
        NowAtk.text = Stat.instance.atk.ToString();
        NextAtk.text = atk.ToString();
        NextHp.text = hp.ToString();
        LevelText.text = "Lv. " + Stat.instance.Level.ToString();
        InfoLevelText.text = "Lv. " + Stat.instance.Level.ToString();
        PriceText.text = ItemManager.instance.ItemLists[0].Price.ToString();
        NameText.text = ItemManager.instance.ItemLists[0].Name;
        AvilityText.text = ItemManager.instance.ItemLists[0].Avility;
        StatText.text = "공격력 + " + ItemManager.instance.ItemLists[0].Atk.ToString() + "%";
        IncreaseText.text = "공격력 + " + ItemManager.instance.ItemLists[0].AtkIncrease.ToString() + "%";

        EquipCurrentAttack.text = Stat.instance.atk.ToString();
        EquipCurrentHP.text = Stat.instance.hp.ToString();
        EquipItemAttackText.text = " + " + ItemManager.instance.ItemLists[0].Atk.ToString() + "%";
        EquipItemHPText.text = " + " + ItemManager.instance.ItemLists[0].HP.ToString() + "%";
        EquipAvilityText.text = ItemManager.instance.ItemLists[0].Avility;
    }
}
