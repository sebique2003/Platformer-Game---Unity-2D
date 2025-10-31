using UnityEngine;
using UnityEngine.SceneManagement;

public class BananaRotation : MonoBehaviour
{
    public float rotationSpeed = 30f; // Speed at which the banana rotates

    void Update()
    {
        // The Update method is called once per frame.
        // Here, we rotate the banana around its Y-axis (upward axis in 3D space).
        // The rotation happens at a speed defined by 'rotationSpeed', and we scale it with 'Time.deltaTime'
        // to ensure smooth rotation regardless of frame rate.
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    // This method is triggered when another object collides with the banana's collider.
    // It only works if one of the colliding objects has a Rigidbody2D component.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that collided with the banana has the tag "Player".
        if (other.CompareTag("Player"))
        {
            // If the player touches the banana:
            // 1. Destroy the banana object to simulate it being "collected".
            Destroy(gameObject);

            // 2. Load the "WinGame" scene, indicating the player has won.
            // Note: Ensure the "WinGame" scene is added to the Build Settings in Unity.
            SceneManager.LoadScene("WinGame");
        }
    }
}
