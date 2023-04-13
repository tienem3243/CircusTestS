using UnityEngine;
using UnityEngine.Events;

namespace Manager
{
    public partial class GameManager : MonoBehaviourSingletonPersistent<GameManager>
    {

        public bool isWin = false;
        public bool isLose = false;
        public bool canCut;
        public int countStart = 0;
        public UnityEvent OnWin;
        public UnityEvent OnLose;
        public bool passMap = false;
        enum GameState { Win, Lose };

        private void Start()
        {
            canCut = true;
            if (OnWin == null) OnWin = new UnityEvent();
            if (OnLose == null) OnLose = new UnityEvent();
        }
        public void Win()
        {
            OnWin.Invoke();
            Debug.Log("Win");
        }
        public void Lose()
        {
            OnLose.Invoke();
            Debug.Log("Lose");
        }
    }
}



