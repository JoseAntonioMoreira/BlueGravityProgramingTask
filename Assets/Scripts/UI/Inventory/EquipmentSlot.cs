using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentSlot : InventorySlot
{
    public SpriteRenderer gearSlot;
    public GearType gearType;

    protected override void OnItemDropped()
    {
        GameObject dropped = eventData.pointerDrag;
        DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();

        if (draggableItem.item.type == gearType)
        {
            if (transform.childCount > 0)
            {
                transform.GetChild(0).SetParent(draggableItem.initialParent);
            }
            draggableItem.initialParent = transform;
            gearSlot.sprite = draggableItem.item.icon;
        }
    }
}
