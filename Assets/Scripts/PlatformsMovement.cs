using UnityEngine;

public class PlatformsMovement : MonoBehaviour
{
    [SerializeField]
    private float initialSpeed = 2f;

    [SerializeField]
    private float speedIncrease = 0.1f;

    private bool canMove = true;

    public bool CanMove { set => canMove = value; }
    private Vector3 startingPosition;

    private float speed;

    private void Start()
    {
        startingPosition = transform.position;
        speed = initialSpeed;
    }

    private void Update()
    {
        if(canMove)
        {
            MovePlatforms();
        }
    }

    private void MovePlatforms()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    public void IncreaseSpeed()
    {
        speed += speedIncrease;
    }

    public void StopMovement()
    {
        canMove = false;
    }

    public void StartMovement()
    {
        canMove = true;
    }

    public void Restart()
    {
        transform.position = startingPosition;
        speed = initialSpeed;
        StartMovement();
    }
}
