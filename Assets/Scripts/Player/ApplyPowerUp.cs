using Unity.VisualScripting;
using UnityEngine;

public class ApplyPowerUp : MonoBehaviour
{
    CollisionDetector collisionDetector;
    PlayerMovement playerMovement;
    int speedPowerUpValue;
    int jumpPowerUpValue;
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
        collisionDetector=GetComponent<CollisionDetector>();
        playerMovement = GetComponent<PlayerMovement>();
    }
    public void BoostPlayerSpeed()
    {
        playerMovement.SetPlayerSpeed(speedPowerUpValue);
    }
    public void BoostPlayerJump()
    {
        playerMovement.SetPlayerJump(jumpPowerUpValue);
    }
}
