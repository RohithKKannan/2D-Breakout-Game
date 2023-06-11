using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float maxX = 7.6f;
    [SerializeField] float speed = 10f;
    [SerializeField] GameManager gameManager;
    Vector3 prev;
    Vector2 displacement, velocity;
    float xVal;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    void PlayerInput()
    {
        xVal = Input.GetAxisRaw("Horizontal");
        prev = transform.position;
    }
    void Update()
    {
        PlayerInput();
        if ((transform.position.x < maxX && xVal > 0) || (transform.position.x > -maxX && xVal < 0))
        {
            transform.Translate(Vector3.right * xVal * speed * Time.deltaTime);
        }
        displacement = transform.position - prev;
        velocity = displacement / Time.deltaTime;
    }
    public Vector2 GetVelocity()
    {
        return velocity;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        PowerUpController temp = null;
        if (temp = col.gameObject.GetComponent<PowerUpController>())
        {
            if (temp.GetPowerType() == PowerUp.Ball2x)
                gameManager.PowerUpPicked(PowerUp.Ball2x);
            Destroy(col.gameObject);
        }
    }
}
