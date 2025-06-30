using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public Camera mainCamera; // Assign your main camera in the Inspector
    public float depth = 5f; // Depth where the object moves

    void Update()
    {
        if (!mainCamera) return; // Ensure the camera is assigned

        // Get the mouse position in screen space
        Vector3 mousePosition = Input.mousePosition;

        // Convert to world space and move the object
        mousePosition.z = depth;
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

        // Update the object's position
        transform.position = worldPosition;
    }
}
