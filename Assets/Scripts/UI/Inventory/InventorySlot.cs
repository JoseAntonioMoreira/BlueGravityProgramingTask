using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Inventory inventory;

    protected PointerEventData eventData;

    DraggableItem draggableItem;

    public void Start()
    {
        inventory = transform.parent.GetComponent<Inventory>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        this.eventData = eventData;
        draggableItem = eventData.pointerDrag.GetComponent<DraggableItem>();
        OnItemBought();
        OnItemDropped();
    }

    private void OnItemBought()
    {
        if (draggableItem.forSale && inventory.gold >= draggableItem.item.BuyValue && transform.childCount == 0)
        {
            draggableItem.forSale = false;
            draggableItem.transform.GetChild(0).gameObject.SetActive(false);
            inventory.gold -= draggableItem.item.BuyValue;
            inventory.goldText.text = inventory.gold.ToString() + " g";
        }
    }

    protected virtual void OnItemDropped()
    {
        if (transform.childCount == 0 && !draggableItem.forSale)
        {
            draggableItem.initialParent = transform;
        }
    }
}
