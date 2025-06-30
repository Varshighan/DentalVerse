using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSelector : MonoBehaviour
{
    public Camera mainCamera; // Assign your main camera in the Inspector
    public Transform handTransform; // The hand or parent object
    private GameObject currentTool; // The tool currently grabbed

    void Update()
    {
        // Detect left mouse button click
        if (Input.GetMouseButtonDown(0)) // Left-click
        {
            if (currentTool == null)
            {
                TryGrabTool(); // Try to pick up a tool
            }
        }

        // Detect right mouse button click to release the current tool
        if (Input.GetMouseButtonDown(1)) // Right-click
        {
            if (currentTool != null)
            {
                ReleaseTool(); // Release the currently grabbed tool
            }
        }
    }

    void TryGrabTool()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); // Ray from camera to mouse position
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Check if the hit object is a tool
            if (hit.collider.CompareTag("DentalTool")) // Make sure tools have the "DentalTool" tag
            {
                currentTool = hit.collider.gameObject; // Store the selected tool

                // Enable the FollowMouse script for this tool
                currentTool.GetComponent<FollowMouse>().enabled = true;

                // Optionally parent the tool to the hand
                currentTool.transform.SetParent(handTransform);

                Debug.Log("Grabbed Tool: " + currentTool.name);
            }
        }
    }

    void ReleaseTool()
    {
        // Disable the FollowMouse script for the current tool
        currentTool.GetComponent<FollowMouse>().enabled = false;

        // Detach the tool from the hand
        currentTool.transform.SetParent(null);

        Debug.Log("Released Tool: " + currentTool.name);
        currentTool = null; // Reset the current tool reference
    }
}
