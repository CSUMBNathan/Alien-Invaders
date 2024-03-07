using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bullet;
  public Transform shottingOffset;
  public float movementSpeed = 5.0f;
  public float xInput;

    private void Start()
    {
     // Enemy.enemyDeath += onEnemyDeath;

      
    }

    private void OnDestroy()
    {
     // Enemy.enemyDeath -= onEnemyDeath;

    }


    void Update()
    {
      xInput = Input.GetAxisRaw("Horizontal");
      transform.Translate(Vector3.right * (xInput * movementSpeed * Time.deltaTime));
      
      
      
      if (Input.GetKeyDown(KeyCode.Space))
      {
        GetComponent<Animator>().SetTrigger("Shoot Trigger");
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);


        Destroy(shot, 3f);
      }
    }
}
