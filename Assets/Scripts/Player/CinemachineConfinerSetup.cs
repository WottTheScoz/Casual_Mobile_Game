using UnityEngine;
using Cinemachine;

public class CinemachineConfinerSetup : MonoBehaviour
{
    public Camera mainCamera;
    public Collider confinerCollider;

    private void Start()
    {
        // Create a new virtual camera
        GameObject virtualCameraObj = new GameObject("VirtualCamera");
        CinemachineVirtualCamera virtualCamera = virtualCameraObj.AddComponent<CinemachineVirtualCamera>();

        // Set the main camera as the target
        virtualCamera.Follow = transform; // Set to the object you want to follow
        virtualCamera.LookAt = transform; // Set to the object you want to look at

        // Create a new Confiner
        CinemachineConfiner confiner = virtualCameraObj.AddComponent<CinemachineConfiner>();
        confiner.m_BoundingShape2D = null; // Use 3D colliders
        confiner.m_BoundingVolume = confinerCollider; // Assign your collider here

        // Set the camera to be active
        virtualCamera.Priority = 10; // Ensure it's higher than any other camera if needed
    }
}
