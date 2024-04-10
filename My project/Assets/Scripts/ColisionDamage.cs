using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionDamage : MonoBehaviour
{
    public int colisionDamage = 10;
    public string colisionTag;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == colisionTag)
        {
            Health health = collision.gameObject.GetComponent<Health>();
            health.TakeHit(colisionDamage);
        }
    }
}
