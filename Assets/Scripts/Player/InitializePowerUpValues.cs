using UnityEngine;

public class InitializePowerUpValues : MonoBehaviour
{
    private SpeedPowerUp speedPowerUp;
    private JumpPowerUp jumpPowerUp;
    private PlayerMovement playerMovement;

    private float speedmultiplier;

    public float SpeedMultiplier
    {
        get { return speedmultiplier; }
        set { speedmultiplier = value; }
    }

      private float jumpmultiplier;

    public float JumpMultiplier
    {
        get { return jumpmultiplier; }
        set { jumpmultiplier = value; }
    }

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        speedPowerUp = new SpeedPowerUp();
        jumpPowerUp = new JumpPowerUp();
        InitializePowerUps();
    }

    private void InitializePowerUps()
    {
        speedPowerUp.NewSpeed = playerMovement.defaultSpeed*SpeedMultiplier;
        jumpPowerUp.NewJumpValue = playerMovement.defaultJumpForce*JumpMultiplier; 
    }
}
