using UnityEngine;

public class RespawnTrigger : MonoBehaviour
{
    [Header("Objeto Player (asignar en el inspector)")]
    public Transform player;

    [Header("Posición de Respawn (inicio del nivel)")]
    public Vector2 respawnPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.position = respawnPosition;
        }
    }
}

