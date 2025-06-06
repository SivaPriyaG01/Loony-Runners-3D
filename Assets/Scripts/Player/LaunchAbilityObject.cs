using System;
using UnityEngine;

public class LaunchAbilityObject : MonoBehaviour
{
    public static event Action<GameObject> AssignPowerUp;
    public static event Action StartRayCast;
    public static event Action ThrowAbilityObject;

    private GameObject abilityObject;
    private Transform attackPoint;
    private Transform cam;
    private float throwCoolDown;
    private float throwForce;
    private float throeUpwardForce;
    private bool readyToThrow;
    void OnEnable()
    {

    }
    void OnDisable()
    {

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    
}
