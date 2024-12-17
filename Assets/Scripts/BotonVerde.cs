using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BotonVerde : MonoBehaviour
{
    public GameObject ultimaBalaDisparada; // Última bala disparada
    public GameObject balaPrefab;          // Prefab de la bala
    public GameObject canon;               // Referencia al cañón
    public Transform posicionInicial;      // Posición inicial de disparo
    public Transform cruceta;              // Cruceta hacia donde disparará
    public Renderer canonRenderer;         // Renderer del cañón para cambiar color
    public float fuerzaBalaMin = 5f;       // Fuerza mínima
    public float fuerzaBalaMax = 20f;      // Fuerza máxima
    public float tiempoCargaMax = 2f;      // Tiempo máximo para cargar la fuerza
    public float distanciaCambioColor = 5f; // Distancia mínima para cambiar el color del cañón

    private float tiempoInicio;            // Tiempo al iniciar la carga
    private float tiempoCargando;          // Tiempo actual acumulado
    private float fuerzaActual;            // Fuerza calculada
    private bool cargando = false;         // Indicador de carga activa
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
            // Calcular el tiempo de carga acumulado
            tiempoCargando = Time.time - tiempoInicio;

            // Calcular la fuerza actual manualmente
            if (tiempoCargando >= tiempoCargaMax)
            {
                fuerzaActual = fuerzaBalaMax;
            }
            else
            {
                float porcentajeCarga = tiempoCargando / tiempoCargaMax;
                fuerzaActual = (fuerzaBalaMax - fuerzaBalaMin) * porcentajeCarga + fuerzaBalaMin;
            }

            // Actualizar la fuerza en el Canvas
            GameManager.FuerzaBala(fuerzaActual);
        }

        // Verificar si la bala está dentro de la distancia para cambiar el color del cañón
        if (ultimaBalaDisparada != null)
        {
            float distancia = Vector3.Distance(ultimaBalaDisparada.transform.position, canon.transform.position);

            if (distancia <= distanciaCambioColor)
            {
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
    }

    private void OnMouseDown()
    {
        // Cambiar el color del cañón al iniciar la carga
        if (canonRenderer != null)
        {
            canonRenderer.material.color = Color.red;
        }

        // Iniciar la carga
        cargando = true;
        tiempoInicio = Time.time;
        tiempoCargando = 0f;
        fuerzaActual = fuerzaBalaMin;

        // Actualizar la fuerza inicial en el Canvas
        GameManager.FuerzaBala(fuerzaActual);
    }

    private void OnMouseUp()
    {
        // Detener la carga
        cargando = false;

        // Restaurar el color original del cañón
        if (canonRenderer != null)
        {
            canonRenderer.material.color = colorOriginal;
        }

        // Disparar la bala
        if (posicionInicial != null && cruceta != null && balaPrefab != null && canon != null)
        {
            // Instanciar la bala en la posición inicial
            ultimaBalaDisparada = Instantiate(balaPrefab, posicionInicial.position, Quaternion.identity);

            // Calcular la dirección de disparo desde el cañón hacia la cruceta
            Vector3 direccionDisparo = (cruceta.position - canon.transform.position).normalized;

            // Obtener el Rigidbody de la bala y aplicar la fuerza
            Rigidbody rb = ultimaBalaDisparada.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(direccionDisparo * fuerzaActual, ForceMode.Impulse);
            }
        }

        // Incrementar el contador de balas
        GameManager.IncNumBalas();

    }
}





