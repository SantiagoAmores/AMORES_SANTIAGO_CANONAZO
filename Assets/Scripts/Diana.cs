using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Diana : MonoBehaviour
{
    // Tag para identificar las balas
    public string tagBala = "Bala";

    // Prefab de la diana para reaparecer
    public GameObject dianaPrefab;

    // Límites de la pared en el plano X e Y
    public float limiteXMin = -26f;
    public float limiteXMax = 26f;
    public float limiteYMin = 4f;
    public float limiteYMax = 18f;

    // Sonido de impacto
    public AudioClip sonidoImpacto;
    public AudioSource audioSource;

    private float tiempoSinImpacto = 0f; // Tiempo que la diana ha estado sin recibir un impacto
    private float tiempoMaximo = 5f;    // Tiempo máximo sin impacto antes de reaparecer

    private void Start()
    {
        
    }

    private void Update()
    {
        // Incrementar el tiempo sin impacto
        tiempoSinImpacto += Time.deltaTime;

        // Si el tiempo sin impacto supera el máximo, reaparecer y destruir la diana actual
        if (tiempoSinImpacto >= tiempoMaximo)
        {
            ReaparecerDiana();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        // Comprobar si el objeto que entra en el trigger tiene el tag de bala
        if (collision.gameObject.CompareTag(tagBala))
        {
            // Reiniciar el contador de tiempo sin impacto
            tiempoSinImpacto = 0f;

            Debug.Log("sonidoimpacto" + sonidoImpacto);
            Debug.Log("audioSource" + audioSource);

            // Reproducir el sonido de impacto
            if (sonidoImpacto != null && audioSource != null)
            {
                Debug.Log("Reproducir sonido");
                audioSource.PlayOneShot(sonidoImpacto);
            }

            Destroy(collision.gameObject); // Destruir la bala
            GameManager.DecNumBalas();

            // Añadir 3 segundos al temporizador
            GameManager.IncTiempo(3f);

            // Reaparecer la diana en una posición aleatoria en el plano X,Y
            ReaparecerDiana();
            Destroy(gameObject); // Destruir la diana actual

            GameManager.IncNumDianas();
        }
    }

    private void ReaparecerDiana()
    {
        // Verificar que el prefab de la diana no sea null
        if (dianaPrefab != null)
        {
            // Elegir una posición aleatoria dentro de los límites en el plano X e Y
            float posX = Random.Range(limiteXMin, limiteXMax);
            float posY = Random.Range(limiteYMin, limiteYMax);

            // Establecer una posición en el plano X,Y
            Vector3 nuevaPosicion = new Vector3(posX, posY, transform.position.z);

            // Instanciar la nueva diana en la posición aleatoria

            Vector3 eulerAngles = new Vector3(-90, 0, 0);
            Quaternion rotation = Quaternion.Euler(eulerAngles);

            Instantiate(dianaPrefab, nuevaPosicion, rotation);
        }
    }
}


