using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Importar para manejar textos

public class Menu : MonoBehaviour
{
    public GameObject menuPrincipal; // Panel del men� principal
    public GameObject textoCreditos; // Panel del men� cr�ditos

    public AudioSource audioSource;  // Componente AudioSource para reproducir sonidos
    public AudioClip sonidoBoton;    // Sonido que se reproducir� al pulsar botones

    public Text textoDificultad;     // Componente de texto para mostrar la dificultad
    private bool esFacil = true;     // Variable para controlar el estado de la dificultad

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

    public void CambiarDificultad()
    {
        // Cambia entre F�cil y Dif�cil
        esFacil = !esFacil;

        // Actualiza el texto basado en el estado actual
        if (textoDificultad != null)
        {
            if (esFacil)
            {
                textoDificultad.text = "F�cil";
            }
            else
            {
                textoDificultad.text = "Dif�cil";
            }
        }

        ReproducirSonido(); // Opcional: reproducir un sonido al cambiar la dificultad
    }

    public void MostrarCreditos()
    {
        // Cambiar de men� principal a cr�ditos
        menuPrincipal.SetActive(false);   // Ocultar men� principal
        textoCreditos.SetActive(true);     // Mostrar men� cr�ditos
    }

    public void OcultarCreditos()
    {
        // Volver del men� cr�ditos al men� principal
        menuPrincipal.SetActive(true);    // Mostrar men� principal
        textoCreditos.SetActive(false);    // Ocultar men� cr�ditos
    }

    void Start()
    {
        // Configurar los objetos al inicio del juego
        menuPrincipal.SetActive(true);   // Mostrar men� principal
        textoCreditos.SetActive(false);  // Ocultar men� cr�ditos

        // Configurar la dificultad inicial
        if (textoDificultad != null)
        {
            textoDificultad.text = "F�cil"; // Texto predeterminado
        }
    }
}
