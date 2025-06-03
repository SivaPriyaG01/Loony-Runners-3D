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
  private float jumpmultiplier;

  public float JumpMultiplier
  {
    get { return jumpmultiplier; }
    set { jumpmultiplier = value; }
  }
}
