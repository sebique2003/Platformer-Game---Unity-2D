using UnityEngine;
using UnityEngine.SceneManagement;  // Required for scene management

public class StartBtn : MonoBehaviour
{
    // Method to start the game by loading the specified scene
    public void StartGame()
    {
        // Loads the scene named "GameScene"
        SceneManager.LoadScene("GameScene");
    }
}
