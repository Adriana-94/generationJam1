using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VidaJugador : MonoBehaviour
{
    public int vidaActual;
    public int vidaMaxima = 5; // Define un valor máximo por defecto

    // Evento para notificar cambios en la vida
    public UnityEvent cambioVida; // Declara el evento
    public int valorPrueba;

    private void Start()
    {
        vidaActual = vidaMaxima;  
        if (cambioVida == null)
        {
            cambioVida = new UnityEvent(); // Inicializa el evento si es null
        }
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            TomarDaño(valorPrueba);
        }
    }

    public void TomarDaño(int cantidadDaño)
    {
        vidaActual -= cantidadDaño;
        if (vidaActual < 0)
        {
            vidaActual = 0;
        }

        // Llama al evento de cambio de vida
        cambioVida.Invoke(); // Invoca el evento

        if (vidaActual <= 0)
        {
            Destroy(gameObject);
        }
    }
}

