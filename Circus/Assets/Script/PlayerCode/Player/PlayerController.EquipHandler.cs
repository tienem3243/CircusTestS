using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{


public partial class PlayerController
{
    public void EquipmentHandler(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            Take();

        }


    }

    private void Take()
    {
        nearestItem = FindNearest(transform.position, radiusTakeItem, WeaponLayer);
            if (nearestItem != null)
            {
                if (weapon != null)
                    weapon.UnEquip();
                nearestItem.TryGetComponent<Weapon>(out weapon);
                weapon.Equip();
                nearestItem = null;
            }
     
    }
       
 
}
}