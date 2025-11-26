using UnityEngine;
using System.Collections;

public class LevelEndTrigger : MonoBehaviour
{
    [Header("Panels")]
    public GameObject levelCompletePanel;    // Panel de GANASTE
    public GameObject missingKeysPanel;      // Panel que dice "Faltan llaves"

    [Header("Scene")]
    public string levelName = "SampleScene"; // Nombre de tu escena actual
    public string menuScene = "MenuInicial"; // Escena a cargar cuando ganas

    private bool ended = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ended) return;

        if (collision.CompareTag("Player"))
        {
            ended = true;

            // Validar llaves
            if (KeyManager.Instance != null &&
                KeyManager.Instance.keysCollected >= KeyManager.Instance.totalKeys)
            {
                // GANASTE
                if (levelCompletePanel != null)
                    levelCompletePanel.SetActive(true);

                StartCoroutine(WinCoroutine());
            }
            else
            {
                // FALTAN LLAVES
                if (missingKeysPanel != null)
                    missingKeysPanel.SetActive(true);

                StartCoroutine(RestartCoroutine());
            }
        }
    }

    IEnumerator WinCoroutine()
    {
        // Espera 5 segundos mostrando tu panel de victoria
        yield return new WaitForSeconds(5f);

        // 🔥 Aquí regresas al menú
        UnityEngine.Application.LoadLevel(menuScene);
    }

    IEnumerator RestartCoroutine()
    {
        yield return new WaitForSeconds(3f);

        // Reiniciar el nivel
        UnityEngine.Application.LoadLevel(levelName);
    }
}

