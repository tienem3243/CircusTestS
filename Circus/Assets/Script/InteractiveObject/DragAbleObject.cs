using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
public class DragAbleObject : MonoBehaviour
{
    enum DragType { Horizontal ,Vertical}
    [SerializeField] DragType dragType;
    public bool isDragging = false;
    private Vector3 startPosition;
    private float maxDisntance = 3.0f;
    public static DragAbleObject instance;
    protected virtual void Awake()
    {
        this.startPosition = transform.position;
        instance = this;
    }
    void OnMouseDown()
    {
        isDragging = true;
        GameManger.Instance.canCut = !isDragging;
        Debug.Log("call is mouse down method");
    }

    void OnMouseUp()
    {
      
        isDragging = false;
        GameManger.Instance.canCut = !isDragging;
        Debug.Log("call mouseUp method");
    }

    protected virtual void FixedUpdate()
    {
        if (isDragging)
            this.Dragging();
    }
    protected virtual void Dragging()
    {
        switch (dragType)
        {
            case DragType.Horizontal:
                HorizontalDrag();
                break;
            case DragType.Vertical:
                VerticalDrag();
                break;
        }
            
        
    }

    private void HorizontalDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        Vector3 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        objectPosition.y = startPosition.y;
        if (objectPosition.x > startPosition.x + maxDisntance) objectPosition.x = startPosition.x + maxDisntance;
        if (objectPosition.x < startPosition.x - maxDisntance) objectPosition.x = startPosition.x - maxDisntance;
        transform.position = objectPosition;
    }


    private void VerticalDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        Vector3 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        objectPosition.x = transform.position.x;
        if (objectPosition.x > startPosition.x + maxDisntance) objectPosition.y = startPosition.y + maxDisntance;
        if (objectPosition.x < startPosition.x - maxDisntance) objectPosition.y = startPosition.y - maxDisntance;
        transform.position = objectPosition;
    }
}
