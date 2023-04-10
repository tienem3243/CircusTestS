
using UnityEngine;
using Manager;
namespace Character.MoveCharacter {
    public partial class MoveCharacter : MonoBehaviour
    {
        [Header("Move Character")]
        [SerializeField] protected bool isfaceRight = false;
        [SerializeField] protected float moveSpeed = 2.0f;
        [SerializeField] protected float xRange = 3.0f;
        [SerializeField] protected bool moveRight;
        protected Vector3 starPos;
        protected virtual void Start()
        {
            this.starPos = transform.position;
        }

        protected virtual void FixedUpdate()
        {
            this.Move();
            this.FlipCharc();
        }
        protected virtual void Move()
        {
            if (GameManger.Instance.isWin || GameManger.Instance.isLose) return;
            if (Turn())
            {
                transform.parent.Translate(Vector2.right * Time.fixedDeltaTime * moveSpeed);
            }
            else
            {
                transform.parent.Translate(Vector2.left * Time.fixedDeltaTime * moveSpeed);
            }
        }
        protected virtual bool Turn()
        {
            if (transform.parent.position.x > starPos.x + xRange)
            {
                moveRight = false;
            }
            if (transform.parent.position.x < starPos.x - xRange)
            {
                moveRight = true;
            }
            return moveRight;
        }
        protected virtual void FlipCharc()
        {
            if (!Turn() && isfaceRight || Turn() && !isfaceRight)
            {
                isfaceRight = !isfaceRight;
                Vector3 LocalScale = transform.parent.localScale;
                LocalScale.x = LocalScale.x * -1;
                transform.parent.localScale = LocalScale;
            }
        }
    }
}


