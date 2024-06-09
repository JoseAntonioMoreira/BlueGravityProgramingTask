using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipItems : MonoBehaviour
{
    public Image helmet;
    public Image armor;
    public Image shield;
    public Image weapon;

    public void ChangeHelmet(DraggableItem draggableItem)
    {
        helmet.sprite = draggableItem.item.icon;
    }

    public void ChangeArmor(DraggableItem draggableItem)
    {
        armor.sprite = draggableItem.item.icon;
    }

    public void ChangeShield(DraggableItem draggableItem)
    {
        shield.sprite = draggableItem.item.icon;
    }

    public void ChangeWeapon(DraggableItem draggableItem)
    {
        weapon.sprite = draggableItem.item.icon;
    }
}
