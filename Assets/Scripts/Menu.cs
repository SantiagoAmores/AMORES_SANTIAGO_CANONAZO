using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menuPrincipal; // Panel del men� principal
    public GameObject menuCreditos; // Panel del men� cr�ditos

    public void IniciarJuego()
    {
        SceneManager.LoadScene("SampleScene"); // Cargar la escena principal
    }
    void Start()
    {
        // Configurar los objetos al inicio del juego
        menuPrincipal.SetActive(true);   // Mostrar men� principal
        menuCreditos.SetActive(false);   // Mostrar men� cr�ditos
    }
}
