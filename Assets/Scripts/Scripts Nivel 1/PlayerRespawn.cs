using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [Header("Player Lives")]
    public int lives = 3;

    [Header("Checkpoint")]
    private Vector2 checkpoint;

    [Header("Animator")]
    public Animator animator;

    [Header("UI de Vida")]
    public VidaJugador barraVidaJugador;

    private void Start()
    {
        checkpoint = transform.position;
    }

    // Este método se llama desde DamageObjects
    public void TakeDamage()
    {
        // Restar vida
        lives--;

        // Reproducir animación de daño
        if (animator != null)
            animator.Play("Hit2");

        // Actualizar barra de vida
        if (barraVidaJugador != null)
            barraVidaJugador.TomarDaño(100f / 3f); // 3 golpes = barra completa

        // Revisar si aún quedan vidas
        if (lives > 0)
        {
            // Solo respawn si quieres, o puedes quitarlo si quieres que siga en el mismo lugar
            // Invoke(nameof(Respawn), 0.4f);
        }
        else
        {
            // Mostrar Game Over
            if (GameManager.instance != null)
                GameManager.instance.ShowGameOver();
        }
    }

    private void Respawn()
    {
        transform.position = checkpoint;
    }

    public void UpdateCheckpoint(Vector2 pos)
    {
        checkpoint = pos;
    }
}
