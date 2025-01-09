using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Importar para manejar textos

public class Menu : MonoBehaviour
{
    public GameObject menuPrincipal; // Panel del menú principal
    public GameObject textoCreditos; // Panel del menú créditos

    public AudioSource audioSource;  // Componente AudioSource para reproducir sonidos
    public AudioClip sonidoBoton;    // Sonido que se reproducirá al pulsar botones

    public Text textoDificultad;     // Componente de texto para mostrar la dificultad
    private bool esFacil = true;     // Variable para controlar el estado de la dificultad

    public void IniciarJuego()
    {
        ReproducirSonido(); // Reproducir el sonido al pulsar el botón
        SceneManager.LoadScene("SampleScene"); // Cargar la escena principal
    }

    public void ReproducirSonido()
    {
        // Verifica que el AudioSource y el sonido están configurados
        if (audioSource != null && sonidoBoton != null)
        {
            audioSource.PlayOneShot(sonidoBoton); // Reproduce el sonido
        }
    }

    public void CambiarDificultad()
    {
        // Cambia entre Fácil y Difícil
        esFacil = !esFacil;

        // Actualiza el texto basado en el estado actual
        if (textoDificultad != null)
        {
            if (esFacil)
            {
                textoDificultad.text = "Fácil";
            }
            else
            {
                textoDificultad.text = "Difícil";
            }
        }

        ReproducirSonido(); // Opcional: reproducir un sonido al cambiar la dificultad
    }

    public void MostrarCreditos()
    {
        // Cambiar de menú principal a créditos
        menuPrincipal.SetActive(false);   // Ocultar menú principal
        textoCreditos.SetActive(true);     // Mostrar menú créditos
    }

    public void OcultarCreditos()
    {
        // Volver del menú créditos al menú principal
        menuPrincipal.SetActive(true);    // Mostrar menú principal
        textoCreditos.SetActive(false);    // Ocultar menú créditos
    }

    void Start()
    {
        // Configurar los objetos al inicio del juego
        menuPrincipal.SetActive(true);   // Mostrar menú principal
        textoCreditos.SetActive(false);  // Ocultar menú créditos

        // Configurar la dificultad inicial
        if (textoDificultad != null)
        {
            textoDificultad.text = "Fácil"; // Texto predeterminado
        }
    }
}
