using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public WeaponManager manager;
    public ThrowWeapon ThrowWeapon;
    public PlayerController playerController;
    public GameObject upgradeMenu;
    private void Start()
    {
        upgradeMenu.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.tag == "Upgrade")
        {
            Destroy(collision.gameObject);
            upgradeMenu.SetActive(true);
            Time.timeScale = 0f;
            PauseMenu.isPaused = true;
        }
    }

    public void DamageUpgrade()
    {
        ThrowWeapon.damageValue += 5;
        MainManager.Instance.damageValue = ThrowWeapon.damageValue;
        upgradeMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseMenu.isPaused = false;
        print("asdsad");
    }

    public void FireRateUpgrade()
    {
        manager.timeBetweenFiring -= 0.05f;
        MainManager.Instance.fireRateValue = manager.timeBetweenFiring;
        upgradeMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseMenu.isPaused = false;
    }

    public void ThrowPowerUpgrade()
    {
        ThrowWeapon.movementSpeed += 2;
        MainManager.Instance.throwPowerValue = ThrowWeapon.movementSpeed;
        upgradeMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseMenu.isPaused = false;
    }

    public void MovementSpeedUpgrade()
    {
        playerController.movementSpeed += 0.5f;
        MainManager.Instance.moveSpeedValue = playerController.movementSpeed;
        upgradeMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseMenu.isPaused = false;
    }


}
