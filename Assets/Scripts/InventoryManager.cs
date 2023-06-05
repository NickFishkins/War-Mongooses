using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // Function Stuff
    private GameObject heldItem;
    private GameObject newItem;

    // UI Stuff
    public List<UiItem> uiSyringe = new List<UiItem>();
    public GameObject slotsPrefab;
    public Transform backPanel;
    public int numOfSlots = 3;


    private void Awake()
    {
        for(int i = 0; i < numOfSlots; i++)
        {
            GameObject slotInstance = Instantiate(slotsPrefab);
            slotInstance.transform.SetParent(backPanel);
            uiSyringe.Add(slotInstance.GetComponentInChildren<UiItem>());
        }
    }


    public void RefreshInventory(int slot, ItemScript item)
    {
        uiSyringe[slot].UpdateItems(item);
    }
    public void AddItem(ItemScript item)
    {
        RefreshInventory(uiSyringe.FindIndex(i => i.syringe == null), item);
    }
    public void RemoveItem(ItemScript item)
    {
        RefreshInventory(uiSyringe.FindIndex(i => i.syringe == item), null);
    }


    // Function Stuff
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Switch(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Switch(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Switch(2);
        }else if (Input.GetKeyDown(KeyCode.F))
        {
            //RemoveItem();
        }
    }

    private void Switch(int itemNum)
    {
        newItem = GameManager.Instance.items[itemNum];
        GameManager.Instance.itemEquipped = itemNum;
        if(newItem != heldItem)
        {
            heldItem?.SetActive(false);
            newItem.SetActive(true);
            heldItem = newItem;
        }
        else
        {
            return;
        }
    }
}
