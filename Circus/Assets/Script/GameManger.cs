using UnityEngine;
using UnityEngine.Events;

public class GameManger : MonoBehaviour
{
    public static GameManger Instance;
    public bool isWin = false;
    public bool isLose = false;
    public bool canCut;
    public int countStart = 0;
    public UnityEvent OnWin;
    public UnityEvent OnLose;
    protected virtual void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
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


