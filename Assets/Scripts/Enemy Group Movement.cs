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
    public GameObject bullet;
    public float shootCooldown = 2f; 
    private float shootTimer = 0f; 
    public AudioClip shootSound;
    private AudioSource audioSource;


    
    void Start()
    {
        Enemy.enemyDeath += OnEnemyDeath; 
        audioSource = GetComponent<AudioSource>();

       
    }

    void OnDestroy()
    {
        Enemy.enemyDeath -= OnEnemyDeath; 
    }
    
    private void Update()
    {
        transform.Translate(Vector3.right * (movementSpeed * Time.deltaTime));
        // Update shoot timer
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0)
        {
            Shoot();
            // Reset shoot timer
            shootTimer = shootCooldown;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Boundary"))
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
    
    void Shoot()
    {
        audioSource.PlayOneShot(shootSound);
        int randomIndex = UnityEngine.Random.Range(0, transform.childCount);
        Transform randomEnemyTransform = transform.GetChild(randomIndex);

        // Instantiate a bullet at the random enemy's position
        GameObject newBullet = Instantiate(bullet, randomEnemyTransform.position, Quaternion.identity);
        Destroy(newBullet, 3f);

    }
    
}
