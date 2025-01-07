using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menuPrincipal; // Panel del menú principal
    public GameObject menuCreditos; // Panel del menú créditos

    public void IniciarJuego()
    {
        SceneManager.LoadScene("SampleScene"); // Cargar la escena principal
    }
    void Start()
    {
        // Configurar los objetos al inicio del juego
        menuPrincipal.SetActive(true);   // Mostrar menú principal
        menuCreditos.SetActive(false);   // Mostrar menú créditos
    }
}
