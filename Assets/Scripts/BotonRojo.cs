using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonRojo : MonoBehaviour
{
    // Este método se llama automáticamente cuando se hace clic sobre el objeto.
    private void OnMouseDown()
    {
        // Buscar todos los objetos con el tag "Bala"
        GameObject[] balas = GameObject.FindGameObjectsWithTag("Bala");

        // Recorrer cada objeto encontrado y destruirlo
        foreach (GameObject bala in balas)
        {
            Destroy(bala);
        }
    }
}
