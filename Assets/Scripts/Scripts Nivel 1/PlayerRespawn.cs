using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PlayerRespawn : MonoBehaviour
{
    [Header("Corazones del jugador")]
    public int maxHearts = 3;
    public int currentHearts;

    [Header("UI de corazones")]
    public Image[] heartsUI;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    [Header("Animator")]
    public Animator animator;   // Animación Hit2

    [Header("Pantalla de Game Over")]
    public GameObject gameOverScreen;

    [Header("Escena a cargar cuando muere")]
    public string menuScene = "MenuInicial";   // ⭐ Ahora puedes escogerla en el inspector

    private bool isDead = false;

    private void Start()
    {
        currentHearts = maxHearts;
        UpdateHearts();
    }

    // Método llamado por DamageObjects
    public void TakeDamage()
    {
        if (isDead) return;

        // Animación de daño
        if (animator != null)
            animator.Play("Hit2");

        // Quitar un corazón
        currentHearts--;
        UpdateHearts();

        // Si ya no tiene corazones → morir
        if (currentHearts <= 0)
        {
            StartCoroutine(GameOver());
        }
    }

    // Actualiza la UI de corazones
    void UpdateHearts()
    {
        for (int i = 0; i < heartsUI.Length; i++)
        {
            if (i < currentHearts)
                heartsUI[i].sprite = fullHeart;
            else
                heartsUI[i].sprite = emptyHeart;
        }
    }

    IEnumerator GameOver()
    {
        isDead = true;

        // Mostrar pantalla GameOver
        if (gameOverScreen != null)
            gameOverScreen.SetActive(true);

        // Esperar
        yield return new WaitForSeconds(3f);

        // 🔥 Cargar la escena que tú elijas desde Unity
        SceneManager.LoadScene(menuScene);
    }
}
