using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void OnTriggerEnter(Collider collision)
    {
        // Comprobar si el objeto que entra en el trigger tiene el tag de bala
        if (collision.gameObject.CompareTag(tagBala))
        {
            Destroy(collision.gameObject); // Destruir la bala
            GameManager.DecNumBalas();

                // Reaparecer la diana en una posición aleatoria en el plano X,Y
                ReaparecerDiana();
                Destroy(gameObject); // Destruir la diana actual

                GameManager.IncNumDianas();
    
        }
    }

    private void Update()
    {
        // Sin ninguna rotación o cambio de color, no hace falta código aquí
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
            Instantiate(dianaPrefab, nuevaPosicion, Quaternion.identity);
        }
    }
}

