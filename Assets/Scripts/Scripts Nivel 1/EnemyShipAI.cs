using UnityEngine;

public class EnemyShipAI : MonoBehaviour
{
    [Header("Player")]
    public Transform player;                    
    public float speed = 3f;
    public bool isChasing = false;

    [Header("Movimiento Inicial")]
    public float retreatDistance = 2f;       // Cuánto se mueve hacia atrás
    public float retreatTime = 0.5f;         // Cuánto dura ese movimiento
    private bool hasRetreated = false;

    [Header("Disparo")]
    public GameObject shotPrefab;              
    public float fireRate = 1.5f;               
    private float fireTimer = 0f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!isChasing || player == null) return;

        // --- RETROCESO INICIAL ---
        if (!hasRetreated)
            return; // No persigue ni dispara hasta terminar el retroceso

        // --- PERSEGUIR AL PLAYER ---
        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;

        // --- DISPARAR ---
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireRate)
        {
            fireTimer = 0;
            ShootAtPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isChasing = true;
            StartCoroutine(RetreatThenChase());
        }
    }

    private System.Collections.IEnumerator RetreatThenChase()
    {
        if (player == null) yield break;

        // Calcular dirección opuesta al player
        Vector2 retreatDir = (transform.position - player.position).normalized;

        float timer = 0f;

        while (timer < retreatTime)
        {
            rb.linearVelocity = retreatDir * speed * 1.5f;  
            timer += Time.deltaTime;
            yield return null;
        }

        // Terminar retroceso
        rb.linearVelocity = Vector2.zero;

        hasRetreated = true;  // Ahora sí empieza la persecución
    }

    private void ShootAtPlayer()
    {
        if (shotPrefab == null) return;

        GameObject shot = Instantiate(shotPrefab, transform.position, Quaternion.identity);

        Vector2 dir = (player.position - transform.position).normalized;

        Rigidbody2D rbShot = shot.GetComponent<Rigidbody2D>();
        rbShot.linearVelocity = dir * 5f;
    }
}

