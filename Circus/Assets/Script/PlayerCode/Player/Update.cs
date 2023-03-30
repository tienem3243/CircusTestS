using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public partial class PlayerController : MonoBehaviour
    {
        private void Update()
        {

            //move
            rbPlayer.velocity = new Vector2(horizontal * speed, rbPlayer.velocity.y);
            //flip
            if (!isFacingRight && horizontal > 0)
            {
                Flip();
            }
            else if (isFacingRight && horizontal < 0)
            {
                Flip();
            }
            if(weapon!=null)
            weapon.getObject().transform.position = transform.position;

        }
    }
}

