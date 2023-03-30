using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Arrow : MonoBehaviour
{
    [SerializeField]Rigidbody2D rig;
    [SerializeField] LayerMask layerMask;
    private UnityEvent onHit= new UnityEvent();

    public UnityEvent OnHit { get => onHit; set => onHit = value; }


    private void Update()
    {
        Debug.Log(rig.velocity);
        if (rig.velocity != Vector2.zero)
        {
            float angle = Mathf.Atan2(rig.velocity.y, rig.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
     
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((layerMask.value & (1 << collision.gameObject.layer)) > 0)
        {
            if (OnHit != null)
                OnHit.Invoke();
            rig.velocity = Vector2.zero;
            rig.gravityScale = 0;
            Debug.Log("Stop");  
        }
       
    }

}
