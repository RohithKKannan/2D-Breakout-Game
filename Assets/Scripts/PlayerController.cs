using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float maxX = 7.6f;
    [SerializeField] float speed = 10f;
    float xVal;
    void PlayerInput()
    {
        xVal = Input.GetAxisRaw("Horizontal");
    }
    void Update()
    {
        PlayerInput();
        Debug.Log(xVal);
        if ((transform.position.x < maxX && xVal > 0) || (transform.position.x > -maxX && xVal < 0))
        {
            transform.Translate(Vector3.right * xVal * speed * Time.deltaTime);
        }
    }
}
