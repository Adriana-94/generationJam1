using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{

    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;

    private bool juegoPausado = false;
    // Start is called before the first frame update
    public void Pausa()
    {
        juegoPausado = true;
        Time.timeScale = 0f; //esto lo que hae es pausar
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);    
    }

    public void Reanudar()
    {
        juegoPausado = false;
        Time.timeScale = 1f; //esto lo que hae es reanudar
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);  


    }

    public void Reinicar(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void Cerrar(){
        Debug.Log("Cerrando Juego");
        Application.Quit();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            if(juegoPausado){
                Reanudar();
                } else{
                    Pausa();
                }
        }
    }

}
