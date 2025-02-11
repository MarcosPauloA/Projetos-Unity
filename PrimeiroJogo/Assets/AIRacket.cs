using UnityEngine;

public class AIRacket : MonoBehaviour
{
    public Transform ball;  // Reference to the ball
    public float speed = 4f; // AI movement speed
    public float reactionTime = 0.1f; // Delay for more natural movement
    public float errorChance = 0.1f; // 10% chance to make an error
    public float maxErrorOffset = 1f; // Maximum error offset from the ball position

    private float targetY; // Target position for the AI
    private float errorOffset = 0.25f;

    void Update()
    {
        if (ball != null)
        {
            // Introduce a random error sometimes
            if (Random.value < errorChance)
            {
                errorOffset = Random.Range(-maxErrorOffset, maxErrorOffset);
            }

            // Calculate target position with potential error
            targetY = ball.position.y + errorOffset;

            // Move towards the target Y position at a limited speed
            float newY = Mathf.MoveTowards(transform.position.y, targetY, speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }
}
