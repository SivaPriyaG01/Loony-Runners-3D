using UnityEngine;

public class JumpPowerUp : PowerUpBase
{
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

  PlayerMovement playerMovement;
  private float multiplier = 1.5f;

  void Awake()
  {
    NewJumpValue = playerMovement.defaultJumpForce * multiplier;
    //Implement a script to assign time value
  }
}
