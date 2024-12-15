using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonVerde : MonoBehaviour
{
    public GameObject ultimaBalaDisparada;
    public GameObject balaPrefab;
    public GameObject canon;
    public Transform posicionInicial;
    public Transform cruceta;
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
        // Validar que todo esté asignado
        if (posicionInicial != null && cruceta != null && balaPrefab != null)
        {
            // Instanciar la bala en la posición inicial (delante del cañón)
            ultimaBalaDisparada = Instantiate(balaPrefab, posicionInicial.position, Quaternion.identity);

            // Obtener el Rigidbody de la bala
            Rigidbody rb = ultimaBalaDisparada.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Calcular la dirección desde la posición inicial hacia la cruceta
                Vector3 direccionDisparo = (cruceta.position - posicionInicial.position).normalized;

                // Aplicar fuerza en la dirección calculada
                rb.AddForce(direccionDisparo * fuerzaBala, ForceMode.Impulse);
            }
        }
        else
        {
            Debug.LogWarning("Asegúrate de asignar 'posicionInicial', 'cruceta' y 'balaPrefab' en el inspector.");
        }
    }
}

