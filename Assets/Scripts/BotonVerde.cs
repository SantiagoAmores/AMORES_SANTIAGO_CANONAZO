using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BotonVerde : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject ultimaBalaDisparada; // �ltima bala disparada
    public GameObject balaPrefab;          // Prefab de la bala
    public GameObject canon;               // Referencia al ca��n
    public Transform posicionInicial;      // Posici�n inicial de disparo
    public Transform cruceta;              // Cruceta hacia donde disparar�
    public Renderer canonRenderer;         // Renderer del ca��n para cambiar color
    public float fuerzaBalaMin = 5f;       // Fuerza m�nima
    public float fuerzaBalaMax = 20f;      // Fuerza m�xima
    public float tiempoCargaMax = 2f;      // Tiempo m�ximo para cargar la fuerza
    public float distanciaCambioColor = 5f; // Distancia m�nima para cambiar el color del ca��n

    private float tiempoInicio;            // Tiempo al iniciar la carga
    private float tiempoCargando;          // Tiempo actual acumulado
    private float fuerzaActual;            // Fuerza calculada
    private bool cargando = false;         // Indicador de carga activa
    private Color colorOriginal;           // Color original del ca��n

    private void Start()
    {
        // Guardar el color original del ca��n
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

        // Verificar si la bala est� dentro de la distancia para cambiar el color del ca��n
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

    // Esta funci�n se llama cuando el bot�n es presionado (comienza la carga)
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!cargando)
        {
            // Cambiar el color del ca��n al iniciar la carga
            if (canonRenderer != null)
            {
                canonRenderer.material.color = Color.red;
            }

            // Comenzar la carga
            cargando = true;
            tiempoInicio = Time.time;
            tiempoCargando = 0f;
            fuerzaActual = fuerzaBalaMin;

            // Actualizar la fuerza inicial en el Canvas
            GameManager.FuerzaBala(fuerzaActual);
        }
    }

    // Esta funci�n se llama cuando el bot�n es liberado (dispara la bala)
    public void OnPointerUp(PointerEventData eventData)
    {
        // Detener la carga
        cargando = false;

        // Restaurar el color original del ca��n
        if (canonRenderer != null)
        {
            canonRenderer.material.color = colorOriginal;
        }

        // Disparar la bala
        DispararBala();
    }

    private void DispararBala()
    {
        // Disparar la bala
        if (posicionInicial != null && cruceta != null && balaPrefab != null && canon != null)
        {
            // Instanciar la bala en la posici�n inicial
            ultimaBalaDisparada = Instantiate(balaPrefab, posicionInicial.position, Quaternion.identity);

            // Calcular la direcci�n de disparo desde el ca��n hacia la cruceta
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






