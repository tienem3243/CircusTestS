using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slicer2D;
using Utilities2D;
using DG.Tweening;
namespace InteractiveObj
{
    public class BreakEffect : MonoBehaviour
    {
        public List<Transform> listSlice;
        public Sliceable2D sliceableObj;
        List<Vector2D> sliceNode;
        public Rigidbody2D rib;
        private void Start()
        {
            sliceNode = new();
            rib.simulated = false;


        }
        [ContextMenu("slice")]
        public void Break()
        {
            if (rib == null) return;
            rib.simulated = true;
            Slicer2D.Debug.Log("Slice");

            foreach (var x in listSlice)
            {
                sliceNode.Add(new Vector2D(x.position));
            }

            sliceableObj.AddEvent((Slice2D s) => {
                List<GameObject> gameObjects = s.GetGameObjects();
                foreach (var x in gameObjects)
                {

                }
                return true;
            });
            sliceableObj.ComplexSlice(sliceNode);
        }

    }
}

