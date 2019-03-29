using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

    #region Singleton

    public static ItemManager instance;

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

    public ItemStat[] Items;
    public GameObject ItemListObject;
    public GameObject ItemListCase;

    [HideInInspector]
    public List<ItemStat> ItemLists = new List<ItemStat>();

    int count = 0;

    void Start()
    {
        for (int i = 0; i < Items.Length; i++)
        {
            ItemLists.Add(Items[i]);
            Instantiate(ItemListObject, ItemListObject.transform.position, Quaternion.identity)
                .transform.SetParent(ItemListCase.transform, false);
        }
    }

    void Update()
    {
        if (count < ItemLists.Count)
        {
            Instantiate(ItemLists[count], ItemLists[count].GameObj.transform.position, Quaternion.identity)
                .transform.SetParent(ItemListCase.transform, false);
        }
        else
        {
            count = 0;
        }
    }

    void OnApplicationQuit()
    {
        for (int i = 0; i < ItemLists.Count; i++)
        {
            ItemLists[i].Atk = 5;
            ItemLists[i].Level = 1;
            ItemLists[i].Price = 1200;
        }
    }
}


