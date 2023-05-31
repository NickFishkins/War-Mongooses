using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private GameObject heldItem;
    private GameObject newItem;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Switch(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Switch(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Switch(3);
        }else if (Input.GetKeyDown(KeyCode.F))
        {
            // Put what happens when you use the item.
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
