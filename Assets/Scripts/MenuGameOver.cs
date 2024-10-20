using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameOver : MonoBehaviour
{
    [SerializeField] private GameObject menuGameOver;
    [SerializeField] private VidaJugador vidaJugador;

    private void Awake()
    {
        if (vidaJugador == null)
        {
            vidaJugador = GameObject.FindWithTag("Player")?.GetComponent<VidaJugador>();
        }

        if (vidaJugador != null)
        {
            vidaJugador.MuerteJugador.AddListener(ActivarMenu); // Escucha la muerte del jugador
        }
        else
        {
            Debug.LogError("VidaJugador no asignado.");
        }
    }

    private void ActivarMenu()
    {
        menuGameOver.SetActive(false); // Activa el menú Game Over
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reinicia la escena actual
    }

    public void Menu()
    {
        SceneManager.LoadScene(0); // Regresa al menú principal
    }

    public void Salir()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Para detener el juego en el editor
#endif
    }
}
