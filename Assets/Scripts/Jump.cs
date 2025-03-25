using UnityEngine;
using UnityEngine.Events;

public class Jump : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 5f;

    [SerializeField]
    private float maxJumpTime = 0.3f;

    [SerializeField]
    private float jumpBoost = 0.5f;

    [SerializeField]
    private int maxJumps = 2;
    [SerializeField]
    private UnityEvent onJump;
    [SerializeField]
    private UnityEvent onLand;
    private int jumps;

    private Rigidbody rb;
    private bool isGrounded;
    private bool isJumping;
    private float jumpTimeCounter;
    private bool buttonPressed;
    private bool canJump = true;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void SetCanJump(bool value)
    {
        canJump = value;
        RestartJump();
        isGrounded = true;
    }

    private void RestartJump()
    {
        jumps = maxJumps;
    }
    public void StartJump()
    {
        if(!canJump)
        {
            return;
        }

        buttonPressed = true;
        
        if (isGrounded || jumps > 0)
        {
            onJump?.Invoke();
            jumps--;
            isJumping = true;
            jumpTimeCounter = maxJumpTime;
            rb.linearVelocity = Vector3.up * jumpForce;
            isGrounded = false;
        }
    }

    public void EndJump()
    {
        buttonPressed = false;
        isJumping = false;
    }

    private void FixedUpdate()
    {
        HandleJump();
    }

    private void HandleJump()
    {
        if(buttonPressed && isJumping)
        {
            rb.linearVelocity = Vector3.up * (jumpForce + jumpBoost);
            jumpTimeCounter -= Time.deltaTime;
        }
        else
        {
            isJumping = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            RestartJump();
            isGrounded = true;
            onLand?.Invoke();
        }
    }
}
