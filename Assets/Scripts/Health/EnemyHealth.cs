using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject gold;
    public GameObject deathSound;
    public float health;

    void Start()
    {
        health = 100f;
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(gold, transform.position, Quaternion.identity);
            Instantiate(deathSound, transform.position, Quaternion.identity);
        }
    }


}