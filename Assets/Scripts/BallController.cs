using UnityEngine;

public class BallController : MonoBehaviour
{
    bool Launched = false;
    Rigidbody2D rb;
    Vector2 direction, collisionNormal;
    PlayerController paddle;
    [SerializeField] float speed = 10f;
    [SerializeField] GameManager gameManager;
    int index = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
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
        if (col.gameObject.layer == LayerMask.NameToLayer("Pit"))
        {
            gameManager.DeleteBall(index);
            return;
        }
        if (paddle = col.gameObject.GetComponent<PlayerController>())
        {
            AudioManager.Instance.PlaySound(SoundType.PaddleBump);
            if (Vector2.Dot(paddle.GetVelocity().normalized, direction.normalized) <= 0)
                collisionNormal = col.contacts[0].normal + paddle.GetVelocity() * Random.Range(0.025f, 0.075f);
            else
                collisionNormal = col.contacts[0].normal;
        }
        else if (col.gameObject.GetComponent<BrickController>() != null)
        {
            AudioManager.Instance.PlaySound(SoundType.BrickBump);
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
    public void JustSpawned(int _index)
    {
        Launched = true;
        index = _index;
    }
    public Vector2 GetDirection()
    {
        return direction;
    }
    public void SetDirection(Vector2 dir)
    {
        direction = dir;
    }
    public int GetIndex()
    {
        return index;
    }
}
