using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Fields to control player movement and state
    [SerializeField] private float horizontalInput;    // Player's horizontal input
    [SerializeField] private float moveSpeed = 5f;     // Movement speed, adjustable in the Inspector
    [SerializeField] private bool isFacingRight = true; // Whether the player is facing right
    [SerializeField] private float jumpPower = 5.5f;   // Jump force, adjustable in the Inspector
    [SerializeField] private bool isJumping = false;   // Check if the player is jumping

    private Rigidbody2D rb;        // Reference to the player's Rigidbody2D
    private Animator animator;     // Reference to the Animator component

    // Variable for screen boundaries
    private Vector2 screenBounds;

    void Start()
    {
        // Initialize Rigidbody2D and Animator components
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // Set the initial facing direction based on input
        FlipSprite(horizontalInput);

        // Calculate screen boundaries based on the camera's view
        Camera mainCamera = Camera.main;
        screenBounds = new Vector2(mainCamera.orthographicSize * mainCamera.aspect, mainCamera.orthographicSize);
    }

    void Update()
    {
        // Get horizontal input (e.g., from arrow keys or A/D)
        horizontalInput = Input.GetAxis("Horizontal");

        // Update animator parameters for animations
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput)); // Pass absolute speed for running animation
        animator.SetBool("IsJumping", isJumping);               // Set jumping animation state

        // Check if the sprite should flip based on movement direction
        FlipSprite(horizontalInput);

        // Handle jumping when the "Jump" button (default is Space) is pressed
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            // Apply an upward force to the player's Rigidbody2D for jumping
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            isJumping = true; // Set the jumping flag to true
        }
    }

    private void FixedUpdate()
    {
        // Apply horizontal movement to the player's Rigidbody2D
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);

        // Restrict player's position within the screen boundaries
        ClampPosition();
    }

    void FlipSprite(float horizontalInput)
    {
        // Check if the player's direction needs to change
        if ((isFacingRight && horizontalInput < 0f) || (!isFacingRight && horizontalInput > 0f))
        {
            isFacingRight = !isFacingRight; // Toggle facing direction

            // Flip the player's sprite by rotating it 180 degrees on the Y-axis
            transform.rotation = Quaternion.Euler(0, isFacingRight ? 0 : 180, 0);
        }
    }

    private void ClampPosition()
    {
        // Calculate the camera's width in world units
        Camera mainCamera = Camera.main;
        float cameraHalfWidth = mainCamera.orthographicSize * mainCamera.aspect;

        // Restrict the player's X position to stay within the camera's width
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -cameraHalfWidth, cameraHalfWidth);

        // Apply the clamped position back to the player
        transform.position = clampedPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Detect collisions and reset the jumping flag if the player lands
        isJumping = false;
    }
}
