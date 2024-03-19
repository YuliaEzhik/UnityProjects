using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalarProduct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 vector1 = new Vector3(1, -5, 7);
        Vector3 vector2 = new Vector3(2, 0, -6);

        float dotProduct = Vector3.Dot(vector1, vector2);
        Debug.Log(dotProduct);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
