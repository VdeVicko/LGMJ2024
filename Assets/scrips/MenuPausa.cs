using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;

    public void Pausa()
    {
        //Debug.Log("pausa");
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
    }
    public void Renudar()
    {
        
        Time.timeScale = 1f;
        botonPausa.SetActive(true );
        menuPausa.SetActive(false );
    }
    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void cerrar ()
    {
        Debug.Log("salir");
        Application.Quit();
    }




    public void EscenaJuego()
    {
      SceneManager.LoadScene("MENU");
    }
}
