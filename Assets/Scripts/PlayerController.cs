using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Unity.VisualScripting.Member;

public class PlayerController : MonoBehaviour
{
    // Movement Variables
    public float movementSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 movementDirection;

    // Animation Variables
    private Animator Anim;

    // Enemy Attack Speed
    float timeBetweenAttacks = 0.6f;
    float nextAttacktime;

    // Sound effects
    public GameObject hitSound;
    public GameObject CoinSound;

    // Change Weapon Variables
    public SpriteRenderer rend;
    public Sprite player;
    public Sprite playerPickaxe;
    public Sprite playerTorch;
    public Sprite playerSword;

    // Throw Weapon Variales
    public GameObject Pickaxe;
    public GameObject Sword;

    // Gold Count
    public TMP_Text CoinCount;
    public int CoinAmount;
    void Start()
    {
        if (MainManager.Instance.currentSprite != null)
        {
            rend.sprite = MainManager.Instance.currentSprite;
        }
        CoinAmount = MainManager.Instance.gold;
        CoinCount.text = CoinAmount.ToString();
        rend = GetComponent<SpriteRenderer>();
        Anim = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        if (MainManager.Instance.moveSpeedValue != 0)
        {
            movementSpeed = MainManager.Instance.moveSpeedValue;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Animation
        if (rb.velocity.magnitude <= 0.5)
        {
            Anim.SetTrigger("PlayerIdle");
        }
        else
        {
            Anim.SetTrigger("PlayerMove");
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = movementDirection * movementSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        nextAttacktime = Time.time + timeBetweenAttacks;
        if (collision.tag == "Pickaxe")
        {
            Destroy(collision.gameObject);
            rend.sprite = playerPickaxe;
            MainManager.Instance.currentSprite = playerPickaxe;
        }

        if (collision.tag == "Sword")
        {
            Destroy(collision.gameObject);
            rend.sprite = playerSword;
            MainManager.Instance.currentSprite = playerSword;
        }

        if (collision.tag == "Torch")
        {
            Destroy(collision.gameObject);
            rend.sprite = playerTorch;
            MainManager.Instance.currentSprite = playerTorch;
        }

        if (collision.tag == "Enemy")
        {
            Instantiate(hitSound);
            // Get damage
            Enemy obj = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
            float enemyDamage = obj.damageValue(obj.damage);

            // Get health function
            Health obj1 = GameObject.FindGameObjectWithTag("Health").GetComponent<Health>();
            obj1.DamagePlayer(enemyDamage);
        }

        if (collision.tag == "Gold")
        {
            Instantiate(CoinSound, gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            CoinAmount += 1;
            MainManager.Instance.NewGoldValue(CoinAmount);
            CoinCount.text = CoinAmount.ToString();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            
            if (Time.time > nextAttacktime)
                {
                    nextAttacktime = Time.time + timeBetweenAttacks;

                Instantiate(hitSound);
                // Get damage
                Enemy obj = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
                    float enemyDamage = obj.damageValue(10f);

                    // Get health function
                    Health obj1 = GameObject.FindGameObjectWithTag("Health").GetComponent<Health>();
                    obj1.DamagePlayer(enemyDamage);
                }

               
        }
    }
}
