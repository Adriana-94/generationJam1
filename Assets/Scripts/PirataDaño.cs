using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirataDaño : MonoBehaviour
{
    public int daño;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out VidaJugador vidaJugador))
        {
            vidaJugador.TomarDaño(daño);
        }


    }
   
}
