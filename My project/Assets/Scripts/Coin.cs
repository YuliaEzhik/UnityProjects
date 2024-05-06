using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float radius;
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.CoinCollected();
            gameObject.SetActive(false);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FindThePlayer();
    }
    private void FindThePlayer()
    {
        Collider[] CoinColl = Physics.OverlapSphere(transform.position, radius);
        foreach (var c in CoinColl)
        {

            if (c.CompareTag("Player"))
            {
                transform.position = Vector3.MoveTowards(transform.position, c.transform.position + new Vector3(0f, 2f, 0f), Time.deltaTime * 50f);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
