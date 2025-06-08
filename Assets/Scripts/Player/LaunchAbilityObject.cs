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
    private float throwCoolDown = 2f;
    private float throwForce;
    private float throwUpwardForce;
    private bool readyToThrow=true;
    private float abilityObjectMass;
    private Vector3 forceDirection;
    private Vector3 forceToAdd;
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
        forceDirection = cam.transform.forward;
        RaycastHit hit;

        if (Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        }

        forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;
        Debug.DrawRay(attackPoint.position,forceToAdd);
    }

    void Throw()
    {
        readyToThrow = false;
        GameObject projectile = Instantiate(abilityObject, attackPoint.position, cam.rotation);

        // get rigidbody component
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        // calculate direction
       // Vector3 forceDirection = cam.transform.forward;

        // add force
        //Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        // implement throwCooldown
        Invoke(nameof(ResetThrow), throwCoolDown);
    }
    
    private void ResetThrow()
    {
        readyToThrow = true;
    }
}
