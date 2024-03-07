using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyGroupMovement : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    public float speedIncreaseOnDeath = 1.0f;
    public float yDisplacement = 1.0f;
    
    void Start()
    {
        Enemy.enemyDeath += OnEnemyDeath; 
       
    }

    void OnDestroy()
    {
        Enemy.enemyDeath -= OnEnemyDeath; 
    }
    
    private void Update()
    {
        transform.Translate(Vector3.right * (movementSpeed * Time.deltaTime));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Boundry"))
        {
            var transform1 = transform;
            var position = transform1.position;
            
            position = new Vector3(position.x, position.y - yDisplacement, position.z);
            transform1.position = position;

            movementSpeed *= -1;
        }
    }
    
    void OnEnemyDeath(int points)
    {
        if (movementSpeed > 0)
        {
            movementSpeed += speedIncreaseOnDeath;
        }
        else
        {
            movementSpeed -= speedIncreaseOnDeath;
        }
    }
    
}
