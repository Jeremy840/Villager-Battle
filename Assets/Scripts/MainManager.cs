using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public int gold;

    public int nextWave;

    public int woodCount;
    public int bloodCount;
    public int crystalCount;

    public Sprite currentSprite;

    public float damageValue;
    public float fireRateValue;
    public float throwPowerValue;
    public float moveSpeedValue;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void NewGoldValue(int gold)
    {
        MainManager.Instance.gold = gold;
    }

    public void newGame()
    {
        gold = 0;
        nextWave = 0;
        woodCount = 0;
        bloodCount = 0;
        crystalCount = 0;
        damageValue = 50f;
        fireRateValue = 10f;
        moveSpeedValue = 4;

    }
}
