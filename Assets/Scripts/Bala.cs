using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    // Añadir el prefab de la bala
    public GameObject ultimaBalaDisparada;
    public GameObject balaPrefab;
    public GameObject canon;

    // Añadir posición desde la que sale
    public Transform posicionInicial;

    // Distancia mínima para cambiar el color
    public float distanciaCambioColor = 5f;

    // Color original del cañón
    private Color colorOriginal;

    // Referencia al Renderer del objeto dentro del cañón
    private Renderer canonRenderer;

    private void Start()
    {
        // Obtener el Renderer del cañón y guardar su color original
        if (canon != null)
        {
            canonRenderer = canon.GetComponent<Renderer>();
            if (canonRenderer != null)
            {
                colorOriginal = canonRenderer.material.color;
            }
        }
    }

    private void Update()
    {
        // Si no hay una bala activa, no realizar nada
        if (ultimaBalaDisparada == null) return;

        // Obtener el Renderer de la última bala disparada
        Renderer balaRenderer = ultimaBalaDisparada.GetComponent<Renderer>();

        if (balaRenderer != null)
        {
            float distancia = Vector3.Distance(ultimaBalaDisparada.transform.position, canon.transform.position);

            if (distancia <= distanciaCambioColor)
            {
                // Cambiar a un color rojo
                balaRenderer.material.color = Color.red;
            }
            else
            {
                // Cambiar a color azul como predeterminado
                balaRenderer.material.color = colorOriginal;
            }
        }
    }
}

// si no depende de la posicion mejor el foereach
// esfera.transform.position + Random.insideUnitSphere ---- genera un movimiento aleatorio

