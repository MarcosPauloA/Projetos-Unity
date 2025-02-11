using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 direction;
    public Vector2 startPosition = new Vector2(0, 0);
    public float speedIncrease = 0.5f; // Speed increase when hitting a racket
    private float random;
    public GameObject ballPrefab; // Ball prefab for spawning a second ball
    public float secondBallChance = 0.2f; // 20% chance to spawn a second ball
    public bool isSecondBall = false;

    void Start()
    {
        random = Random.Range(-1f, 1f);
        direction = new Vector2(random, random).normalized; // Initial movement direction
    }

    void FixedUpdate()
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Wall"))
        {
            if(collision.gameObject.name == "LeftWall"){
                ScoreManager.instance.AddPointToPlayer2();
                SoundManager.instance.PlaySound(SoundManager.instance.scoreSound);
                RespawnBall();
            } else if(collision.gameObject.name == "RightWall"){
                ScoreManager.instance.AddPointToPlayer1();
                SoundManager.instance.PlaySound(SoundManager.instance.scoreSound);
                RespawnBall();
            } else{ // It means it hit the floor or roof
                direction.y = -direction.y; // Reverse Y direction
                SoundManager.instance.PlaySound(SoundManager.instance.hitSound);
            }
        }
        else if (collision.gameObject.CompareTag("Racket"))
        {
            direction.x = -direction.x; // Reverse X direction
            speed += speedIncrease;
            SoundManager.instance.PlaySound(SoundManager.instance.hitSound);
        }
    }
        void RespawnBall(){
        if(isSecondBall){
            Destroy(gameObject);
        } else{
            transform.position = startPosition;
            direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            speed = 5f; // Reset speed on respawn

            // Ensure X velocity is not too small
            if (Mathf.Abs(direction.x) < 0.5f) 
            {
                direction.x = Mathf.Sign(direction.x) * 0.5f; // Force minimum X movement
                direction = direction.normalized; // Normalize again
            }

            // Random chance to spawn a second ball
            if (Random.value < secondBallChance)
            {
                Instantiate(ballPrefab, startPosition, Quaternion.identity);
            }
        }
    }
}

