using UnityEngine;

public class SpeedPowerUp : PowerUpBase
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int speedMultiplier = 2;
    public int SpeedMultiplier
    {
        get
        { return speedMultiplier; }

        set{}
    }
}
