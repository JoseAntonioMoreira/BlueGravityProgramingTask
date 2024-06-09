using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int gold;
    public InventoryItem[] Items;

    public void ToggleInventory()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
