using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameObject numBalasText;
    static public GameObject numDianasText;
    static public GameObject numFuerzaText;
    static int numBalas = 0;
    static int numDianas = 0;
    static int numFuerza = 0;
   
    void Start()
    {
        numBalasText = GameObject.Find("TextoBalas");

        if (numBalasText != null )
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
    }

    void Update()
    {        
        // De momento nada
    }

    static public void ResetearBalas()
    {
        // Poner el n�mero de balas a cero y cambiar el texto del canvas
        numBalas = 0;
        if ( numBalasText != null ) 
        {
            TextMeshProUGUI textoTMP1 = numBalasText.GetComponent<TextMeshProUGUI>();
            textoTMP1.text = "Balas: " + numBalas;
        }
    }

    static public void IncNumBalas()
    {
        // Incrementar el n�mero de balas y cambiar el texto del canvas
        numBalas++;
        if (numBalasText != null)
        {
            TextMeshProUGUI textoTMP1 = numBalasText.GetComponent<TextMeshProUGUI>();
            textoTMP1.text = "Balas: " + numBalas;
        }
    }

    static public void DecNumBalas()
    {
        // Decrementar el n�mero de balas y cambiar el texto del canvas
        numBalas--;
        if (numBalasText != null)
        {
            TextMeshProUGUI textoTMP1 = numBalasText.GetComponent<TextMeshProUGUI>();
            textoTMP1.text = "Balas: " + numBalas;
        }
    }

    static public void IncNumDianas()
    {
        // Incrementar el n�mero de balas y cambiar el texto del canvas
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
}
