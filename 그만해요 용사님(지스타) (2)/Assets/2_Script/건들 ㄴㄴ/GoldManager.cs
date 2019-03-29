using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{

    public static GoldManager instance;

    #region Singleton
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

    public int gold;
    public int UpgradeGold = 800;


    void Start()
    {
        instance = this;
    }

    public void UpGradeStat()
    {
        if (gold < UpgradeGold)
            return;

        AudioManager.instance.Play("Upgrade");

        Stat.instance.hp += 7;
        Stat.instance.atk += 5;
        Stat.instance.Level += 1;


        gold -= UpgradeGold;
        UpgradeGold += 400;
    }
    public void UpGradeItemStat()
    {

        if (gold < ItemManager.instance.ItemLists[0].Price)
            return;

        AudioManager.instance.Play("Upgrade");

        ItemManager.instance.ItemLists[0].Atk += 1;
        ItemManager.instance.ItemLists[0].Level += 1;
        ItemManager.instance.ItemLists[0].Price += 400;


        gold -= ItemManager.instance.ItemLists[0].Price;
    }


}
