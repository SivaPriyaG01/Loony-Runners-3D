using System;
using System.Collections;
//using Unity.VisualScripting;
using UnityEngine;

public class ApplyPowerUp : MonoBehaviour
{
    //CollisionDetector collisionDetector;
    // SpeedPowerUp speedPowerUp;
    // JumpPowerUp jumpPowerUp;
    PlayerMovement playerMovement;

    // public event Action<float,int> SpeedPowerUpEvent;
    // public event Action<float, int> PowerJump;

    void OnEnable()
    {
        SpeedPowerUp.SpeedPowerUpEvent += BoostPlayerSpeed;
        JumpPowerUp.PowerJump += BoostPlayerJump;
    }

    void OnDisable()
    {
         SpeedPowerUp.SpeedPowerUpEvent -= BoostPlayerSpeed;
        JumpPowerUp.PowerJump -= BoostPlayerJump;
    }

    void Awake()
    {
        //collisionDetector = GetComponent<CollisionDetector>();
        playerMovement = GetComponent<PlayerMovement>();
        // speedPowerUp = new SpeedPowerUp();
        // jumpPowerUp = new JumpPowerUp();

        // if (speedPowerUp != null && jumpPowerUp != null)
        // {
        //     // speedPowerUp.SpeedPowerUpEvent += BoostPlayerSpeed;
        //     // jumpPowerUp.PowerJump += BoostPlayerJump;
        // }

        // SpeedPowerUpEvent += BoostPlayerSpeed;
        // PowerJump += BoostPlayerJump;
    }

    // void OnDestroy()
    // {
    //     // if (speedPowerUp!= null && jumpPowerUp != null)
    //     // {
    //     //     speedPowerUp.SpeedPowerUpEvent -= BoostPlayerSpeed;
    //     //     jumpPowerUp.PowerJump -= BoostPlayerJump;
    //     // }

    //     SpeedPowerUpEvent -= BoostPlayerSpeed;
    //     PowerJump -= BoostPlayerJump;
    // }

    public void BoostPlayerSpeed(float value, int time)
    {
        StartCoroutine(ApplySpeedPowerUp(value, time));
       
        Debug.Log("Speed power Up ended");
    }
    public void BoostPlayerJump(float value, int time)
    {
        StartCoroutine(ApplyJumpPowerUp(value, time));
        
        Debug.Log("Jump power Up ended");
    }

    IEnumerator ApplySpeedPowerUp(float value, int time)
    {
        playerMovement.SetPlayerSpeed(value);
        Debug.Log("Speed power Up applied");
        yield return new WaitForSecondsRealtime(time);

        //  playerMovement.SetPlayerSpeed(playerMovement.defaultSpeed);
        playerMovement.SetPlayerSpeed(1/value);
    }

    IEnumerator ApplyJumpPowerUp(float value, int time)
    {
        playerMovement.SetPlayerJump(value);
        Debug.Log("Jump power Up applied");
        yield return new WaitForSecondsRealtime(time);

        //playerMovement.SetPlayerJump(playerMovement.defaultJumpForce);
        playerMovement.SetPlayerJump(1 / value);
    }

}
