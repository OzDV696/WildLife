using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject Perro1_0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Perro1_0 != null)
        {
            Vector3 position = transform.position;
            position.x = Perro1_0.transform.position.x+3;
            //position.y = Perro1_0.transform.position.y;
            transform.position = position;

        }
    }
}