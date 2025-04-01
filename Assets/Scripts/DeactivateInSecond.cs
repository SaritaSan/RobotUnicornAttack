using UnityEngine;
using UnityEngine.Events;

public class DeactivateInSecond : MonoBehaviour
{
    [SerializeField]
    private float secondsToDeactivate = 5f;

    private void OnEnable()
    {
        Invoke("Deactivate", secondsToDeactivate);
    }

    private void DeactivateObject()
    {
        gameObject.SetActive(false);
    }

}
