/*

using UnityEngine;
using TMPro;
using System.Collections;

public class saathviga : MonoBehaviour
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
            dialogueText.text = "This is " + objectName;
            Debug.Log("Clicked: " + objectName); 

            StartCoroutine(HideTextAfterDelay());
        }
    }

    IEnumerator HideTextAfterDelay()
    {
        yield return new WaitForSeconds(17f);
        if (dialogueText != null)
        {
            dialogueText.text = ""; 
        }
    }
}

*/

using UnityEngine;
using TMPro;
using System.Collections;

public class Saathviga : MonoBehaviour
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
        Debug.Log("Hello World");
        if (dialogueText != null)
        {
            string objectName = gameObject.name;
            string description = "";

            // Incisors
            if (objectName == "Upper Central Incisor Right" || objectName == "Upper Central Incisor Left")
                description = "The two front teeth on the top. Used for cutting and slicing food.";
            else if (objectName == "Upper Lateral Incisor Right" || objectName == "Upper Lateral Incisor Left")
                description = "Next to the central incisors on the top. Helps in cutting food.";
            else if (objectName == "Lower Central Incisor Right" || objectName == "Lower Central Incisor Left")
                description = "The two front teeth on the bottom. Helps in cutting food.";
            else if (objectName == "Lower Lateral Incisor Right" || objectName == "Lower Lateral Incisor Left")
                description = "Next to the central incisors on the bottom. Assists in slicing food.";

            // Canines
            else if (objectName == "Upper Right Canine")
                description = "Pointed tooth next to the lateral incisor on the right side of the top jaw. Used for tearing and gripping food.";
            else if (objectName == "Upper Left Canine")
                description = "Pointed tooth next to the lateral incisor on the left side of the top jaw. Used for tearing and gripping food.";
            else if (objectName == "Lower Right Canine")
                description = "Pointed tooth next to the lateral incisor on the right side of the bottom jaw. Used for tearing and gripping food.";
            else if (objectName == "Lower Left Canine")
                description = "Pointed tooth next to the lateral incisor on the left side of the bottom jaw. Used for tearing and gripping food.";

            // Premolars
            else if (objectName == "Upper Right First Premolar")
                description = "Located behind the canine on the right side of the top jaw. Used for crushing and grinding food.";
            else if (objectName == "Upper Right Second Premolar")
                description = "Located behind the first premolar on the right side of the top jaw. Helps in chewing food.";
            else if (objectName == "Upper Left First Premolar")
                description = "Located behind the canine on the left side of the top jaw. Helps in chewing food.";
            else if (objectName == "Upper Left Second Premolar")
                description = "Located behind the first premolar on the left side of the top jaw. Assists in grinding food.";
            else if (objectName == "Lower Right First Premolar")
                description = "Located behind the canine on the right side of the bottom jaw. Used for crushing food.";
            else if (objectName == "Lower Right Second Premolar")
                description = "Located behind the first premolar on the right side of the bottom jaw. Helps in chewing.";
            else if (objectName == "Lower Left First Premolar")
                description = "Located behind the canine on the left side of the bottom jaw. Used for chewing.";
            else if (objectName == "Lower Left Second Premolar")
                description = "Located behind the first premolar on the left side of the bottom jaw. Assists in grinding.";

            // Molars
            else if (objectName == "Upper Right First Molar")
                description = "Located behind the second premolar on the right side of the top jaw. Used for heavy grinding and chewing.";
            else if (objectName == "Upper Right Second Molar")
                description = "Located behind the first molar on the right side of the top jaw. Helps in crushing food.";
            else if (objectName == "Upper Right Third Molar")
                description = "Wisdom tooth, the last molar at the back on the right side of the top jaw.";
            else if (objectName == "Upper Left First Molar")
                description = "Located behind the second premolar on the left side of the top jaw. Used for heavy grinding.";
            else if (objectName == "Upper Left Second Molar")
                description = "Located behind the first molar on the left side of the top jaw. Helps in crushing food.";
            else if (objectName == "Upper Left Third Molar")
                description = "Wisdom tooth, the last molar at the back on the left side of the top jaw.";
            else if (objectName == "Lower Right First Molar")
                description = "Located behind the second premolar on the right side of the bottom jaw. Used for heavy grinding.";
            else if (objectName == "Lower Right Second Molar")
                description = "Located behind the first molar on the right side of the bottom jaw. Helps in chewing.";
            else if (objectName == "Lower Right Third Molar")
                description = "Wisdom tooth, the last molar at the back on the right side of the bottom jaw.";
            else if (objectName == "Lower Left First Molar")
                description = "Located behind the second premolar on the left side of the bottom jaw. Used for grinding.";
            else if (objectName == "Lower Left Second Molar")
                description = "Located behind the first molar on the left side of the bottom jaw. Helps in crushing food.";
            else if (objectName == "Lower Left Third Molar")
                description = "Wisdom tooth, the last molar at the back on the left side of the bottom jaw.";

            // Default message if no matching tooth name is found
            else
                description = "No information available for this tooth.";

            // Display the tooth name and description
            string message = $"Tooth Name: {objectName}\nInfo: {description}";
            dialogueText.text = message;
            Debug.Log(message); 

            StartCoroutine(HideTextAfterDelay());
        }
    }

    IEnumerator HideTextAfterDelay()
    {
        yield return new WaitForSeconds(17f);
        if (dialogueText != null)
        {
            dialogueText.text = ""; 
        }
    }

    // XR controller interaction method
    public void OnToothSelected(UnityEngine.XR.Interaction.Toolkit.SelectEnterEventArgs args)
    {
        Debug.Log("Tooth selected via XR controller");

        if (dialogueText != null)
        {
            // Simulate a click by calling OnMouseDown logic
            OnMouseDown();
        }
    }
}
