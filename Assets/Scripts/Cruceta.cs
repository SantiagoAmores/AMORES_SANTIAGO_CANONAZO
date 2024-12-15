using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cruceta : MonoBehaviour
{
    // Posición del cañón como referencia
    public Transform canon;

    // Velocidad de movimiento de la cruceta
    public float velocidad = 5f;

    // Límites de movimiento en el eje X (izquierda/derecha) y Y (arriba/abajo)
    public float limiteX = 3f;
    public float limiteY = 2f;

    private Vector3 posicionInicial;

    private void Start()
    {
        // Situar la cruceta delante del cañón
        if (canon != null)
        {
            posicionInicial = canon.position + canon.forward * 10f; // 10 unidades delante del cañón
            transform.position = posicionInicial;
        }
    }

    private void Update()
    {
        // Obtener entradas del teclado
        float moverHorizontal = Input.GetAxis("Horizontal"); // A y D (izquierda/derecha)
        float moverVertical = Input.GetAxis("Vertical");     // W y S (arriba/abajo)

        // Calcular el movimiento de la cruceta
        Vector3 movimiento = new Vector3(moverHorizontal, moverVertical, 0) * velocidad * Time.deltaTime;

        // Aplicar movimiento dentro de los límites
        Vector3 nuevaPosicion = transform.position + movimiento;

        // Limitar el movimiento en X e Y, manteniéndolo perpendicular al suelo
        nuevaPosicion.x = Mathf.Clamp(nuevaPosicion.x, posicionInicial.x - limiteX, posicionInicial.x + limiteX);
        nuevaPosicion.y = Mathf.Clamp(nuevaPosicion.y, posicionInicial.y - limiteY, posicionInicial.y + limiteY);
        nuevaPosicion.z = posicionInicial.z; // Mantenerlo fijo en Z (perpendicular al suelo)

        // Asignar la nueva posición
        transform.position = nuevaPosicion;
    }
}
