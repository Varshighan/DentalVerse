using UnityEngine;
using UnityEngine.SceneManagement;  // Required for scene switching

public class SceneLoader : MonoBehaviour
{
    public void LoadToothTeethScene()  // Function must be PUBLIC
    {
        SceneManager.LoadScene("ToothTeeth");  // Exact scene name
    }
}
