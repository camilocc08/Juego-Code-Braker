using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public CanvasGroup gameOverCanvas;
    public float fadeDuration = 1f;
    private bool isGameOver = false;

    private void Awake()
    {
        // Singleton: solo un GameManager global
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // persiste entre escenas
        }
        else
        {
            Destroy(gameObject); // elimina duplicados
        }
    }

    private void Start()
    {
        if (gameOverCanvas != null)
        {
            gameOverCanvas.alpha = 0;
            gameOverCanvas.gameObject.SetActive(false);
        }
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            gameOverCanvas.gameObject.SetActive(true);
            Time.timeScale = 0f;
            StartCoroutine(FadeIn());
        }
    }

    private System.Collections.IEnumerator FadeIn()
    {
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.unscaledDeltaTime;
            gameOverCanvas.alpha = Mathf.Clamp01(elapsed / fadeDuration);
            yield return null;
        }
        gameOverCanvas.alpha = 1f;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isGameOver = false;
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // asegúrate de que exista la escena MainMenu
        isGameOver = false;
    }
}