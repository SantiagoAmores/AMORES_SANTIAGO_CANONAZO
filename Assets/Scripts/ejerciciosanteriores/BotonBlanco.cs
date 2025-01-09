using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonBlanco : MonoBehaviour
{
    public GameObject ultimaBalaDisparada;
    public GameObject balaPrefab;
    public GameObject canon;
    public Transform posicionInicial;

    public Renderer canonRenderer;

    // Distancia m�nima para cambiar el color
    public float distanciaCambioColor = 5f;

    // Color original del ca��n
    private Color colorOriginal;


    // Este m�todo se llama autom�ticamente cuando se hace clic sobre el objeto.
    private void OnMouseDown ()
    {

        // Verificar si existe una bala activa
        bool existeBalaActiva = ultimaBalaDisparada != null;

        if (existeBalaActiva)
        {
            // Calcular la distancia entre la bala y el ca��n
            float distancia = Vector3.Distance(ultimaBalaDisparada.transform.position, canon.transform.position);

            if (distancia <= distanciaCambioColor)
            {
                // Cambiar el color del ca��n a rojo
                canonRenderer.material.color = Color.red;
            }
            else
            {
                // Restaurar el color original del ca��n
                canonRenderer.material.color = colorOriginal;
            }
        }
        else
        {
            // Si no hay bala, asegurarse de que el ca��n tenga su color original
            canonRenderer.material.color = colorOriginal;
        }

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

        GameManager.IncNumBalas();
    }
}
