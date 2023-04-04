using UnityEngine;
using UnityEngine.Events;

public class GameManger : MonoBehaviourSingleton<GameManger>
{
  
    public bool isWin = false;
    public bool isLose = false;
    public bool canCut;
    public int countStart = 0;
    public UnityEvent OnWin;
    public UnityEvent OnLose;

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


