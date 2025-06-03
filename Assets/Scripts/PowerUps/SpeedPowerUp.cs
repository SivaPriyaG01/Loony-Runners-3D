using UnityEngine;

public class SpeedPowerUp : PowerUpBase
{
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  private float newSpeed;
  public float NewSpeed
  {
    get
    { return newSpeed; }

    set
    {
      newSpeed = value;
    }
  }

  private int speedPowerUpTime;

  public int SpeedPowerUpTime
  {
    get { return speedPowerUpTime; }

    set
    {
      speedPowerUpTime = value;
    }
  }

  private float multiplier;

  public float Multiplier
  {
    get { return multiplier; }
    set { multiplier = value; }
  }
}
