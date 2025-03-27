using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onPlayerLose;
    [SerializeField]
    private UnityEvent<Transform> onObstacleDestroyed;
    [SerializeField]
    private UnityEvent<Transform> onCollisionDie;
    private Dash dash;

    private void Start()
    {
        dash = GetComponent<Dash>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacule"))
        {
            if (dash.IsDashing)
            {
                onObstacleDestroyed?.Invoke(transform);
                Destroy(collision.gameObject);
            }
            else
            {
                onCollisionDie?.Invoke(transform);
                onPlayerLose?.Invoke();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("DeadZone"))
        {
            onCollisionDie?.Invoke(transform);
            onPlayerLose?.Invoke();
            SoundManager.instance.Play("dead");
        }
    }
}
