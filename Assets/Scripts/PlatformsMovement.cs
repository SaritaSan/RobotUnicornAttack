using System;
using UnityEngine;
using UnityEngine.Events;

public class PlatformsMovement : MonoBehaviour
{
    [SerializeField]
    private float initialSpeed = 2f;

    [SerializeField]
    private float speedIncrease = 0.1f;
    [SerializeField]
    private UnityEvent<int> onScoreChanged;

    private bool canMove = true;

    public bool CanMove { set => canMove = value; }
    private Vector3 startingPosition;

    private float speed;
    private Vector3 moveDistance;

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
        Vector3 distanceToMove = Vector3.left * speed * Time.deltaTime;
        transform.position += distanceToMove;
        moveDistance += distanceToMove;
        onScoreChanged?.Invoke(Math.Abs((int)moveDistance.x));
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
        moveDistance = Vector3.zero;
        StartMovement();
    }
}
