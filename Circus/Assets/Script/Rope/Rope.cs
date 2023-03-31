using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Rope : MonoBehaviour
{

	public Rigidbody2D hook;

	public GameObject linkPrefab;

	public Weight weigth;

	public int links = 7;
	public LineRenderer line;
	private List<Link> ropeNodes;
	private  Rope instance;

    public Rope Instance { get => instance; set => instance = value; }

    void Start()
	{
		instance = this;
		ropeNodes = new List<Link>();
		GenerateRope();
	}
    private void Update()
    {
		DrawRope();
    }

    private void DrawRope()
    {
		
		if (ropeNodes.Count > 0)
        {
			line.positionCount = ropeNodes.Count;

			for (int i = 0; i < ropeNodes.Count; i++)
            {
				line.SetPosition(i,ropeNodes[i].transform.position);
			}
			
        }
    }

    void GenerateRope()
	{
		Rigidbody2D previousRB = hook;
		for (int i = 0; i < links; i++)
		{
			GameObject link = Instantiate(linkPrefab, transform);
			HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
			joint.connectedBody = previousRB;

			if (i < links - 1)
			{
				previousRB = link.GetComponent<Rigidbody2D>();
			}
			else
			{
				weigth.ConnectRopeEnd(link.GetComponent<Rigidbody2D>());
			}
			Link CurrentLink=	link.GetComponent<Link>();
			CurrentLink.index = i;
		
			CurrentLink.remove += (int i) =>
			{
				
                if (ropeNodes.Count >= i)
                {			
					ropeNodes.RemoveRange(i, ropeNodes.Count - i);

					/*CleanTheCut(this);*/
				}
				
			};
			ropeNodes.Add(CurrentLink);
			
		}

	}
	private void CleanTheCut(Rope rope)
	{
		rope.Instance.ropeNodes.Clear();
		rope.Instance.line.positionCount = 0;
	}
   

}