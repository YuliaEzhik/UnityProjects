using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenaltyKick : MonoBehaviour
{
    public GameObject ball;
    public GameObject goal; 
    public float kickForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 direction = (goal.transform.position - ball.transform.position).normalized;
            Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
            ballRigidbody.AddForce(direction * kickForce, ForceMode.Impulse);
        }
    }
}
