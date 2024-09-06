using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public float speed;
    private GameObject Player;
    public GameObject gold;
    public GameObject deathSound;
    public GameObject hitMarker;
    public GameObject Upgrade;
    private SpriteRenderer Renderer;
    public float damage = 10f;
    public float health;
    public float maxhealth = 100f;
    public bool hasUpgrade = false;

    [SerializeField] FloatingHealthBar healthBar;

    private void Awake()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }
    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth;
        healthBar.UpdateHealthBar(health, maxhealth);
        Renderer = GetComponent<SpriteRenderer>();
        Player = GameObject.Find("Player");
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        if (transform.position.x - Player.transform.position.x < 0 )
        {
            Renderer.flipX = true;
        } else
        {
            Renderer.flipX = false;
        }
    }

    public float damageValue(float damage)
    {
        return this.damage = damage;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        healthBar.UpdateHealthBar(health, maxhealth);
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(gold, transform.position, Quaternion.identity);
            Instantiate(deathSound, transform.position, Quaternion.identity);

            if (hasUpgrade)
            {
                Instantiate(Upgrade, transform.position, Quaternion.identity);
            }
        }
        else
        {
            Instantiate(hitMarker, transform.position, Quaternion.identity);
        }
    }
}
