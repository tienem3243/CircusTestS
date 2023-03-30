using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Player;
public interface Weapon
{
    public abstract void Attack(InputAction.CallbackContext context);
    public abstract GameObject getObject();
    public abstract void Equip();
    public abstract void UnEquip();
}
       

