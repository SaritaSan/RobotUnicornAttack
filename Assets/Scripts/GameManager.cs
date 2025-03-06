using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onGameStart;
    [SerializeField]
    private UnityEvent onRespawnGame;
    [SerializeField]
    private float secondsToRestart = 3f;

    void Start()
    {
        onGameStart?.Invoke();
    }

    public void PlayerLose()
    {
        Invoke(nameof(RestartGame), secondsToRestart);
    }

    private void RestartGame()
    {
        onRespawnGame?.Invoke();
    }
}
