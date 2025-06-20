using System;
using UnityEngine;

public class LaunchAbilityObject : MonoBehaviour
{
    // public static event Action<GameObject> AssignAbility;
    AbilityUITriggerManager amScript;
    PlayerMovement playerMovement;
    
    //public static event Action StartRayCast;
    // public static event Action ThrowAbilityObject;

    private GameObject abilityObject;
    private Transform attackPoint;
    [SerializeField] private Transform cam;
    private float throwCoolDown = 2f;
    private float throwForce=10f;
    private float throwUpwardForce=10f;
    private bool readyToThrow=true;
    private float abilityObjectMass;
    private Vector3 forceDirection;
    private Vector3 forceToAdd;

    void Awake()
    {
        amScript = GameObject.Find("AbilityUITrigger").GetComponent<AbilityUITriggerManager>();
        playerMovement = GetComponent<PlayerMovement>();  
    }

    void Update()
    {
        attackPoint = gameObject.transform;
    }
    void OnEnable()
    {
        amScript.AssignAbility += AssignAbilityObject;
        amScript.StartRayCast += SetDirection;
        playerMovement.ThrowAbilityObject += Throw;

    }
    void OnDisable()
    {
        amScript.AssignAbility -= AssignAbilityObject;
        amScript.StartRayCast -= SetDirection;
        playerMovement.ThrowAbilityObject -= Throw;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void AssignAbilityObject(GameObject gameObject)
    {
        abilityObject = gameObject;
        abilityObjectMass = gameObject.GetComponent<Rigidbody>().mass;
    }

    void ProjectRayCast()
    {
        Debug.Log("Projectraycast invoked");

        if (cam == null)
    {
        Debug.LogError("Camera is not assigned!");
        return;
    }

    if (attackPoint == null)
    {
        Debug.LogError("Attack Point is not assigned!");
        return;
    }
        forceDirection = cam.transform.forward;
        RaycastHit hit;

        if (Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        }

        forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;
        Debug.DrawRay(attackPoint.position, forceToAdd.normalized*10f, Color.black,5f);
        Debug.Log("Force to add: " + forceToAdd);

    }

    void SetDirection()
    {
        Vector3 screenCentre = new Vector3(Screen.width / 2f, Screen.height / 2f, 0);
        Vector3 worldCentre = Camera.main.ScreenToWorldPoint(screenCentre);
        forceDirection = worldCentre;
        forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;
        Debug.Log("Direction setting complete");
    }

    void Throw()
    {
        if (abilityObject != null)
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
        else
        {
            Debug.Log("ABilityObject not assigned");
        }
       
    }
    
    private void ResetThrow()
    {
        readyToThrow = true;
    }
}
