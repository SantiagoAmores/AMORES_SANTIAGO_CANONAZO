using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sonidos : MonoBehaviour
{
    public AudioSource audioSource;  // Componente AudioSource para reproducir sonidos
    public AudioClip sonidoBoton;    // Sonido que se reproducir� al pulsar botones

    public void IniciarJuego()
    {
        ReproducirSonido(); // Reproducir el sonido al pulsar el bot�n
    }

    public void ReproducirSonido()
    {
        // Verifica que el AudioSource y el sonido est�n configurados
        if (audioSource != null && sonidoBoton != null)
        {
            audioSource.PlayOneShot(sonidoBoton); // Reproduce el sonido
        }
    }
}
