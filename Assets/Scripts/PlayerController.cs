using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float maxX = 7.6f;
    [SerializeField] float speed = 10f;
    Vector3 prev;
    Vector2 displacement, velocity;
    float xVal;
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
}
