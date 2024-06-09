using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EquipmentSlot : InventorySlot
{
    public GearType gearType;

    protected override void OnItemDropped()
    {
        GameObject dropped = eventData.pointerDrag;
        DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();


        if (draggableItem.item.type == gearType)
        {
            transform.GetChild(0).SetParent(draggableItem.initialParent);
            draggableItem.initialParent = transform;
        }
    }
}
