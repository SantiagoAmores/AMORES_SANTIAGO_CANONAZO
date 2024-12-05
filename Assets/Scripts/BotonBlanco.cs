using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonBlanco : MonoBehaviour
{
    public GameObject ultimaBalaDisparada;
    public GameObject balaPrefab;
    public GameObject canon;
    public Transform posicionInicial;


    // Este m�todo se llama autom�ticamente cuando se hace clic sobre el objeto.
    private void OnMouseDown ()
    {
            // Instanciar la bala en la posici�n inicial con su rotaci�n
            GameObject bala = Instantiate(balaPrefab, posicionInicial.position, posicionInicial.rotation);

            // Asegurar que la bala tenga el tag "Bala"
            bala.tag = "Bala";

            // Tama�o aleatorio para la bala
            float escalaAleatoria = Random.Range(0.5f, 2f); // Valores de escala (m�nimo 0.5, m�ximo 2)
            bala.transform.localScale = new Vector3(escalaAleatoria, escalaAleatoria, escalaAleatoria);

            // Fuerza aleatoria
            float fuerzaAleatoria = Random.Range(300f, 1000f); // Valores de fuerza (m�nimo 300, m�ximo 1000)
            Rigidbody rb = bala.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(posicionInicial.forward * fuerzaAleatoria);
            }

            // Color aleatorio entre los 5 b�sicos (rojo, verde, azul, amarillo, magenta)
            Color[] coloresBasicos = { Color.red, Color.green, Color.blue, Color.yellow, Color.magenta };
            Color colorAleatorio = coloresBasicos[Random.Range(0, coloresBasicos.Length)];

            Renderer balaRenderer = bala.GetComponent<Renderer>();
            if (balaRenderer != null)
            {
                balaRenderer.material.color = colorAleatorio;
            }
    }
}
