using UnityEngine;

public class MenuCameraScript: MonoBehaviour
{
    public Transform target;  // The target object to rotate around
    public float rotationSpeed = 10.0f;  // Speed of rotation

    void Update()
    {
        // Check if a target object is assigned
        if (target != null)
        {
            // Rotate the camera around the target object
            transform.RotateAround(target.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}