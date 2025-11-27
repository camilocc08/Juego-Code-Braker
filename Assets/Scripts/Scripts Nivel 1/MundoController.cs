using UnityEngine;
using UnityEngine.SceneManagement;

public class MundoController : MonoBehaviour
{
    public void MenuInicial()
    {
        SceneManager.LoadScene("MenuEle"); // o el nombre de tu escena de juego
    }
    public void JugarMundo1()
    {
        SceneManager.LoadScene("SampleScene"); // o el nombre de tu escena de juego
    }
    public void JugarMundo2()
    {
        SceneManager.LoadScene("SecondLevel"); // o el nombre de tu escena de juego
    }
    public void JugarMundo3()
    {
        SceneManager.LoadScene("TercerLevel"); // o el nombre de tu escena de juego
    }

    public void VolverAlMenu()
    {
        SceneManager.LoadScene("MenuInicial");
    }
}