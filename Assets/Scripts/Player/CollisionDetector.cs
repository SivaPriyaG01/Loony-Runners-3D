using System;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public event Action<int,int> SpeedPowerUp;
    public event Action<int,int> PowerJump;
    public event Action Obstacle;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SpeedPowerUp"))
        {
            var speedComponent = collision.gameObject.GetComponent<SpeedPowerUp>();
            int speedMultiplier = speedComponent.SpeedMultiplier;
            int speedTime = speedComponent.SpeedPowerUpTime;
            SpeedPowerUp?.Invoke(speedMultiplier,speedTime);
        }
        else if (collision.gameObject.CompareTag("JumpPowerUp"))
        {
            var jumpComponent = collision.gameObject.GetComponent<JumpPowerUp>();
            int jumpMultiplier = jumpComponent.JumpMultiplier;
            int jumpTime = jumpComponent.JumpPowerUpTime;
            PowerJump?.Invoke(jumpMultiplier,jumpTime);
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Obstacle?.Invoke();
        }

    }
}
