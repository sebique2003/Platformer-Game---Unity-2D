using UnityEngine;
using UnityEngine.SceneManagement;  // Required for scene management

public class PlayAgainButton : MonoBehaviour
{
    // Method to reload the game scene
    public void LoadGameScene()
    {
        // Loads the scene named "GameScene"
        SceneManager.LoadScene("GameScene");
    }
}
