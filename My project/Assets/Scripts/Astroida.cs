using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroida : MonoBehaviour
{
    public float amplitude;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = amplitude * Mathf.Cos(Time.time);
        float y = amplitude * Mathf.Sin(Time.time);

        Vector3 newPosition = new Vector3(x, y, 0);
        Vector3 deltaPosition = newPosition;

        transform.Translate(deltaPosition * speed * Time.deltaTime);
    }
}
