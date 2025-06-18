using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThrowObject : MonoBehaviour
{
    [SerializeField] GameObject objectToThrow;
    PlayerInput playerInput;
    [SerializeField] float throwForce=10f;
    [SerializeField] bool fire;
    [SerializeField] Vector3 startPosition;
    [SerializeField] Vector3 throwDirection;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
         rb = objectToThrow.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        fire = playerInput.actions["Attack"].WasPressedThisFrame();
        if (fire)
        {
            OnFireThrowObject();
        }
    }

    void OnFireThrowObject()
    {
        Instantiate(objectToThrow, startPosition, objectToThrow.transform.rotation);
        //rb.AddRelativeForce(throwDirection * throwForce, ForceMode.Impulse);
        rb.isKinematic = false;
        rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);
        
    }
}
