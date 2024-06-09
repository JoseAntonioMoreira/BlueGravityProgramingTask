using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    protected PointerEventData eventData;
    public void OnDrop(PointerEventData eventData)
    {
        this.eventData = eventData;
        OnItemDropped();
    }

    protected virtual void OnItemDropped()
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            draggableItem.initialParent = transform;
        }
    }
}
