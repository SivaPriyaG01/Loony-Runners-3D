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

  PlayerMovement playerMovement;
  private float multiplier = 1.5f;
  void Awake()
  {
    playerMovement = GetComponent<PlayerMovement>();
    NewSpeed = playerMovement.defaultSpeed * multiplier;
    //Implement a script to assign time value
  }

}
