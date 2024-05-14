using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceToFinish : MonoBehaviour
{
    public Transform player; 
    public Transform finish; 
    public Text distanceText;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, finish.position);
        distanceText.text = "Distance to Finish: " + distance.ToString("F2");
    }
}
