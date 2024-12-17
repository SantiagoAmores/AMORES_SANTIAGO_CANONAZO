using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{

    public Transform cruceta;              // Cruceta hacia donde disparará


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Hacer que el cañón mire hacia la cruceta
        transform.LookAt(cruceta.transform);
    }
}
