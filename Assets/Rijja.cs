using UnityEngine;
using TMPro;
using System.Collections;

public class Rijja : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    void Start()
    {
        if (dialogueText != null)
        {
            dialogueText.text = ""; 
        }
    }

    void OnMouseDown()
    {
        if (dialogueText != null)
        {
            string objectName = gameObject.name;
            string description = "";

            // Internal Tooth Structures
            if (objectName == "Enamel")
                description = "The hardest, outermost layer of the tooth. Protects inner layers from decay and damage.";
            else if (objectName == "Dentin")
                description = "Softer than enamel but strong. Contains tiny tubules that allow sensations to reach the nerve.";
            else if (objectName == "Pulp")
                description = "The soft inner tissue of the tooth containing nerves and blood vessels.";
            else if (objectName == "Nerve")
                description = "Carries signals to and from the brain, providing sensation such as pain and temperature.";
            else if (objectName == "Blood Vessel")
                description = "Supplies oxygen and nutrients to the tooth, keeping it alive and healthy.";

            // Default message if the structure is not found
            else
                description = "No information available.";

            // Display the description
            dialogueText.text = $"Structure: {objectName}\nInfo: {description}";
            Debug.Log(description);

            StartCoroutine(HideTextAfterDelay());
        }
    }

    IEnumerator HideTextAfterDelay()
    {
        yield return new WaitForSeconds(10f);
        if (dialogueText != null)
        {
            dialogueText.text = ""; 
        }
    }
}


