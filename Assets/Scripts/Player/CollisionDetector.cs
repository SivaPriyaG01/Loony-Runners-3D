using System;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public event Action<int> SpeedPowerUp;
    public event Action<int> PowerJump;
    public event Action Obstacle;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SpeedPowerUp"))
        {
            int speedMultiplier = collision.gameObject.GetComponent<SpeedPowerUp>().SpeedMultiplier;
            SpeedPowerUp?.Invoke(speedMultiplier);
        }
        else if (collision.gameObject.CompareTag("JumpPowerUp"))
        {
            int jumpMultiplier = collision.gameObject.GetComponent<JumpPowerUp>().JumpMultiplier;
            PowerJump?.Invoke(jumpMultiplier);
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Obstacle?.Invoke();
        }

    }
}
