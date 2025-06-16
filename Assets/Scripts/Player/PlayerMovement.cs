using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;
using Unity.VisualScripting;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerInput playerInput;
    public event Action ThrowAbilityObject;
    

    private float vertical;
    private float horizontal;
    private bool jump;
    private bool fire;

    public float defaultSpeed = 10f;
    public float defaultJumpForce = 20f;
    private float playerSpeed = 1f;
    private float jumpForce = 1f;
    private float maxPlayerSpeed = 40f;
    private float maxJumpForce = 15f;

    public float DefaultSpeed
    {
        get => defaultSpeed;
        set => defaultSpeed = value;
    }
    public float DefaultJumpForce
    {
        get => defaultJumpForce;
        set => defaultJumpForce = value;
    }
    public float PlayerSpeed
    {
        get => playerSpeed;
        set
        {
            playerSpeed *= value;
            playerSpeed = Mathf.Min(playerSpeed, maxPlayerSpeed);
        }
    }

    public float JumpForce
    {
        get => jumpForce;
        set
        {
            jumpForce *= value;
            jumpForce = Mathf.Min(jumpForce, maxJumpForce);
        } 
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
        FireAbility();
    }

    void ReadInput()
    {
        Vector2 moveInput = playerInput.actions["Move"].ReadValue<Vector2>();
        vertical = moveInput.y;
        horizontal = moveInput.x;
        jump = playerInput.actions["Jump"].WasPressedThisFrame();
        fire = playerInput.actions["Attack"].WasPressedThisFrame();

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
    void FireAbility()
    {
        if (fire)
        {
            Debug.Log("Fire pressed");
            ThrowAbilityObject?.Invoke();
        }
    }

    public void SetPlayerSpeed(float speedMultiplier)
    {
        PlayerSpeed = speedMultiplier;
    }

    public void SetPlayerJump(float jumpMultiplier)
    {
        JumpForce = jumpMultiplier;
    }
    

}
