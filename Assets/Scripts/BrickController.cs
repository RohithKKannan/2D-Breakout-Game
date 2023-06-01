using UnityEngine;
public enum BrickType
{
    Blue,
    LightGreen,
    Yellow,
    Orange,
    Red
}
public class BrickController : MonoBehaviour
{
    int capacity;
    [SerializeField] BrickType brickType;
    SpriteRenderer spriteRenderer;
    [SerializeField] GameObject explosion;
    void Start()
    {
        SetCapacity();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void SetCapacity()
    {
        switch (brickType)
        {
            case BrickType.Blue: capacity = 1; break;
            case BrickType.LightGreen: capacity = 2; break;
            case BrickType.Yellow: capacity = 3; break;
            case BrickType.Orange: capacity = 4; break;
            case BrickType.Red: capacity = 5; break;
            default: break;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (capacity > 0)
            capacity--;
        if (capacity == 0)
        {
            GameObject.Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
