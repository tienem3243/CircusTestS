using Slicer2D;
using UnityEngine;
using UnityEngine.Events;

public class Weight : MonoBehaviour
{
	public UnityEvent OnBreaking;
	public float distanceFromChainEnd = 0.6f;
    public BreakEffect breakAbleObject;
    private Rigidbody2D rig;

    public Rigidbody2D Rig { get => rig; set => rig = value; }

    private void Start()
    {
        if (OnBreaking == null)
        {
			OnBreaking = new UnityEvent();
        }
        Rig = GetComponent<Rigidbody2D>();
        BreakEffect obj = Instantiate(breakAbleObject.gameObject, transform).GetComponent<BreakEffect>();
        obj.GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        OnBreaking.AddListener(() =>
        {
            obj.transform.parent = null;
            obj.gameObject.GetComponent<Rigidbody2D>().velocity = Rig.velocity;
            obj.Break();
            gameObject.SetActive(false);
        });
    }
    public void ConnectRopeEnd(Rigidbody2D endRB)
	{
		HingeJoint2D joint = gameObject.AddComponent<HingeJoint2D>();
		joint.autoConfigureConnectedAnchor = false;
		joint.connectedBody = endRB;
		joint.anchor = Vector2.zero;
		joint.connectedAnchor = new Vector2(0f, -distanceFromChainEnd);
	}

   
}