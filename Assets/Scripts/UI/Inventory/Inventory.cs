using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int gold;
    public TextMeshProUGUI goldText;
    public InventoryItem[] Items;

    public void ToggleInventory()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        RefreshGold();
    }

    public void RefreshGold()
    {
        goldText.text = gold.ToString() + " g";
    }
}
