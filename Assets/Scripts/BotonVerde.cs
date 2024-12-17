using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonVerde : MonoBehaviour
{
    public GameObject ultimaBalaDisparada; // �ltima bala disparada
    public GameObject balaPrefab;          // Prefab de la bala
    public GameObject canon;               // Referencia al ca��n
    public Transform posicionInicial;      // Posici�n inicial de disparo
    public Transform cruceta;              // Cruceta hacia donde disparar�
    public float fuerzaBalaMin = 5f;       // Fuerza m�nima
    public float fuerzaBalaMax = 20f;      // Fuerza m�xima
    public float tiempoCargaMax = 2f;      // Tiempo m�ximo para cargar la fuerza
    public float distanciaCambioColor = 5f; // Distancia m�nima para cambiar el color del ca��n
    public Renderer canonRenderer;         // Renderer del ca��n para cambiar color

    private float tiempoCargando;          // Tiempo actual de carga
    private float fuerzaActual;            // Fuerza acumulada
    private bool cargando = false;         // Si se est� cargando la fuerza
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
            // Incrementar el tiempo de carga
            tiempoCargando += Time.deltaTime;

            // Calcular la fuerza actual usando interpolaci�n
            fuerzaActual = Mathf.Lerp(fuerzaBalaMin, fuerzaBalaMax, tiempoCargando / tiempoCargaMax);

            // Actualizar la fuerza en el Canvas
            GameManager.FuerzaBala(fuerzaActual);
        }

        // Verificar si existe una bala activa
        if (ultimaBalaDisparada != null)
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
            // Si no hay bala, restaurar el color original del ca��n
            canonRenderer.material.color = colorOriginal;
        }
    }

    private void OnMouseDown()
    {
       
        // Iniciar la carga
        cargando = true;
        tiempoCargando = 0f;
        fuerzaActual = fuerzaBalaMin; // Comenzar con la fuerza m�nima

        // Mostrar fuerza inicial en el Canvas
        GameManager.FuerzaBala(fuerzaActual);
    }

    private void OnMouseUp()
    {
        // Detener la carga
        cargando = false;

        // Validar que todo est� asignado
        if (posicionInicial != null && cruceta != null && balaPrefab != null && canon != null)
        {
            // Hacer que el ca��n mire hacia la cruceta
            canon.transform.LookAt(cruceta);

            // Instanciar la bala en la posici�n inicial
            ultimaBalaDisparada = Instantiate(balaPrefab, posicionInicial.position, Quaternion.identity);

            // Obtener el Rigidbody de la bala
            Rigidbody rb = ultimaBalaDisparada.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Aplicar fuerza en la direcci�n del ca��n
                rb.AddForce(canon.transform.forward * fuerzaActual, ForceMode.Impulse);
            }
        }

        // Incrementar el contador de balas
        GameManager.IncNumBalas();
    }
}



