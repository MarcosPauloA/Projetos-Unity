using UnityEngine;

public class SecondRacketMovement : MonoBehaviour
{
    public float speed = 7f; // Speed of the racket
    public float boundary = 4f; // Limit for movement

    void Update()
    {
        float move = Input.GetAxis("Vertical2") * speed * Time.deltaTime;
        float newY = Mathf.Clamp(transform.position.y + move, -boundary, boundary);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
