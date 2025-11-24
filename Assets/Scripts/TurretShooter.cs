using UnityEngine;

public class TurretShooter : MonoBehaviour
{
    public GameObject shotPrefab;     // Prefab de la bala
    public Transform firePoint;       // Desde dónde se dispara
    public float shootInterval = 7f;  // Cada cuántos segundos dispara

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= shootInterval)
        {
            Shoot();
            timer = 0;
        }
    }

    void Shoot()
    {
        Instantiate(shotPrefab, firePoint.position, firePoint.rotation);
    }

    // --------- SI EL PLAYER CAE ENCIMA DE LA TORRETA EXPLOTA ---------
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si el objeto que cae es el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Ver si cayó por arriba usando la normal del contacto
            if (collision.contacts[0].normal.y < -0.5f)
            {
                Destroy(gameObject);  // Desaparece la torreta
            }
        }
    }
}

