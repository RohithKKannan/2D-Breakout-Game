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
            collisionNormal = col.contacts[0].normal + paddle.GetVelocity() * paddleTurn;
        }
        else
        {
            collisionNormal = col.contacts[0].normal;
        }
        Debug.Log("OnCollisionEnter2D direction : " + direction + " normal : " + collisionNormal);
        direction = Vector2.Reflect(direction, collisionNormal);
        Debug.Log("Result direction : " + direction);
    }
    void LateUpdate()
    {
        rb.velocity = speed * direction;
        direction = rb.velocity.normalized;
    }
}
