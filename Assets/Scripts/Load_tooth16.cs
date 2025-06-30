using UnityEngine;
using UnityEngine.SceneManagement;  // Required for scene switching

public class SceneLoader_tooth : MonoBehaviour
{
    public void LoadToothTeethScene()  // Function must be PUBLIC
    {
        SceneManager.LoadScene("tooth_16th");  // Exact scene name
    }
}
