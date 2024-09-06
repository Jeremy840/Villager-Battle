using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponShop : MonoBehaviour
{
    public GameObject weaponMenu;
    // Start is called before the first frame update
    public GameObject moneySound;
    public GameObject noMoneySound;
    public GameObject pickaxe;
    public GameObject sword;
    public GameObject torch;

    public SpriteRenderer rend;
    public Sprite playerPickaxe;
    public Sprite playerSword;
    public Sprite playerTorch;

    public int pickaxeCost = 2;
    public int swordCost = 3;
    public int torchCost = 4;

    public int woodCount;
    public int bloodCount;
    public int crystalCount;

    public TMP_Text WoodCount;
    public TMP_Text BloodCount;
    public TMP_Text CrystalCount;

    void Start()
    {
        weaponMenu.SetActive(false);
        woodCount = MainManager.Instance.woodCount;
        bloodCount = MainManager.Instance.bloodCount;
        crystalCount = MainManager.Instance.crystalCount;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        weaponMenu.SetActive(true);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        weaponMenu.SetActive(false);
    }
    

    public void PickaxeButtonPress()
    {
        if (MainManager.Instance.bloodCount >= pickaxeCost)
        {
            Instantiate(moneySound, transform.position, Quaternion.identity);
            MainManager.Instance.bloodCount -= pickaxeCost;
            BloodCount.text = MainManager.Instance.bloodCount.ToString();
            rend.sprite = playerPickaxe;
            MainManager.Instance.currentSprite = rend.sprite;
        }
        else
        {
            Instantiate(noMoneySound, transform.position, Quaternion.identity);
        }
    }

    public void SwordButtonPress()
    {
        if (MainManager.Instance.woodCount >= swordCost)
        {
            Instantiate(moneySound, transform.position, Quaternion.identity);
            MainManager.Instance.woodCount -= swordCost;
            WoodCount.text = MainManager.Instance.woodCount.ToString();
            rend.sprite = playerSword;
            MainManager.Instance.currentSprite = rend.sprite;
        }
        else
        {
            Instantiate(noMoneySound, transform.position, Quaternion.identity);
        }
    }

    public void TorchButtonPress()
    {
        if (MainManager.Instance.crystalCount >= torchCost)
        {
            Instantiate(moneySound, transform.position, Quaternion.identity);
            MainManager.Instance.crystalCount -= torchCost;
            CrystalCount.text = MainManager.Instance.crystalCount.ToString();
            rend.sprite = playerTorch;
            MainManager.Instance.currentSprite = rend.sprite;
        }
        else
        {
            Instantiate(noMoneySound, transform.position, Quaternion.identity);
        }
    }
}