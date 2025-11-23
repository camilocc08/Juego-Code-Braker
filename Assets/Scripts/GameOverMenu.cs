using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [Header("Panel e Imagen")]
    public GameObject gameOverPanel;   // El panel completo
    public Image gameOverImage;        // La imagen dentro del panel

    [Header("Imagen personalizada")]
    public Sprite gameOverSprite;      // Tu imagen de Game Over

    void Start()
    {
        // Asegura que el panel esté oculto al inicio
        gameOverPanel.SetActive(false);
    }

    // Llama este método cuando el jugador pierda
    public void ShowGameOver()
    {
        // Asigna la imagen si existe
        if (gameOverImage != null && gameOverSprite != null)
        {
            gameOverImage.sprite = gameOverSprite;
            gameOverImage.preserveAspect = true;
        }

        // Muestra el panel
        gameOverPanel.SetActive(true);

        // Pausa el juego
        Time.timeScale = 0f;
    }

    // Botón: Reiniciar nivel
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.name);
    }

    // Botón: Volver al menú principal
    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // Cambia el nombre si tu menú se llama distinto
    }
}