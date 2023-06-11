using UnityEngine;
using TMPro;
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
    [SerializeField] TMP_Text text;
    [SerializeField] BrickType brickType;
    SpriteRenderer spriteRenderer;
    [SerializeField] GameObject explosion;
    [SerializeField] GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        SetCapacity();
        spriteRenderer = GetComponent<SpriteRenderer>();
        text = GetComponentInChildren<TMP_Text>();
        UpdateText();
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
    void UpdateText()
    {
        text.text = capacity.ToString();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (capacity > 0)
        {
            capacity--;
            UpdateText();
        }
        if (capacity == 0)
        {
            gameManager.DeleteBrick(transform.position);
            AudioManager.Instance.PlaySound(SoundType.BrickBreak);
            GameObject.Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
