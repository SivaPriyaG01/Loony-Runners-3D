using System;
using UnityEngine;

public class JumpPowerUp : PowerUpBase
{
  public static event Action<float, int> PowerJump;
  private float newJumpValue;
  public float NewJumpValue
  {
    get
    { return newJumpValue; }
    set
    {
      newJumpValue = value;
    }
  }

  private int jumpPowerUpTime;

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
      PowerJump?.Invoke(NewJumpValue,JumpPowerUpTime);
      Destroy(gameObject);      
    }
    }

}
