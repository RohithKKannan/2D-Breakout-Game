using UnityEngine;

public class BallController : MonoBehaviour
{
    bool Launched = false;
    Rigidbody2D rb;
    Vector2 direction, collisionNormal;
    PlayerController paddle;
    [SerializeField] float speed = 10f;
    [SerializeField] float paddleTurn = 2f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (!Launched)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.SetParent(null);
                direction = Vector2.up * speed;
                Launched = true;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (paddle = col.gameObject.GetComponent<PlayerController>())
        {
            if (Vector2.Dot(paddle.GetVelocity().normalized, direction.normalized) <= 0)
                collisionNormal = col.contacts[0].normal + paddle.GetVelocity() * paddleTurn;
            else
                collisionNormal = col.contacts[0].normal;
        }
        else
        {
            collisionNormal = col.contacts[0].normal;
        }
        direction = Vector2.Reflect(direction, collisionNormal);
    }
    void LateUpdate()
    {
        rb.velocity = speed * direction;
        direction = rb.velocity.normalized;
    }
}
