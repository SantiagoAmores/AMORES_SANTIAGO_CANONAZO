using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{

    public Transform cruceta;              // Cruceta hacia donde disparar�


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Hacer que el ca��n mire hacia la cruceta
        transform.LookAt(cruceta.transform);
    }
}
