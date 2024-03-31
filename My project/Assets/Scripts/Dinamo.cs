using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinamo : MonoBehaviour
{
    public GameObject gravityObject;
    private Rigidbody rb;

    private bool gravityEnabled = false;

    void Start()
    {
        rb = gravityObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gravityEnabled = !gravityEnabled;
            rb.useGravity = gravityEnabled;
        }
    }
}
