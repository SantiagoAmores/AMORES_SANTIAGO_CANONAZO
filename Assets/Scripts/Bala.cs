using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    // A�adir el prefab de la bala
    public GameObject ultimaBalaDisparada;
    public GameObject balaPrefab;
    public GameObject canon;

    // A�adir posici�n desde la que sale
    public Transform posicionInicial;

    // Distancia m�nima para cambiar el color
    public float distanciaCambioColor = 5f;

    // Color original del ca��n
    private Color colorOriginal;

    // Referencia al Renderer del objeto dentro del ca��n
    private Renderer canonRenderer;

    private void Start()
    {
        // Obtener el Renderer del ca��n y guardar su color original
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

        // Obtener el Renderer de la �ltima bala disparada
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

