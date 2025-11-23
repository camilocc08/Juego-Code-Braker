using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    [Header("UI")]
    public Image barraVida; // Imagen de la barra rellena

    [Header("Vida")]
    public float vidaMax = 100f;
    private float vidaActual;

    void Start()
    {
        vidaActual = vidaMax;
        ActualizarBarra();
    }

    // Recibe daño
    public void TomarDaño(float daño)
    {
        vidaActual -= daño;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMax);
        ActualizarBarra();

        if (vidaActual <= 0)
        {
            if (GameManager.instance != null)
                GameManager.instance.ShowGameOver();
        }
    }

    // Curar vida
    public void Curar(float cantidad)
    {
        vidaActual += cantidad;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMax);
        ActualizarBarra();
    }

    private void ActualizarBarra()
    {
        if (barraVida != null)
            barraVida.fillAmount = vidaActual / vidaMax;
    }
}
