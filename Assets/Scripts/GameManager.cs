using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onGameStart;

    void Start()
    {
        onGameStart?.Invoke();
    }
}
