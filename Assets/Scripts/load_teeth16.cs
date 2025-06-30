using UnityEngine;
using UnityEngine.SceneManagement;  // Required for scene switching

public class SceneLoader_teeth : MonoBehaviour
{
    public void LoadToothTeethScene()  // Function must be PUBLIC
    {
        SceneManager.LoadScene("teeth_16th");  // Exact scene name
    }
}
