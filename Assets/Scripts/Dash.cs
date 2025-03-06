using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class Dash : MonoBehaviour
{
    [SerializeField]
    private float duration = 1f;
    [SerializeField]
    private float inactiveDuration = 2f;
    [SerializeField]
    private UnityEvent onDash;
    [SerializeField]
    private UnityEvent onStopDash;
    private bool canDash = true;
    private bool isDashing;
    public bool IsDashing { get => isDashing; }
    private bool dashEnable = true;

    public void SetDashEnable(bool enable)
    {
        dashEnable = enable;
    }

    public void DashAction()
    {
        if(!isDashing && canDash && dashEnable)
        {
            canDash = false;
            onDash?.Invoke();
            isDashing = true;
            Invoke(nameof(StopDash), duration);
        }

    }

    private void StopDash()
    {
        onStopDash?.Invoke();
        isDashing = false;
        Invoke(nameof(EnableDash), inactiveDuration);
    }

    private void EnableDash()
    {
        canDash = true;
    } 

}
