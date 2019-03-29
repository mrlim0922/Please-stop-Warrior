using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTouch : MonoBehaviour
{
    bool IsEquip = false;
    public GameObject EquipItem;
    static public bool IsEquipItem = false;

    public void ListPointUp()
    {
        Instantiate(EquipItem, EquipItem.transform.position, Quaternion.identity)
                .transform.SetParent(GameObject.Find("Canvas").transform, false);
        TextManager.SetActive = true;
        IsEquipItem = true;
    }

    public void EquipPointUp()
    {
        Destroy(gameObject);
        TextManager.SetActive = false;
        IsEquipItem = false;
    }
}
