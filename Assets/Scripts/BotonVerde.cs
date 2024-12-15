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

    // Distancia m�nima para cambiar el color
    public float distanciaCambioColor = 5f;

    // Color original del ca��n
    private Color colorOriginal;

    private void Update()
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
    }

    // Este m�todo se llama autom�ticamente cuando se hace clic sobre el objeto.
    private void OnMouseDown ()
    {
        // Validar que todo est� asignado
        if (posicionInicial != null && cruceta != null && balaPrefab != null)
        {
            // Instanciar la bala en la posici�n inicial (delante del ca��n)
            ultimaBalaDisparada = Instantiate(balaPrefab, posicionInicial.position, Quaternion.identity);

            // Obtener el Rigidbody de la bala
            Rigidbody rb = ultimaBalaDisparada.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Calcular la direcci�n desde la posici�n inicial hacia la cruceta
                Vector3 direccionDisparo = (cruceta.position - posicionInicial.position).normalized;

                // Aplicar fuerza en la direcci�n calculada
                rb.AddForce(direccionDisparo * fuerzaBala, ForceMode.Impulse);
            }
        }
        else
        {
            Debug.LogWarning("Aseg�rate de asignar 'posicionInicial', 'cruceta' y 'balaPrefab' en el inspector.");
        }
    }
}

