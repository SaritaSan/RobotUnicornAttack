using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onGameStart;
    [SerializeField]
    private UnityEvent onRespawnGame;
    [SerializeField]
    private UnityEvent onFinishGame;
    [SerializeField]
    private UnityEvent onLoseGame;
    [SerializeField]
    private UnityEvent onShowGameOverScreen;
    [SerializeField]
    private float secondsToRestart = 3f;
    [SerializeField]
    private float finalSecondToRestart = 5f;
    [SerializeField]
    private float secondsToShowGameOverScreen = 3f;

    void Awake()
    {
        secondsToRestart += secondsToShowGameOverScreen;
        finalSecondToRestart += secondsToShowGameOverScreen;
    }

    void Start()
    {
        onGameStart?.Invoke();
    }

    public void LoseGame()
    {
        onLoseGame?.Invoke();
        Invoke("ShowGameOverScreen", secondsToShowGameOverScreen);

    }

    private void ShowGameOverScreen()
    {
        onShowGameOverScreen?.Invoke();
    }

    public void RespawnGame()
    {
        Invoke("RestartGame", secondsToRestart);
    }

    public void FinishGame()
    {
        onFinishGame?.Invoke();
        Invoke("Start", finalSecondToRestart);
        Invoke("RestartGame", finalSecondToRestart);
    }

    private void RestartGame()
    {
        onRespawnGame?.Invoke();
    }
}
