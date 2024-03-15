using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyType = 1;
    private int points = 0;


    private static Dictionary<int, int> enemyPoints = new Dictionary<int, int>()
    {
        { 1, 10 }, // Type 1 enemy is worth 10 points
        { 2, 50 }, // Type 2 enemy is worth 50 points
        { 3, 100 }, // Type 3 enemy is worth 100 points
        { 4, 200 } // Type 4 enemy is worth 200 points
    };

    public delegate void EnemyDeathDelegate(int points);
    public static event EnemyDeathDelegate enemyDeath;
    
    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>(); 
        animator.SetInteger("EnemyType", enemyType);
            
        
        if (enemyPoints.TryGetValue(enemyType, out var point))
        {
            points = point;
        }

        
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            enemyDeath?.Invoke(points);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        
        
    }

   
}