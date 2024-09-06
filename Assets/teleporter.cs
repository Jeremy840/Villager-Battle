using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleporter : MonoBehaviour
{
    public bool isActive = false;
    public int teleOn;
    public ParticleSystem ParticleSystem;

    public void Start()
    {
        teleOn = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isActive)
        {
            if (collision.tag == "Player")
            {
                SceneManager.LoadScene(2);
            }
        }
    }

    public void Update()
    {
        if (isActive)
        {
            if (teleOn == 0)
            {
                ParticleSystem.Play();
                teleOn += 1;
            }
        }
    }
}
