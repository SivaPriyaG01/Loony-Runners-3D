using System;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public event Action SpeedPowerUp;
    public event Action PowerJump;
    public event Action Obstacle;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SpeedPowerUp"))
        {
            SpeedPowerUp?.Invoke();
        }
        else if (collision.gameObject.CompareTag("PowerJump"))
        {
            PowerJump?.Invoke();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Obstacle?.Invoke();
        }

    }
}
