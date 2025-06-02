using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ApplyPowerUp : MonoBehaviour
{
    CollisionDetector collisionDetector;
    PlayerMovement playerMovement;
    // int speedPowerUpValue;
    // int jumpPowerUpValue;
    void OnEnable()
    {
        collisionDetector.SpeedPowerUp += BoostPlayerSpeed;
        collisionDetector.PowerJump += BoostPlayerJump;
    }

    void OnDisable()
    {
        collisionDetector.SpeedPowerUp -= BoostPlayerSpeed;
        collisionDetector.PowerJump -= BoostPlayerJump;
    }

    void Awake()
    {
        collisionDetector = GetComponent<CollisionDetector>();
        playerMovement = GetComponent<PlayerMovement>();
    }
    public void BoostPlayerSpeed(int value, int time)
    {
        ApplySpeedPowerUp(value, time);
        playerMovement.SetPlayerSpeed(playerMovement.defaultSpeed);
    }
    public void BoostPlayerJump(int value, int time)
    {
        ApplyJumpPowerUp(value, time);
        playerMovement.SetPlayerJump(playerMovement.defaultJumpForce);
    }

    IEnumerator ApplySpeedPowerUp(int value, int time)
    {
        playerMovement.SetPlayerSpeed(value);
        yield return new WaitForSecondsRealtime(time);
    }
    
    IEnumerator ApplyJumpPowerUp(int value, int time)
    {
        playerMovement.SetPlayerSpeed(value);
        yield return new WaitForSecondsRealtime(time);
    }

}
