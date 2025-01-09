using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Importar para manejar textos

public class Menu : MonoBehaviour
{

    public GameObject menuPrincipal;
    public GameObject menuCreditos;
    public GameObject botonAtras;

    public string dificultad = "Fácil";

    public TextMeshProUGUI textoDificultad;

    public AudioSource audioSource;  // Componente AudioSource para reproducir sonidos
    public AudioClip sonidoBoton;    // Sonido que se reproducirá al pulsar botones

    private void Start()
    {
        menuPrincipal.SetActive(true);
        menuCreditos.SetActive(false);
        botonAtras.SetActive(false);
    }

    private void IniciarJuego()
    {

        //Cargar escena con el juego
        SceneManager.LoadScene("SampleScene");

    }

    public void Creditos()
    {
        menuPrincipal.SetActive(false);
        menuCreditos.SetActive(true);
        botonAtras.SetActive(true);
    }

    public void Atras()
    {
        menuPrincipal.SetActive(true);
        menuCreditos.SetActive(false);
        botonAtras.SetActive(false);
    }

    public void DificultadJuego(string nivel) 
    {
        dificultad = nivel;
        
        if (textoDificultad != null )
        {
            textoDificultad.text = dificultad;
        }
    }

}