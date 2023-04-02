using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
  enum GameState { Win,Lose};
    public UnityEvent OnWin;
    public UnityEvent OnLose;
    private void Start()
    {
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
