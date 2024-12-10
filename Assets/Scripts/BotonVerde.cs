using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonVerde : MonoBehaviour
{
    public GameObject ultimaBalaDisparada;
    public GameObject balaPrefab;
    public GameObject canon;
    public Transform posicionInicial;
    public float fuerzaBala;
    public Renderer canonRenderer;

    // Distancia mínima para cambiar el color
    public float distanciaCambioColor = 5f;

    // Color original del cañón
    private Color colorOriginal;

    private void Update()
    {
        // Verificar si existe una bala activa
        bool existeBalaActiva = ultimaBalaDisparada != null;

        if (existeBalaActiva)
        {
            // Calcular la distancia entre la bala y el cañón
            float distancia = Vector3.Distance(ultimaBalaDisparada.transform.position, canon.transform.position);

            if (distancia <= distanciaCambioColor)
            {
                // Cambiar el color del cañón a rojo
                canonRenderer.material.color = Color.red;
            }
            else
            {
                // Restaurar el color original del cañón
                canonRenderer.material.color = colorOriginal;
            }
        }
        else
        {
            // Si no hay bala, asegurarse de que el cañón tenga su color original
            canonRenderer.material.color = colorOriginal;
        }
    }

    // Este método se llama automáticamente cuando se hace clic sobre el objeto.
    private void OnMouseDown ()
    {
            if (posicionInicial != null && canon != null)
            {
                // Instanciar la bala en la posición del empty y con su rotación
                ultimaBalaDisparada = Instantiate(balaPrefab, posicionInicial.position, posicionInicial.rotation);

                // Asegurar que la bala tenga el tag "Bala"
                ultimaBalaDisparada.tag = "Bala";

                // Añadir fuerza para que la bala salga disparada
                Rigidbody rb = ultimaBalaDisparada.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddForce(posicionInicial.forward * fuerzaBala);

                }
            }

            GameManager.IncNumBalas();

    }
}

