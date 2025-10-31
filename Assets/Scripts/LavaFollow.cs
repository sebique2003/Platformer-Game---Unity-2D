using UnityEngine;
using UnityEngine.SceneManagement;  // Required for scene management

public class LavaFollow : MonoBehaviour
{
    public Transform player;        // Reference to the player
    public float followSpeed = 2f;  // Speed at which the lava follows the player
    private bool isFollowing = false;  // Flag to start following the player
    private float timer = 0f;          // Timer to start following after 3 seconds

    void Update()
    {
        // If lava is set to follow the player
        if (isFollowing)
        {
            // Lava follows the player's vertical position (y-axis) without affecting its own x or z position
            Vector3 targetPosition = new Vector3(transform.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
        else
        {
            // If the player starts moving up, the timer begins
            timer += Time.deltaTime;

            // After 3 seconds, enable the following behavior
            if (timer >= 3f)
            {
                isFollowing = true;
            }
        }
    }

    // Detect collision with the player
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Check if the object is tagged as "Player"
        {
            // Load the "LostGame" scene when the lava touches the player
            SceneManager.LoadScene("LostGame");
        }
    }
}
