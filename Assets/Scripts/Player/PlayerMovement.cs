using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerInput playerInput;

    private float vertical;
    private float horizontal;
    private bool jump;

     public float defaultSpeed = 10f;
     public float defaultJumpForce = 5f;
    private float playerSpeed;
    private float jumpForce;
    

    public float PlayerSpeed
    {
        get => playerSpeed;
        set => playerSpeed = value;
    }

    public float JumpForce
    {
        get => jumpForce;
        set => jumpForce = value;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        playerInput.actions.Enable(); 
        SetPlayerJump(defaultJumpForce);
        SetPlayerSpeed(defaultSpeed);
    }

    void Update()
    {
        ReadInput();
    }

    void FixedUpdate()
    {
        MovePlayer();
        JumpPlayer();
    }

    void ReadInput()
    {
        Vector2 moveInput = playerInput.actions["Move"].ReadValue<Vector2>();
        vertical = moveInput.y;
        horizontal = moveInput.x;
        jump = playerInput.actions["Jump"].WasPressedThisFrame();
    }

    void MovePlayer()
    {
        Vector3 moveDirection = transform.right * horizontal + transform.forward * vertical;
        moveDirection.y = 0f; // prevent vertical movement
        moveDirection.Normalize();

        rb.MovePosition(rb.position + moveDirection * playerSpeed * Time.fixedDeltaTime);
        
    }

    void JumpPlayer()
    {
        if (jump && Mathf.Abs(rb.linearVelocity.y) < 0.01f) // prevent double jumps
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void SetPlayerSpeed(float speed)
    {
        PlayerSpeed = speed;
    }

    public void SetPlayerJump(float jump)
    {
        JumpForce = jump;
    }
}
