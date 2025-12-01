using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class InventoryMenu : MonoBehaviour
{
    public Inventory inventory;
    public List<GameObject> inventoryUIButtons = new List<GameObject>();

    void RefreshInventory()
    {
        foreach (GameObject uiButton in inventoryUIButtons)
        {
            uiButton.SetActive(false);
        }

        for (int i = 0; i < inventory.items.Count; i++)
        {
            if (i < inventoryUIButtons.Count)
            {
                InventoryUIButton uIButton = inventoryUIButtons[i].GetComponent<InventoryUIButton>();
                Items item = inventory.items[i];

                uIButton.gameObject.SetActive(true);
                uIButton.SetButton(item);
            }
        }
    }

    private void OnEnable()
    {
        RefreshInventory();
    }
    public void OnInventoryUIButton(int i)
    {
        inventory.RemoveItem(i);
        RefreshInventory();
    }
}
