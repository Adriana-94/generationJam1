using UnityEngine;
using UnityEngine.Events;

public class VidaJugador : MonoBehaviour
{
    public int vidaMaxima = 5;
    public int vidaActual;

    // Evento para detectar cambios en la vida
    public UnityEvent cambioVida = new UnityEvent();

    // Evento para detectar la muerte del jugador
    public UnityEvent MuerteJugador = new UnityEvent();

    private void Start()
    {
        vidaActual = vidaMaxima;
        cambioVida.Invoke(); // Sincroniza la UI al inicio
    }

    public void TomarDaño(int cantidad)
    {
        vidaActual -= cantidad;
        if (vidaActual < 0) vidaActual = 0;

        cambioVida.Invoke(); // Notifica la UI sobre el cambio de vida

        if (vidaActual <= 0)
        {
            MuerteJugador.Invoke();  // Invoca el evento ANTES de destruir el objet
            gameObject.SetActive(false); // Desactiva el jugador en lugar de destruirlo
            //Destroy(gameObject); // Destruye al jugador
        }
    }
}
