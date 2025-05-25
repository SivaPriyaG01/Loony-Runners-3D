using Unity.VisualScripting;
using UnityEngine;

public class ApplyPowerUp : MonoBehaviour
{
    CollisionDetector collisionDetector;
    void OnEnable()
    {
        collisionDetector.SpeedPowerUp += BoostPlayerSpeed;
    }
    public void BoostPlayerSpeed()
    {
        
    }
}
