using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;

    public GameObject Rock;
    public GameObject Pickaxe;
    public GameObject Sword;
    public GameObject Torch;

    public Transform weaponTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    private void Awake()
    {
        PauseMenu PauseMenu = GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<PauseMenu>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (MainManager.Instance.fireRateValue != 0)
        {
            timeBetweenFiring = MainManager.Instance.fireRateValue;
        }
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        if(!PauseMenu.isPaused)
        {
            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

            Vector3 rotation = mousePos - transform.position;

            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, rotZ);
            if (!canFire)
            {
                timer += Time.deltaTime;
                if (timer > timeBetweenFiring)
                {
                    canFire = true;
                    timer = 0;
                }
            }
            if (Input.GetMouseButtonDown(0) && canFire)
            {
                canFire = false;
                PlayerController controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

                if (controller.rend.sprite == controller.player)
                {
                    Instantiate(Rock, weaponTransform.position, Quaternion.identity);
                }

                if (controller.rend.sprite == controller.playerPickaxe)
                {
                    Instantiate(Pickaxe, weaponTransform.position, Quaternion.identity);
                }

                if (controller.rend.sprite == controller.playerSword)
                {
                    Instantiate(Sword, weaponTransform.position, Quaternion.identity);
                }

                if (controller.rend.sprite == controller.playerTorch)
                {
                    Instantiate(Torch, weaponTransform.position, Quaternion.identity);
                }
            }
        }
        
    }
}
