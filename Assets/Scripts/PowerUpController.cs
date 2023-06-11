using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    [SerializeField] PowerUp powerUp;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Pit"))
        {
            Destroy(this.gameObject);
            return;
        }
    }
    public PowerUp GetPowerType()
    {
        return powerUp;
    }
}
