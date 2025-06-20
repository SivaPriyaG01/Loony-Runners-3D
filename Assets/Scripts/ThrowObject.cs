using UnityEngine;
using UnityEngine.InputSystem;

public class ThrowObject : MonoBehaviour
{
    [SerializeField] GameObject objectToThrowPrefab;
    [SerializeField] float throwForce = 20f;
    //[SerializeField] Vector3 startPosition;
    Vector3 trajectoryDir;
    
    private GameObject spawnedObject;
    private Rigidbody spawnedRb;
    private PlayerInput playerInput;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        // Instantiate and store reference
        spawnedObject = Instantiate(objectToThrowPrefab, transform.position, Quaternion.identity);

        // Get and configure Rigidbody
        spawnedRb = spawnedObject.GetComponent<Rigidbody>();
        spawnedRb.useGravity = false;
        spawnedRb.isKinematic = true;
        trajectoryDir = new Vector3(spawnedRb.position.x, spawnedRb.position.y + 2, spawnedRb.position.z + 2);
    }

    void Update()
    {
        if (playerInput.actions["Attack"].WasPressedThisFrame())
        {
            FireObject();
        }
    }

    void FireObject()
    {
        if (spawnedRb == null) return;

        Debug.Log("Attack pressed");

        spawnedRb.useGravity = true;
        spawnedRb.isKinematic = false;
        spawnedRb.AddForce(trajectoryDir * throwForce, ForceMode.Impulse);
    }
}
