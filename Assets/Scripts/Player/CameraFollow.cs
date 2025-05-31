using UnityEngine;
using Unity.Cinemachine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player;
    private CinemachineCamera followCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // player = GameObject.FindGameObjectWithTag("Player");
        // followCamera = GetComponent<CinemachineCamera>();
        // followCamera.Follow = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
