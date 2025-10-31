using UnityEngine;

public class GameManager : MonoBehaviour
{
    // This method will be called to close the application
    public void ExitGame()
    {
        // Check if the game is running in the Unity Editor
#if UNITY_EDITOR
        // If the game is in the Unity Editor, stop play mode
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // If the game is built and running outside the Editor, close the application
        Application.Quit();
#endif
    }
}
