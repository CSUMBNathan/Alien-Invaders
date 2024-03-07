using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("asf");
        if (collision.gameObject.CompareTag("Bullet"))
        {
            DestroyBarricade();
            Destroy(collision.gameObject); // Destroy the bullet
        }
    }

    void DestroyBarricade()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        Destroy(gameObject); 
        
    }    

}