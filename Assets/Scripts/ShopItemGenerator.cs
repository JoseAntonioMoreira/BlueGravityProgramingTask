using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemGenerator : MonoBehaviour
{
    public DraggableItem[] availableItems;

    public DraggableItem[] itemsForSale;
    void Start()
    {
        itemsForSale = new DraggableItem[19];
        for (int i = 0; i < itemsForSale.Length; i++)
        {
            itemsForSale[i] = availableItems[Random.Range(0, availableItems.Length)];
        }

        SpawnItemForSale();
    }

    void SpawnItemForSale()
    {
        for (int i = 0; i < itemsForSale.Length; i++)
        {
            Instantiate(itemsForSale[i].gameObject, transform.GetChild(i + 1).transform);
        }
    }
}
