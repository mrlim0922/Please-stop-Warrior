using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    bool SetActiveStat = false;

    public Sprite CanNotUpgradeItemSprite;

    public Text goldText;
    public Text IncreaseText;

    public GameObject StatObject;

    public GameObject ItemUpgradeBtn;
    public GameObject StatUpgradeBtn;
    //public GameObject CanNotUpgradeItem;
    public GameObject CanNotUpgradeStat;

    public GameObject Lod;
    public GameObject MyInfo;
    public GameObject UpGrade;
    public GameObject MyInventory;
    public GameObject InvenBG;
    public GameObject BG;
    public GameObject MyChar;
    public GameObject UICanves;
    //public GameObject Item;
    public GameObject SpeechBubble;

    GameObject obj;
    GameObject obj1;

    public void Start()
    {
        MyChar.SetActive(true);
        UICanves.SetActive(true);
        BG.SetActive(true);
        MyInventory.SetActive(false);
        MyInfo.SetActive(false);
        UpGrade.SetActive(false);
        SpeechBubble.SetActive(false);
        SetActive.instance.SetActiveFalse();
    }
    
    public void StartBtn()
    {
        ScoreManager.instance.currentScore = 0;
        GameManager.instance.active = true;
        AudioManager.instance.Stop("MainBgm");
        SceneManager.LoadScene("Game");
    }

    public void StoreBtn()
    {
        Instantiate(Lod, Lod.transform.position, Quaternion.identity);
    }

    public void QuestBtn()
    {
        Instantiate(Lod, Lod.transform.position, Quaternion.identity);
    }

    public void MyInfoBtn()
    {
        MyInfo.SetActive(true);
        MyChar.SetActive(false);
        UICanves.SetActive(false);
        obj = Instantiate(InvenBG, InvenBG.transform.position, Quaternion.identity);
    }

    public void InfoExitBtn()
    {
        MyInfo.SetActive(false);
        MyChar.SetActive(true);
        UICanves.SetActive(true);
        Destroy(obj);
    }

    public void UpgradeWindowBtn()
    {
        MyInfo.SetActive(false);
        UpGrade.SetActive(true);
        CanNotUpgradeStat.SetActive(SetActiveStat);
    }

    public void Upgrade()
    {
        GoldManager.instance.UpGradeStat();
        if (Stat.instance.Level % 10 == 9)
        {
            SpeechBubble.SetActive(true);
        }
        if (SpeechBubble.activeSelf == true && Stat.instance.Level % 10 != 9)
        {
            SpeechBubble.SetActive(false);
        }

        if (Stat.instance.Level >= 30)
        {
            Destroy(StatObject);
            Destroy(StatUpgradeBtn);
            SetActiveStat = true;
            CanNotUpgradeStat.SetActive(true);
        }
    }

    public void UpgradeExitBtn()
    {
        MyChar.SetActive(true);
        UICanves.SetActive(true);
        UpGrade.SetActive(false);
        Destroy(obj);
        if (SpeechBubble.activeSelf == true)
        {
            SpeechBubble.SetActive(false);
        }
        CanNotUpgradeStat.SetActive(false);
    }

    public void InvenBtn()
    {
        if (ItemUpgradeBtn != null)
            ItemUpgradeBtn.SetActive(true);
        SetActive.instance.SetActiveTrue();
        
        MyInventory.SetActive(true);
        MyChar.SetActive(false);
        UICanves.SetActive(false);
        //BG.SetActive(false);
        //obj1 = Instantiate(Item, InvenBG.transform.position, Quaternion.identity);
        obj = Instantiate(InvenBG, InvenBG.transform.position, Quaternion.identity);

        if (ItemTouch.IsEquipItem)
            SetActive2.instance.SetActiveTrue2();
    }

    public void InvenExitBtn()
    {
        if (ItemUpgradeBtn != null)
            ItemUpgradeBtn.SetActive(false);
        
        SetActive.instance.SetActiveFalse();
        MyInventory.SetActive(false);
        MyChar.SetActive(true);
        UICanves.SetActive(true);
        //CanNotUpgradeItem.SetActive(false);
        //BG.SetActive(true);
        Destroy(obj);
        Destroy(obj1);

        if (ItemTouch.IsEquipItem)
            SetActive2.instance.SetActiveFalse2();
    }

    public void InvenUpgradeBtn()
    {
        GoldManager.instance.UpGradeItemStat();

        if (ItemManager.instance.ItemLists[0].Level >= 10)
        {
            ItemUpgradeBtn.GetComponent<Image>().sprite = CanNotUpgradeItemSprite; //버튼 스프라이트 교체
            ItemUpgradeBtn.GetComponent<RectTransform>().sizeDelta =
                new Vector2(283.723f, 170.5f); // 그림 사이즈 조정
            Destroy(ItemUpgradeBtn.GetComponent<Button>());
            Destroy(goldText);
            Destroy(IncreaseText);
        }
    }
}
