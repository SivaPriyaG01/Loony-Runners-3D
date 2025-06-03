using System;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public event Action<int,int> SpeedPowerUp;
    public event Action<int,int> PowerJump;
    public event Action Obstacle;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpeedPowerUp"))
        {
            Debug.Log("Coollided with speed power up");
            var speedComponent = other.gameObject.GetComponent<SpeedPowerUp>();
            int newSpeed = speedComponent.NewSpeed;
            int speedTime = speedComponent.SpeedPowerUpTime;
            SpeedPowerUp?.Invoke(newSpeed,speedTime);
        }
        else if (other.gameObject.CompareTag("JumpPowerUp"))
        {
            Debug.Log("Coollided with jump power up");
            var jumpComponent = other.gameObject.GetComponent<JumpPowerUp>();
            int newJumpVal = jumpComponent.NewJumpValue;
            int jumpTime = jumpComponent.JumpPowerUpTime;
            PowerJump?.Invoke(newJumpVal,jumpTime);
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            Obstacle?.Invoke();
        }

    }

    
}
