using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonRojo : MonoBehaviour
{
    // Este m�todo se llama autom�ticamente cuando se hace clic sobre el objeto.
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
