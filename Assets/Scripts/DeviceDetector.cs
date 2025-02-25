using UnityEngine;
using UnityEngine.Events;

public class DeviceDetector : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onDeskop;

    [SerializeField]
    private UnityEvent onMobile;

    private void Start()
    {
        if(Application.isMobilePlatform)
        {
            onMobile?.Invoke();
        }
        else
        {
            onDeskop?.Invoke();
        }
    }
}
