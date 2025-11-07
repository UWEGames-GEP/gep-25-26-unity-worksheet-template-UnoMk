using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public GameManager gameManager;

    public List<string> items = new List<string>();

    public void AddItem(string itemName)
    {
        items.Add(itemName);
    }

    public void RemoveItem(string itemName)
    {
        items.Remove(itemName);
    }

    void Start()
    {
    }

    void Update()
    {
        if (gameManager.state != GameManager.GameState.GAMEPLAY)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AddItem("Generic Item");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            RemoveItem("Generic Item");
        }
    }
}
