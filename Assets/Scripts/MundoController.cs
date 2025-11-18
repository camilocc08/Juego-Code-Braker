using UnityEngine;
using UnityEngine.SceneManagement;

public class MundoController : MonoBehaviour
{
    public void JugarMundo()
    {
        SceneManager.LoadScene("SampleScene"); // o el nombre de tu escena de juego
    }

    public void VolverAlMenu()
    {
        SceneManager.LoadScene("MenuInicial");
    }
}