using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float speed;

    public Vector3 Direction { get; set; }
    public float Damage { get; set; }
    public GameObject Shooter { get; set; } // Inimigo que disparou o projétil

    private void Update()
    {
        transform.Translate(Direction * (speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Ignore colisão com o próprio inimigo que disparou
        if (other.gameObject == Shooter) return;
        
        other.GetComponent<IDamageable>()?.TakeDamage(Damage);
        Destroy(gameObject);
    }
       
}
