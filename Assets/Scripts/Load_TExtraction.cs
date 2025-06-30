using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_TExtraction : MonoBehaviour
{
   public void LoadToothExtractionScene()  // Function must be PUBLIC
    {
        SceneManager.LoadScene("Tooth_Extraction");  // Exact scene name
    }
}
