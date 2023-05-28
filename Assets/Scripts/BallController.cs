using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 velocity, newDirection;
    bool disabled = true;
    [SerializeField] float bounce = 1.2f;
    [SerializeField] float firstPush = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }
    void Update()
    {
        if (disabled)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.gravityScale = 1f;
                disabled = false;
                rb.velocity = Vector2.up * firstPush;
                transform.SetParent(null);
            }
        }
        velocity = rb.velocity;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        // Vector3.Reflect = returns vector that points in the reflecting direction
        newDirection = Vector2.Reflect(velocity.normalized, col.contacts[0].normal);

        rb.velocity = newDirection * Mathf.Max(velocity.magnitude, bounce);
    }
}
