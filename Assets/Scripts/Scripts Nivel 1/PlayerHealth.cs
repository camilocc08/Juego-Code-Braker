using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHearts = 3;
    public int currentHearts;

    public Image[] heartsUI;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public GameObject gameOverScreen;

    private bool isDead = false;

    [Header("Animator del Player")]
    public Animator animator;

    void Start()
    {
        currentHearts = maxHearts;
        UpdateHearts();
    }

    public void TakeDamage()
    {
        if (isDead) return;

        // Reproducir animación de daño
        if (animator != null)
            animator.Play("Hit2");

        currentHearts--;
        UpdateHearts();

        if (currentHearts <= 0)
        {
            StartCoroutine(GameOver());
        }
    }

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

        if (gameOverScreen != null)
            gameOverScreen.SetActive(true);

        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("MainMenu");
    }
}
