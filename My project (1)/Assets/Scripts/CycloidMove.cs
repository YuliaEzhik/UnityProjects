using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycloidMove : MonoBehaviour
{
    public float amplitude;  
    public float speed;      

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = amplitude * (Time.time - Mathf.Sin(Time.time));
        float y = amplitude * (1 - Mathf.Cos(Time.time));

        Vector3 newPosition = new Vector3(x, y, 0);
        Vector3 deltaPosition = newPosition - transform.position;

        transform.Translate(deltaPosition * speed * Time.deltaTime);
    }
}
