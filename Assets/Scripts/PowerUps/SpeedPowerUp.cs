using System;
//using Unity.VisualScripting;
using UnityEngine;

public class SpeedPowerUp : PowerUpBase
{
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  public static event Action<float,int> SpeedPowerUpEvent;
  private float speedMultiplier=1.5f;
  public float SpeedMultiplier
  {
    get => speedMultiplier;
    set => speedMultiplier= value;
  }

  private int speedPowerUpTime=5;

  public int SpeedPowerUpTime
  {
    get => speedPowerUpTime;
    set => speedPowerUpTime = value;
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      SpeedPowerUpEvent?.Invoke(SpeedMultiplier,SpeedPowerUpTime);
      Destroy(gameObject);
    }
    }
}
