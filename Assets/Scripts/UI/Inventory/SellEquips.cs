using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SellEquips : MonoBehaviour, IDropHandler, IPointerEnterHandler
{
    public Inventory inventory;
    public TextMeshProUGUI valueText;


    public void OnDrop(PointerEventData eventData)
    {
        SellItem(eventData);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        eventData.pointerDrag.TryGetComponent(out DraggableItem draggableItem);
        valueText.text = draggableItem.item.SellValue.ToString();
    }

    private void SellItem(PointerEventData eventData)
    {
        DraggableItem draggableItem = eventData.pointerDrag.GetComponent<DraggableItem>();
        inventory.gold += draggableItem.item.SellValue;
        inventory.goldText.text = inventory.gold.ToString() + " g";
        Destroy(eventData.pointerDrag);
        valueText.text = "Sell";
    }
}
