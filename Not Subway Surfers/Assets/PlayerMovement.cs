using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 startTouchPosition;
    private Vector2 currentSwipe;

    private void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startTouchPosition = touch.position;
                    break;

                case TouchPhase.Ended:
                    currentSwipe = (touch.position - startTouchPosition).normalized;

                    if (currentSwipe.x > 0)
                    {
                        // Swipe Right
                        MovePlayer(Vector3.right);
                    }
                    else if (currentSwipe.x < 0)
                    {
                        // Swipe Left
                        MovePlayer(Vector3.left);
                    }
                    break;
            }
        }
    }

    private void MovePlayer(Vector3 direction)
    {
        // Adjust the speed and method of movement to your needs
        float speed = 5f;
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
