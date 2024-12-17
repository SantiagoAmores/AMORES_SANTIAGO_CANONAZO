using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonVerde : MonoBehaviour
{
    public GameObject ultimaBalaDisparada; // Última bala disparada
    public GameObject balaPrefab;          // Prefab de la bala
    public GameObject canon;               // Referencia al cañón
    public Transform posicionInicial;      // Posición inicial de disparo
    public Transform cruceta;              // Cruceta hacia donde disparará
    public float fuerzaBalaMin = 5f;       // Fuerza mínima
    public float fuerzaBalaMax = 20f;      // Fuerza máxima
    public float tiempoCargaMax = 2f;      // Tiempo máximo para cargar la fuerza
    public float distanciaCambioColor = 5f; // Distancia mínima para cambiar el color del cañón
    public Renderer canonRenderer;         // Renderer del cañón para cambiar color

    private float tiempoCargando;          // Tiempo actual de carga
    private float fuerzaActual;            // Fuerza acumulada
    private bool cargando = false;         // Si se está cargando la fuerza
    private Color colorOriginal;           // Color original del cañón

    private void Start()
    {
        // Guardar el color original del cañón
        if (canonRenderer != null)
        {
            colorOriginal = canonRenderer.material.color;
        }
    }

    private void Update()
    {
        if (cargando)
        {
            // Incrementar el tiempo de carga
            tiempoCargando += Time.deltaTime;

            // Calcular la fuerza actual usando interpolación
            fuerzaActual = Mathf.Lerp(fuerzaBalaMin, fuerzaBalaMax, tiempoCargando / tiempoCargaMax);

            // Actualizar la fuerza en el Canvas
            GameManager.FuerzaBala(fuerzaActual);
        }

        // Verificar si existe una bala activa
        if (ultimaBalaDisparada != null)
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
            // Si no hay bala, restaurar el color original del cañón
            canonRenderer.material.color = colorOriginal;
        }
    }

    private void OnMouseDown()
    {
       
        // Iniciar la carga
        cargando = true;
        tiempoCargando = 0f;
        fuerzaActual = fuerzaBalaMin; // Comenzar con la fuerza mínima

        // Mostrar fuerza inicial en el Canvas
        GameManager.FuerzaBala(fuerzaActual);
    }

    private void OnMouseUp()
    {
        // Detener la carga
        cargando = false;

        // Validar que todo esté asignado
        if (posicionInicial != null && cruceta != null && balaPrefab != null && canon != null)
        {
            // Hacer que el cañón mire hacia la cruceta
            canon.transform.LookAt(cruceta);

            // Instanciar la bala en la posición inicial
            ultimaBalaDisparada = Instantiate(balaPrefab, posicionInicial.position, Quaternion.identity);

            // Obtener el Rigidbody de la bala
            Rigidbody rb = ultimaBalaDisparada.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Aplicar fuerza en la dirección del cañón
                rb.AddForce(canon.transform.forward * fuerzaActual, ForceMode.Impulse);
            }
        }

        // Incrementar el contador de balas
        GameManager.IncNumBalas();
    }
}



