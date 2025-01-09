using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Necesario para manipular UI

public class Menu : MonoBehaviour
{
    public GameObject menuPrincipal; // Panel del men� principal
    public GameObject menuCreditos; // Panel de los cr�ditos
    public TextMeshProUGUI textoDificultad;    // Texto que muestra la dificultad actual
    public AudioSource audioSource; // Componente AudioSource para reproducir sonidos
    public AudioClip sonidoBoton;   // Sonido que se reproduce al pulsar un bot�n

    private bool esDificil = false; // Estado de la dificultad (false = f�cil, true = dif�cil)

    void Start()
    {
        // Inicializar los men�s
        menuPrincipal.SetActive(true);  // Mostrar el men� principal
        menuCreditos.SetActive(false); // Ocultar el men� de cr�ditos

        // Inicializar el texto de la dificultad
        textoDificultad.text = "F�cil";
    }

    public void IniciarJuego()
    {
        ReproducirSonido();
        SceneManager.LoadScene("SampleScene"); // Cambia a la escena del juego
    }

    public void MostrarCreditos()
    {
        ReproducirSonido();
        menuPrincipal.SetActive(false); // Ocultar el men� principal
        menuCreditos.SetActive(true);  // Mostrar los cr�ditos
    }

    void VolverAlMenu()
    {
        ReproducirSonido();
        menuPrincipal.SetActive(true);  // Mostrar el men� principal
        menuCreditos.SetActive(false); // Ocultar los cr�ditos
    }

    public void CambiarDificultad()
    {
        ReproducirSonido();

        // Alternar el estado de dificultad
        esDificil = !esDificil;

        // Cambiar el texto seg�n el estado
        if (esDificil)
        {
            textoDificultad.text = "Dif�cil";
        }
        else
        {
            textoDificultad.text = "F�cil";
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

