using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonBlanco : MonoBehaviour
{
    public GameObject ultimaBalaDisparada;
    public GameObject balaPrefab;
    public GameObject canon;
    public Transform posicionInicial;


    // Este método se llama automáticamente cuando se hace clic sobre el objeto.
    private void OnMouseDown ()
    {
            // Instanciar la bala en la posición inicial con su rotación
            GameObject bala = Instantiate(balaPrefab, posicionInicial.position, posicionInicial.rotation);

            // Asegurar que la bala tenga el tag "Bala"
            bala.tag = "Bala";

            // Tamaño aleatorio para la bala
            float escalaAleatoria = Random.Range(0.5f, 2f); // Valores de escala (mínimo 0.5, máximo 2)
            bala.transform.localScale = new Vector3(escalaAleatoria, escalaAleatoria, escalaAleatoria);

            // Fuerza aleatoria
            float fuerzaAleatoria = Random.Range(300f, 1000f); // Valores de fuerza (mínimo 300, máximo 1000)
            Rigidbody rb = bala.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(posicionInicial.forward * fuerzaAleatoria);
            }

            // Color aleatorio entre los 5 básicos (rojo, verde, azul, amarillo, magenta)
            Color[] coloresBasicos = { Color.red, Color.green, Color.blue, Color.yellow, Color.magenta };
            Color colorAleatorio = coloresBasicos[Random.Range(0, coloresBasicos.Length)];

            Renderer balaRenderer = bala.GetComponent<Renderer>();
            if (balaRenderer != null)
            {
                balaRenderer.material.color = colorAleatorio;
            }
    }
}
