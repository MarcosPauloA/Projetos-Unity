using UnityEngine;

public class RacketMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of the racket
    public float boundary = 4f; // Limit for movement
    public string inputAxis; // Assign this in the Inspector
    void Update()
    {
        float move = Input.GetAxisRaw(inputAxis) * speed * Time.deltaTime;
        float newY = Mathf.Clamp(transform.position.y + move, -boundary, boundary);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}