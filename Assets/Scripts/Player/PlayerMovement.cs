using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody rb;
    private PlayerInput playerInput;

    float vertical;
    float horizontal;
    bool jump;

    private int playerSpeed;
    public int PlayerSpeed
    {
        get => playerSpeed;
        set
        {
            playerSpeed += value;
        }
    }

    private int jumpForce;
    public int JumpForce
    {
        get => jumpForce;
        set
        {
            jumpForce += value;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }

    void FixedUpdate()
    {
        MovePlayer();
        JumpPlayer();
    }

    void PlayerInput()
    {
        vertical = playerInput.actions["Move"].ReadValue<Vector2>().x;
        horizontal = playerInput.actions["Move"].ReadValue<Vector2>().y;
        jump = playerInput.actions["Jump"].WasPressedThisFrame();
    }

    void MovePlayer()
    {
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
        rb.MovePosition(moveDirection*playerSpeed);
    }

    void JumpPlayer()
    {
        rb.AddForce(Vector3.up*JumpForce, ForceMode.Impulse);
    }
}
