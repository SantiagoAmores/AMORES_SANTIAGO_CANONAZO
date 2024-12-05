using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diana : MonoBehaviour
{
    // Tag para identificar las balas
    public string tagBala = "Bala";
    int contador = 0;
    bool rotarDiana = false;

    // Si el Collider est� configurado como "Trigger"
    private void OnTriggerEnter(Collider other)
    {
        // Comprobar si el objeto que entra en el trigger tiene el tag de bala
        if (other.gameObject.CompareTag(tagBala))
        {
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
                // Destruir la diana
                Destroy(gameObject);
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
}

