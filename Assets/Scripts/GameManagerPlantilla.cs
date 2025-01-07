using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameObject numBalasText;
    static public GameObject numDianasText;
    static public GameObject numFuerzaText;
    static public GameObject timerText;

    static int numBalas = 0;
    static int numDianas = 0;
    static int numFuerza = 0;

    static float tiempoRestante = 20f; // Temporizador en segundos
    bool temporizadorActivo = true;    // Controla si el temporizador está activo

    public GameObject botonesCanvas;
    public GameObject dianasParent;
    public GameObject mirilla;
    public GameObject victoria;
    public GameObject derrota;

    public Animator animacionFinPartida;

    public TextMeshProUGUI textoVictoria;
    public TextMeshProUGUI textoDerrota;

    void Start()
    {
        numBalasText = GameObject.Find("TextoBalas");

        if (numBalasText != null)
        {
            TextMeshProUGUI textoTMP1 = numBalasText.GetComponent<TextMeshProUGUI>();
            textoTMP1.text = "Balas: " + numBalas;
        }

        numDianasText = GameObject.Find("TextoDianas");

        if (numDianasText != null)
        {
            TextMeshProUGUI textoTMP2 = numDianasText.GetComponent<TextMeshProUGUI>();
            textoTMP2.text = "Dianas: " + numDianas;
        }

        numFuerzaText = GameObject.Find("TextoFuerza");

        if (numFuerzaText != null)
        {
            TextMeshProUGUI textoTMP2 = numFuerzaText.GetComponent<TextMeshProUGUI>();
            textoTMP2.text = "Fuerza: " + numFuerza;
        }

        timerText = GameObject.Find("TextoTemporizador");

        if (timerText != null)
        {
            TextMeshProUGUI textoTMP3 = timerText.GetComponent<TextMeshProUGUI>();
            textoTMP3.text = "Tiempo: " + Mathf.RoundToInt(tiempoRestante);
        }

        derrota.SetActive(false);
        victoria.SetActive(false);
    }

    void Update()
    {
        if (temporizadorActivo)
        {
            // Reducir el tiempo restante cada frame
            tiempoRestante -= Time.deltaTime;

            // Si el tiempo restante es menor o igual a 0, detener el temporizador
            if (tiempoRestante <= 0f)
            {
                tiempoRestante = 0f;
                temporizadorActivo = false;  // Detener el temporizador
                FinalizarJuego();
            }

            // Actualizar el texto del temporizador en la interfaz
            if (timerText != null)
            {
                TextMeshProUGUI textoTMP = timerText.GetComponent<TextMeshProUGUI>();
                textoTMP.text = "Tiempo: " + Mathf.RoundToInt(tiempoRestante);
            }
        }
    }

    static public void ResetearBalas()
    {
        // Poner el número de balas a cero y cambiar el texto del canvas
        numBalas = 0;
        if (numBalasText != null)
        {
            TextMeshProUGUI textoTMP1 = numBalasText.GetComponent<TextMeshProUGUI>();
            textoTMP1.text = "Balas: " + numBalas;
        }
    }

    static public void IncNumBalas()
    {
        // Incrementar el número de balas y cambiar el texto del canvas
        numBalas++;
        if (numBalasText != null)
        {
            TextMeshProUGUI textoTMP1 = numBalasText.GetComponent<TextMeshProUGUI>();
            textoTMP1.text = "Balas: " + numBalas;
        }
    }

    static public void DecNumBalas()
    {
        // Decrementar el número de balas y cambiar el texto del canvas
        numBalas--;
        if (numBalasText != null)
        {
            TextMeshProUGUI textoTMP1 = numBalasText.GetComponent<TextMeshProUGUI>();
            textoTMP1.text = "Balas: " + numBalas;
        }
    }

    static public void IncNumDianas()
    {
        // Incrementar el número de balas y cambiar el texto del canvas
        numDianas++;
        if (numDianasText != null)
        {
            TextMeshProUGUI textoTMP1 = numDianasText.GetComponent<TextMeshProUGUI>();
            textoTMP1.text = "Dianas: " + numDianas;
        }
    }

    static public void FuerzaBala(float potencia)
    {
        // Actualizar el texto de la potencia en el Canvas
        if (numFuerzaText != null)
        {
            TextMeshProUGUI textoTMP3 = numFuerzaText.GetComponent<TextMeshProUGUI>();
            textoTMP3.text = "Fuerza: " + Mathf.RoundToInt(potencia);
        }
    }

    static public void IncTiempo(float segundos)
    {
        // Incrementar el tiempo restante
        tiempoRestante += segundos;

        // Actualizar el texto del temporizador
        if (timerText != null)
        {
            TextMeshProUGUI textoTMP = timerText.GetComponent<TextMeshProUGUI>();
            textoTMP.text = "Tiempo: " + Mathf.RoundToInt(tiempoRestante);
        }
    }

    private void FinalizarJuego()
    {
        // Calcular estadísticas
        int balasDisparadas = numBalas + numDianas; // Total de balas disparadas

        // Calcular la precisión
        float precision = 0f;
        if (numBalas > 0)
        {
            precision = ((float)numDianas / balasDisparadas) * 100f;
        }

        // Comprobar condiciones para victoria o derrota
        if (numDianas >= 5 && precision > 50f)
        {
            victoria.SetActive(true);
            textoVictoria.text = "¡VICTORIA!";
            animacionFinPartida.SetTrigger("IniciarVictoria");
        }
        else
        {
            derrota.SetActive(true);
            textoDerrota.text = "DERROTA...";
            animacionFinPartida.SetTrigger("IniciarDerrota");
        }

        // Mostrar estadísticas en el texto del temporizador
        string mensajeFinal = "Juego Finalizado\nDianas acertadas: " + numDianas + "\n" +
                              "Balas disparadas: " + balasDisparadas + "\n" +
                              "Precisión: " + precision + "%";

        // Crear un objeto en el canvas para mostrar el mensaje
        GameObject mensajeText = GameObject.Find("TextoFinal"); // Asegúrate de tener un objeto en el Canvas llamado "TextoFinal"
        if (mensajeText != null)
        {
            TextMeshProUGUI textoTMP = mensajeText.GetComponent<TextMeshProUGUI>();
            textoTMP.text = mensajeFinal;
        }

        if (timerText != null)
        {
            TextMeshProUGUI textoTMP = timerText.GetComponent<TextMeshProUGUI>();
            textoTMP.text = mensajeFinal;
        }

        // Desactivar botones, dianas y mirilla
        if (botonesCanvas != null)
        {
            botonesCanvas.SetActive(false);
        }
        GameObject[] dianas = GameObject.FindGameObjectsWithTag("Diana");
        foreach (GameObject diana in dianas)
        {
            diana.SetActive(false);
        }
        if (mirilla != null)
        {
            mirilla.SetActive(false);
        }
    }
    }

