using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public partial class PlayerController : MonoBehaviour
    {
        private void Start()
        {
            if(weaponObject!=null)
            weapon = weaponObject.GetComponent<Weapon>();
        }
    }
}

