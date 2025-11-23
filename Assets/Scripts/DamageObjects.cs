using UnityEngine;

public class DamageObjects : MonoBehaviour
{
    [Header("Daño al jugador")]
    public int daño = 1; // Opcional, puedes modificar

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            var playerRespawn = collision.transform.GetComponent<PlayerRespawn>();
            if (playerRespawn != null)
                playerRespawn.TakeDamage();
        }
    }
}