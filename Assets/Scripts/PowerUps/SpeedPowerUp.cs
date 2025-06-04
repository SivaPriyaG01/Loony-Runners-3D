using System;
//using Unity.VisualScripting;
using UnityEngine;

public class SpeedPowerUp : PowerUpBase
{
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  public event Action<float,int> SpeedPowerUpEvent;
  private float newSpeed;
  public float NewSpeed
  {
    get => newSpeed;
    set => newSpeed = value;
  }

  private int speedPowerUpTime;

  public int SpeedPowerUpTime
  {
    get => speedPowerUpTime;
    set => speedPowerUpTime = value;
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      SpeedPowerUpEvent?.Invoke(NewSpeed,SpeedPowerUpTime);
      Destroy(gameObject);
    }
    }
}
