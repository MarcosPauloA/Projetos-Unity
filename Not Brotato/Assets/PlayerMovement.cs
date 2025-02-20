using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator animator;

    public MobileJoystick joystick; // Reference to the mobile joystick

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Get input from the joystick
        movement = joystick.GetInput();

        Debug.Log("Joystick Input: " + movement); // Debug log to check joystick values

        // Set animator running state
        animator.SetBool("running", movement.magnitude > 0);
    }

    void FixedUpdate()
    {
        // Move the player
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
