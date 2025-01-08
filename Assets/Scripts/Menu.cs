using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menuPrincipal; // Panel del men� principal
    public GameObject menuCreditos; // Panel del men� cr�ditos

    public AudioSource audioSource;  // Componente AudioSource para reproducir sonidos
    public AudioClip sonidoBoton;    // Sonido que se reproducir� al pulsar botones

    public void IniciarJuego()
    {
        ReproducirSonido(); // Reproducir el sonido al pulsar el bot�n
        SceneManager.LoadScene("SampleScene"); // Cargar la escena principal
    }

    public void ReproducirSonido()
    {
        // Verifica que el AudioSource y el sonido est�n configurados
        if (audioSource != null && sonidoBoton != null)
        {
            audioSource.PlayOneShot(sonidoBoton); // Reproduce el sonido
        }
    }

    void Start()
    {
        // Configurar los objetos al inicio del juego
        menuPrincipal.SetActive(true);   // Mostrar men� principal
        menuCreditos.SetActive(false);  // Ocultar men� cr�ditos
    }
}
