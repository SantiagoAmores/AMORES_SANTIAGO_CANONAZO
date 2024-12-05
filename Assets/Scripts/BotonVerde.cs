using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonVerde : MonoBehaviour
{
    public GameObject ultimaBalaDisparada;
    public GameObject balaPrefab;
    public GameObject canon;
    public Transform posicionInicial;
    public float fuerzaBala;

    // Este m�todo se llama autom�ticamente cuando se hace clic sobre el objeto.
    private void OnMouseDown()
    {
        if (posicionInicial != null && canon != null)
        {
            // Instanciar la bala en la posici�n del empty y con su rotaci�n
            ultimaBalaDisparada = Instantiate(balaPrefab, posicionInicial.position, posicionInicial.rotation);

            // Asegurar que la bala tenga el tag "Bala"
            ultimaBalaDisparada.tag = "Bala";

            // A�adir fuerza para que la bala salga disparada
            Rigidbody rb = ultimaBalaDisparada.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(posicionInicial.forward * fuerzaBala);

            }
        }
    }
}

