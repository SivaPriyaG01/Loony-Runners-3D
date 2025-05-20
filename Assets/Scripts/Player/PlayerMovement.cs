using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody rb;
    
    private int playerSpeed;
    public int PlayerSpeed
    {
        get => playerSpeed;
        set
        {
            playerSpeed += value;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void PlayerInput()
    {

    }

    void MovePlayer()
    {

    }
}
