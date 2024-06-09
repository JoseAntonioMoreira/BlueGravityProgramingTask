using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int gold;
    public TextMeshProUGUI goldText;
    public InventoryItem[] Items;

    private void Start()
    {
        goldText.text = gold.ToString() + " g";
    }

    public void ToggleInventory()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        goldText.text = gold.ToString() + " g";
    }
}
