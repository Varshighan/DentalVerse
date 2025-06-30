using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomwithController : MonoBehaviour
{
    public Transform targetToZoom;  // Drag your canvas or 3D object here
    public float zoomSpeed = 1.5f;
    public float minDistance = 0.5f;
    public float maxDistance = 5.0f;

    private Transform cameraTransform;

    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        // Get input from secondary thumbstick (right joystick vertical)
        float zoomInput = Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical");

        if (zoomInput != 0)
        {
            Vector3 direction = (targetToZoom.position - cameraTransform.position).normalized;
            float distance = Vector3.Distance(cameraTransform.position, targetToZoom.position);
            float moveAmount = zoomInput * zoomSpeed * Time.deltaTime;

            // Clamp within min/max range
            if ((zoomInput > 0 && distance > minDistance) || (zoomInput < 0 && distance < maxDistance))
            {
                targetToZoom.position -= direction * moveAmount;
            }
        }
    }
}