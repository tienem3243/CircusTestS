using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAlgebra : MonoBehaviour
{
    public Transform[] point;
    private void OnDrawGizmos()
    {
        if (point.Length == 4)
        {
            Gizmos.DrawLine(point[0].position, point[1].position);
            Gizmos.DrawLine(point[2].position, point[3].position);
            Vector2 cross = VectorHelper.Intersect(point[0].position, point[1].position, point[2].position, point[3].position);
            Debug.Log(cross);
            Gizmos.DrawWireSphere(cross,1f);
        }
      
    }
  
}
