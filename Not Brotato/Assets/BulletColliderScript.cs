using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object hit is tagged as 'Target'
        if (collision.gameObject.CompareTag("Target"))
        {
            // You can add effects here, like playing an animation or sound

            // Destroy the bullet
            Destroy(gameObject);

            // Destroy the target
            Destroy(collision.gameObject);
        }
    }
}
