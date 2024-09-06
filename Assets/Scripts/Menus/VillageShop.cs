using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VillageShop : MonoBehaviour
{
    public GameObject shopMenu;
    public GameObject moneySound;
    public GameObject noMoneySound;

    public int woodCost = 15;
    public int bloodCost = 15;
    public int crystalCost = 15;

    public int woodCount = 0;
    public int bloodCount = 0;
    public int crystalCount = 0;

    public TMP_Text CoinCount;
    public TMP_Text WoodCount;
    public TMP_Text BloodCount;
    public TMP_Text CrystalCount;
    // Start is called before the first frame update
    void Start()
    {
        shopMenu.SetActive(false);
        WoodCount.text = MainManager.Instance.woodCount.ToString();
        woodCount = MainManager.Instance.woodCount;
        BloodCount.text = MainManager.Instance.bloodCount.ToString();
        bloodCount = MainManager.Instance.bloodCount;
        CrystalCount.text = MainManager.Instance.crystalCount.ToString();
        crystalCount = MainManager.Instance.crystalCount;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        shopMenu.SetActive(true);  
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        shopMenu.SetActive(false);
    }

    public void WoodButtonPress()
    {
        if (MainManager.Instance.gold >= woodCost)
        {
            Instantiate(moneySound,transform.position,Quaternion.identity);
            MainManager.Instance.gold -= woodCost;
            CoinCount.text = MainManager.Instance.gold.ToString();
            woodCount += 1;
            MainManager.Instance.woodCount = woodCount;
            WoodCount.text = woodCount.ToString();
        }
        else
        {
            Instantiate(noMoneySound, transform.position, Quaternion.identity);
        }
    }

    public void BloodButtonPress()
    {
        if (MainManager.Instance.gold >= bloodCost)
        {
            Instantiate(moneySound, transform.position, Quaternion.identity);
            MainManager.Instance.gold -= bloodCost;
            CoinCount.text = MainManager.Instance.gold.ToString();
            bloodCount += 1;
            MainManager.Instance.bloodCount = bloodCount;
            BloodCount.text = bloodCount.ToString();
        }
        else
        {
            Instantiate(noMoneySound, transform.position, Quaternion.identity);
        }
    }

    public void CrystalButtonPress()
    {
        if (MainManager.Instance.gold >= crystalCost)
        {
            Instantiate(moneySound, transform.position, Quaternion.identity);
            MainManager.Instance.gold -= crystalCost;
            CoinCount.text = MainManager.Instance.gold.ToString();
            crystalCount += 1;
            MainManager.Instance.crystalCount = crystalCount;
            CrystalCount.text = crystalCount.ToString();
        }
        else
        {
            Instantiate(noMoneySound, transform.position, Quaternion.identity);
        }
    }
}
