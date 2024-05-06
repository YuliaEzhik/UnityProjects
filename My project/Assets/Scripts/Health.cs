using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;
    private Animator animator;
    public void TakeHit(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            animator.SetBool("Life", false);
           // Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } 
    }
}
