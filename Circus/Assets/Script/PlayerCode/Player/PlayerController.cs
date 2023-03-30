using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
namespace Player
{
    public partial class PlayerController : MonoBehaviour
    {
        [SerializeField] private const float RADIUS_GROUND_CHECK = 0.2f;
        [SerializeField] private const float SLOW_FACTOR = 0.5f;
        [SerializeField] private float speed = 100f;
        [SerializeField] private Rigidbody2D rbPlayer;
        [SerializeField] private float horizontal;
        [SerializeField] private bool isFacingRight = true;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private float jumpingPower = 16f;
        [SerializeField] private Vector3 WeapOffset;
        [SerializeField] public LayerMask WeaponLayer;
        //item take stat
        [SerializeField] private float radiusTakeItem;
        //private handler
        private GameObject JunkHandler;
        GameObject nearestItem;

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, radiusTakeItem);
            Gizmos.color = Color.red;
        }


        public void Jump(InputAction.CallbackContext context)
        {
            if (context.performed && isGrounded())
            {
                rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, jumpingPower);
            }
            if (context.canceled && rbPlayer.velocity.y > 0)
            {
                rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, rbPlayer.velocity.y * SLOW_FACTOR);
            }

        }
        //
        public void Move(InputAction.CallbackContext context)
        {
            horizontal = context.ReadValue<Vector2>().x;
        }
      

        private GameObject FindNearest(Vector3 center,float radius , LayerMask WeaponLayer)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(center, radius, WeaponLayer);
            float minDistance = float.PositiveInfinity;
            float tempCalculate;
            GameObject res=null;
            if (colliders.Length != 0)
                foreach (Collider2D col in colliders)
                {
                    tempCalculate = Vector3.Distance(col.gameObject.transform.position, transform.position);
                    if (tempCalculate < minDistance)
                    {
                        minDistance = tempCalculate;
                        res = col.gameObject;
                    }
                }
            return res;
        }

      

        private bool isGrounded()
        {

            return Physics2D.OverlapCircle(groundCheck.position, RADIUS_GROUND_CHECK, groundLayer);
        }

        private void Flip()
        {
            isFacingRight = !isFacingRight;
            Vector2 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

    }

}