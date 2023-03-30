using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
using UnityEngine.Events;

namespace Player
{
    public partial class PlayerController : MonoBehaviour
    {

        [SerializeField] private Weapon weapon;
        [SerializeField] private GameObject weaponObject;
        
        UnityEvent unityEvent
        {
            get
            {
                if (unityEvent != null)
                    return unityEvent;
                else
                {
                    unityEvent = new UnityEvent();
                    return unityEvent;
                }
            }
            set => unityEvent = value;
        }

        public void Attack(InputAction.CallbackContext context)
        {
            if(weapon!=null)
            weapon.Attack(context);
        }
      
    }
}

