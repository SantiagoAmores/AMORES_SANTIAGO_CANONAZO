using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sonidos : MonoBehaviour
{
    public AudioSource audioSource;  // Componente AudioSource para reproducir sonidos
    public AudioClip sonidoBoton;    // Sonido que se reproducirá al pulsar botones

    public void IniciarJuego()
    {
        ReproducirSonido(); // Reproducir el sonido al pulsar el botón
    }

    public void ReproducirSonido()
    {
        // Verifica que el AudioSource y el sonido están configurados
        if (audioSource != null && sonidoBoton != null)
        {
            audioSource.PlayOneShot(sonidoBoton); // Reproduce el sonido
        }
    }
}
