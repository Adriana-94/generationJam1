using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorazonUI : MonoBehaviour
{
    public List<Image> listaCorazones = new List<Image>(); // Inicializamos la lista
    public GameObject corazonPrefab;
    public VidaJugador vidaJugador;
    public Sprite corazonLleno;
    public Sprite corazonVacio;

    private void Awake()
    {
        if (vidaJugador != null)
        {
            vidaJugador.cambioVida.AddListener(ActualizarUI); // Asigna el evento
        }
        else
        {
            Debug.LogError("VidaJugador no asignado en CorazonUI.");
        }
    }

    private void Start()
    {
        InicializarUI(); // Inicializa la UI
    }

    private void InicializarUI()
    {
        if (corazonPrefab == null)
        {
            Debug.LogError("Prefab de corazón no asignado.");
            return;
        }

        for (int i = 0; i < vidaJugador.vidaMaxima; i++)
        {
            GameObject nuevoCorazon = Instantiate(corazonPrefab, transform);
            Image imagenCorazon = nuevoCorazon.GetComponent<Image>();

            if (imagenCorazon != null)
            {
                listaCorazones.Add(imagenCorazon);
                imagenCorazon.sprite = corazonLleno; // Lleno inicialmente
            }
            else
            {
                Debug.LogError("El prefab no tiene un componente Image.");
            }
        }
    }

    private void ActualizarUI()
    {
        if (listaCorazones.Count == 0)
        {
            Debug.LogWarning("La lista de corazones está vacía.");
            return;
        }

        for (int i = 0; i < listaCorazones.Count; i++)
        {
            if (i < vidaJugador.vidaActual)
            {
                listaCorazones[i].sprite = corazonLleno; // Lleno
            }
            else
            {
                listaCorazones[i].sprite = corazonVacio; // Vacío
            }
        }
    }
}
