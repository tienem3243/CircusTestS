using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshPlay : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    Vector2[] vertices;

    public LineRenderer line;

    private void Awake()
    {
       
    }
    private void Start()
    {

        vertices = spriteRenderer.sprite.vertices;
        line.positionCount = vertices.Length;
    }
    private void Update()
    {
        for(int i=0;i<vertices.Length-1; i++)
        {
            line.SetPosition(i,vertices[i]);
        }
    }
}
