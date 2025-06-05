using System;
using UnityEngine;

public class JumpPowerUp : PowerUpBase
{
  public static event Action<float, int> PowerJump;
  private float jumpMultiplier=1.5f;
  public float JumpMultiplier
  {
    get
    { return jumpMultiplier; }
    set
    {
      jumpMultiplier = value;
    }
  }

  private int jumpPowerUpTime =5;

  public int JumpPowerUpTime
  {
    get { return jumpPowerUpTime; }

    set
    {
      jumpPowerUpTime = value;
    }
  }


  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      PowerJump?.Invoke(JumpMultiplier,JumpPowerUpTime);
      Destroy(gameObject);      
    }
    }

}
