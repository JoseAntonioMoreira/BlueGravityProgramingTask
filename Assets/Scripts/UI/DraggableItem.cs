using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Image image;

    public InventoryItem item;

    [HideInInspector]
    public Transform initialParent;

    private void Start()
    {
        image = GetComponent<Image>();
        image.sprite = item.icon;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        initialParent = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;

        ChangeEquip();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(initialParent);
        image.raycastTarget = true;
    }

    private void ChangeEquip()
    {
        if (initialParent.CompareTag("equipSlot"))
        {
            EquipmentSlot equipmentSlot = initialParent.GetComponent<EquipmentSlot>();
            equipmentSlot.gearSlot.sprite = null;
        }
    }
}
