using UnityEngine;
using UnityEngine.SceneManagement;  // Required for scene switching

public class SceneLoader_2 : MonoBehaviour
{
    public void LoadMainScene()  // Function must be PUBLIC
    {
        SceneManager.LoadScene("MainOpening");  // Exact scene name
    }
}
