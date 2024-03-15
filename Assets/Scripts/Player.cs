using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public AudioClip shootSound;
  public AudioClip deathSound;
  public GameObject bullet;
  public Transform shottingOffset;
  public float movementSpeed = 5.0f;
  public float xInput;
  
  public delegate void PlayerDeathDelegate();
  public static event PlayerDeathDelegate playerDeath;
  private AudioSource audioSource;


    private void Start()
    {
      
      audioSource = GetComponent<AudioSource>();
      
    }

    private void OnDestroy()
    {

    }


    void Update()
    {
      xInput = Input.GetAxisRaw("Horizontal");
      transform.Translate(Vector3.right * (xInput * movementSpeed * Time.deltaTime));
      
      
      
      if (Input.GetKeyDown(KeyCode.Space))
      {
        audioSource.PlayOneShot(shootSound);

        GetComponent<Animator>().SetTrigger("Shoot Trigger");
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);


        Destroy(shot, 3f);
      }
      
      
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
      audioSource.PlayOneShot(deathSound);

      if (collision.gameObject.CompareTag("EnemyBullet"))
      {
        playerDeath?.Invoke();
        Destroy(gameObject);
        Destroy(collision.gameObject);
      }
    }
    
}
