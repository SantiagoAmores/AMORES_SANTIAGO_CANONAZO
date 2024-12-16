using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonVerde : MonoBehaviour
{
    public GameObject ultimaBalaDisparada; // �ltima bala disparada
    public GameObject balaPrefab;          // Prefab de la bala
    public GameObject canon;               // Referencia al ca��n
    public Transform posicionInicial;      // Posici�n inicial de disparo (Empty delante del ca��n)
    public Transform cruceta;              // Cruceta hacia donde disparar�
    public float fuerzaBalaMin = 5f;       // Fuerza m�nima de disparo
    public float fuerzaBalaMax = 50f;      // Fuerza m�xima de disparo
    public float tiempoCargaMax = 2f;      // Tiempo m�ximo para cargar la potencia
    public Renderer canonRenderer;         // Renderer del ca��n para cambiar color

    // Variables privadas
    private float fuerzaActual;            // Fuerza de disparo actual
    private float tiempoCargando;          // Tiempo que se ha mantenido presionado el bot�n
    private bool cargando;                 // Flag para saber si est� cargando la potencia
    private Color colorOriginal;

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
        // Verificar si existe una bala activa
        bool existeBalaActiva = ultimaBalaDisparada != null;

        if (existeBalaActiva)
        {
            // Calcular la distancia entre la bala y el ca��n
            float distancia = Vector3.Distance(ultimaBalaDisparada.transform.position, canon.transform.position);

            if (distancia <= 5f)
            {
                // Cambiar el color del ca��n a rojo
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

        // Incrementar la carga si el bot�n est� presionado
        if (cargando)
        {
            tiempoCargando += Time.deltaTime;
            // Calcular la fuerza actual seg�n el tiempo cargado
            fuerzaActual = Mathf.Lerp(fuerzaBalaMin, fuerzaBalaMax, tiempoCargando / tiempoCargaMax);
        }
    }

    private void OnMouseDown()
    {
        // Comenzar a cargar la potencia
        cargando = true;
        tiempoCargando = 0f;
        fuerzaActual = fuerzaBalaMin; // Empezar con la fuerza m�nima
    }

    private void OnMouseUp()
    {
        // Dejar de cargar y disparar la bala
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
                // Aplicar fuerza acumulada en la direcci�n del ca��n
                rb.AddForce(canon.transform.forward * fuerzaActual, ForceMode.Impulse);
            }
        }

        // Incrementar el contador de balas
        GameManager.IncNumBalas();
    }
}



