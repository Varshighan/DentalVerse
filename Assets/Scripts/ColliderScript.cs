using UnityEngine;
 // Ensure this matches the namespace of ToothExtractionController

public class ColliderScript : MonoBehaviour
{
    private ToothExtractionController controller;

    void Start()
    {
        controller = FindObjectOfType<ToothExtractionController>();
        if (controller == null)
        {
            Debug.LogError("ColliderScript could not find ToothExtractionController. Ensure it is in the scene.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Your collision logic here
        if (other.CompareTag("Tool")) // Assuming tools have a tag "Tool"
        {
            controller.OnToolUsed(other.gameObject);
        }
    }
}