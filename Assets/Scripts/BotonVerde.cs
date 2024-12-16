using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonVerde : MonoBehaviour
{
    public GameObject ultimaBalaDisparada; // Última bala disparada
    public GameObject balaPrefab;          // Prefab de la bala
    public GameObject canon;               // Referencia al cañón
    public Transform posicionInicial;      // Posición inicial de disparo (Empty delante del cañón)
    public Transform cruceta;              // Cruceta hacia donde disparará
    public float fuerzaBalaMin = 5f;       // Fuerza mínima de disparo
    public float fuerzaBalaMax = 50f;      // Fuerza máxima de disparo
    public float tiempoCargaMax = 2f;      // Tiempo máximo para cargar la potencia
    public Renderer canonRenderer;         // Renderer del cañón para cambiar color

    // Variables privadas
    private float fuerzaActual;            // Fuerza de disparo actual
    private float tiempoCargando;          // Tiempo que se ha mantenido presionado el botón
    private bool cargando;                 // Flag para saber si está cargando la potencia
    private Color colorOriginal;

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
        // Verificar si existe una bala activa
        bool existeBalaActiva = ultimaBalaDisparada != null;

        if (existeBalaActiva)
        {
            // Calcular la distancia entre la bala y el cañón
            float distancia = Vector3.Distance(ultimaBalaDisparada.transform.position, canon.transform.position);

            if (distancia <= 5f)
            {
                // Cambiar el color del cañón a rojo
                canonRenderer.material.color = Color.red;
            }
            else
            {
                canonRenderer.material.color = colorOriginal;
            }
        }
        else
        {
            canonRenderer.material.color = colorOriginal;
        }

        // Incrementar la carga si el botón está presionado
        if (cargando)
        {
            tiempoCargando += Time.deltaTime;
            // Calcular la fuerza actual según el tiempo cargado
            fuerzaActual = Mathf.Lerp(fuerzaBalaMin, fuerzaBalaMax, tiempoCargando / tiempoCargaMax);
        }
    }

    private void OnMouseDown()
    {
        // Comenzar a cargar la potencia
        cargando = true;
        tiempoCargando = 0f;
        fuerzaActual = fuerzaBalaMin; // Empezar con la fuerza mínima
    }

    private void OnMouseUp()
    {
        // Dejar de cargar y disparar la bala
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
                // Aplicar fuerza acumulada en la dirección del cañón
                rb.AddForce(canon.transform.forward * fuerzaActual, ForceMode.Impulse);
            }
        }

        // Incrementar el contador de balas
        GameManager.IncNumBalas();
    }
}



