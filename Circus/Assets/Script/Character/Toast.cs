using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Character
{
    public class Toast : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            collision.gameObject.SetActive(false);


        }
    }
}

