using UnityEngine;

public class SpeedPowerUp : PowerUpBase
{
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  private int speedMultiplier = 2;
  public int SpeedMultiplier
  {
    get
    { return speedMultiplier; }

    set
    {
      speedMultiplier = value;
    }
  }

  private int speedPowerUpTime = 5;

  public int SpeedPowerUpTime
  {
    get { return speedPowerUpTime; }

    set
    {
      speedPowerUpTime = value;
    }
  }
}
