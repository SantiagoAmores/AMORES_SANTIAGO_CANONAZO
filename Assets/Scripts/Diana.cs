using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diana : MonoBehaviour
{
    // Tag para identificar las balas
    public string tagBala = "Bala";
    int contador = 0;
    bool rotarDiana = false;

    // Lista de posiciones para reaparecer
    public Transform[] posicionesReaparicion; // Asigna Empty en el Inspector

    // Prefab de la diana para reaparecer
    public GameObject dianaPrefab;

    // Si el Collider está configurado como "Trigger"
    private void OnTriggerEnter(Collider collision)
    {
        // Comprobar si el objeto que entra en el trigger tiene el tag de bala
        if (collision.gameObject.CompareTag(tagBala))
        {
            Destroy(collision.gameObject); // Destruir la bala
            GameManager.DecNumBalas();

            if (contador == 0)
            {
                GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                contador++;
            }
            else if (contador == 1)
            {
                rotarDiana = true;
                contador++;
            }
            else if (contador == 2)
            {
                // Reaparecer la diana en una posición aleatoria
                ReaparecerDiana();
                Destroy(gameObject); // Destruir la diana actual

                GameManager.IncNumDianas();

            }
        }
    }

    private void Update()
    {
        if (rotarDiana)
        {
            transform.Rotate(0, 0, (50 * Time.deltaTime));
        }
    }

    private void ReaparecerDiana()
    {
        // Verificar que existan posiciones en el array
        if (posicionesReaparicion.Length > 0 && dianaPrefab != null)
        {
            // Elegir una posición aleatoria del array
            int indiceAleatorio = Random.Range(0, posicionesReaparicion.Length);
            Transform posicionSeleccionada = posicionesReaparicion[indiceAleatorio];

            // Instanciar una nueva diana en la posición seleccionada
            Instantiate(dianaPrefab, posicionSeleccionada.position, posicionSeleccionada.rotation);
        }
        else
        {
            Debug.LogWarning("No se han asignado posiciones de reaparición o prefab de diana.");
        }
    }
}


