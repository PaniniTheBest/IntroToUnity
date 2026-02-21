using UnityEngine;
public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.0f;
    [SerializeField]
    private float lifetime = 5.0f;
    [SerializeField]
    private float damageValue = 2.0f;

    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(0, 
            speed);

        // destroy this gameobject after the
        // lifetime has passed
        Destroy(this.gameObject, lifetime);
    }

    public float GetDamageValue()
        { return damageValue; }
}
