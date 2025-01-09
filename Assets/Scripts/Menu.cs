using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Necesario para manipular UI

public class Menu : MonoBehaviour
{
    public GameObject menuPrincipal; // Panel del menú principal
    public GameObject menuCreditos; // Panel de los créditos
    public TextMeshProUGUI textoDificultad;    // Texto que muestra la dificultad actual
    public AudioSource audioSource; // Componente AudioSource para reproducir sonidos
    public AudioClip sonidoBoton;   // Sonido que se reproduce al pulsar un botón

    private bool esDificil = false; // Estado de la dificultad (false = fácil, true = difícil)

    void Start()
    {
        // Inicializar los menús
        menuPrincipal.SetActive(true);  // Mostrar el menú principal
        menuCreditos.SetActive(false); // Ocultar el menú de créditos

        // Inicializar el texto de la dificultad
        textoDificultad.text = "Fácil";
    }

    public void IniciarJuego()
    {
        ReproducirSonido();
        SceneManager.LoadScene("SampleScene"); // Cambia a la escena del juego
    }

    public void MostrarCreditos()
    {
        ReproducirSonido();
        menuPrincipal.SetActive(false); // Ocultar el menú principal
        menuCreditos.SetActive(true);  // Mostrar los créditos
    }

    void VolverAlMenu()
    {
        ReproducirSonido();
        menuPrincipal.SetActive(true);  // Mostrar el menú principal
        menuCreditos.SetActive(false); // Ocultar los créditos
    }

    public void CambiarDificultad()
    {
        ReproducirSonido();

        // Alternar el estado de dificultad
        esDificil = !esDificil;

        // Cambiar el texto según el estado
        if (esDificil)
        {
            textoDificultad.text = "Difícil";
        }
        else
        {
            textoDificultad.text = "Fácil";
        }
    }

    public void ReproducirSonido()
    {
        if (audioSource != null && sonidoBoton != null)
        {
            audioSource.PlayOneShot(sonidoBoton);
        }
    }
}

