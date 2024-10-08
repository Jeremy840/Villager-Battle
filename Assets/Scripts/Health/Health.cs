using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float curHealth = 100f;
    public float maxHealth = 100f;
    public Image healthBar;

    void Start()
    {
        curHealth = maxHealth;
    }

    void Update()
    {
        if (curHealth <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }

    public void DamagePlayer(float damage)
    {
        curHealth -= damage;
        healthBar.fillAmount = curHealth / 100f;
    }

    public void Heal(float healingAmount)
    {
        healingAmount += healingAmount;
        maxHealth = Mathf.Clamp(maxHealth, 0, 100);

        healthBar.fillAmount = maxHealth / 100f;
    }
}