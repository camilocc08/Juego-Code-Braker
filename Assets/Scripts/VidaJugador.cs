using UnityEngine;
using UnityEngine.UI;

public class VidaJugador : MonoBehaviour
{
    [Header("UI")]
    public Image barraVida; // Imagen tipo Filled

    private float vidaMax = 100f;
    private float vidaActual;

    void Start()
    {
        vidaActual = vidaMax;
        ActualizarBarra();
    }

    // Método para recibir daño
    public void TomarDaño(float daño)
    {
        vidaActual -= daño;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMax);
        ActualizarBarra();
    }

    // Método para curar vida (opcional)
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
