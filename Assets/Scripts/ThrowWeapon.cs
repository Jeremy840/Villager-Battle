using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowWeapon : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float damageValue = 50f;


private Rigidbody2D rb;
    private Vector2 movementDirection;
    private Animator Anim;
    public GameObject hitSound;
    float x, y;
    float time;

    Vector3 direction;
    private Camera mainCam;
    Vector3 mousePos;

    // Gold drop variable
    public GameObject Gold;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * movementSpeed;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        if (MainManager.Instance.throwPowerValue != 0)
        {
            movementSpeed = MainManager.Instance.throwPowerValue;
        }
        if (MainManager.Instance.damageValue != 0)
        {
            damageValue = MainManager.Instance.damageValue;
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            //Enemy obj = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
            Enemy obj1 = collision.gameObject.GetComponent<Enemy>();
            Instantiate(hitSound);
            obj1.TakeDamage(damageValue);
            //obj.TakeDamage(damageValue);
        }
        if (collision.tag == "Border")
        {
            Destroy(gameObject);
        }
    }
}
