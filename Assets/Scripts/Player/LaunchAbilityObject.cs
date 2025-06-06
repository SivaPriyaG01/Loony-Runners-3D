using System;
using UnityEngine;

public class LaunchAbilityObject : MonoBehaviour
{
    public static event Action<GameObject> AssignAbility;
    public static event Action StartRayCast;
    public static event Action ThrowAbilityObject;

    private GameObject abilityObject;
    private Transform attackPoint;
    private Transform cam;
    private float throwCoolDown;
    private float throwForce;
    private float throeUpwardForce;
    private bool readyToThrow;
    private float abilityObjectMass;
    void OnEnable()
    {
        AssignAbility += AssignAbilityObject;
        StartRayCast += ProjectRayCast;
        ThrowAbilityObject += Throw;

    }
    void OnDisable()
    {
        AssignAbility -= AssignAbilityObject;
        StartRayCast -= ProjectRayCast;
        ThrowAbilityObject -= Throw;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void AssignAbilityObject(GameObject gameObject)
    {
        abilityObject = gameObject;
        abilityObjectMass = gameObject.GetComponent<Rigidbody>().mass;
    }

    void ProjectRayCast()
    {

    }

    void Throw()
    {

    }
}
