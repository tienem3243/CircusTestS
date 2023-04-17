using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;
using System.Runtime.InteropServices;
using Manager;
public class ToastLagger : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Candy"))
        {
            Debug.Log("WiN");
            GameManager.Instance.isWin = true;
            //gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            collision.gameObject.SetActive(false);
      
        }
    }
 
}
