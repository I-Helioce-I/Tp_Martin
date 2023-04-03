using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    int coin;
    [SerializeField]
    TextMeshProUGUI amount;

    private void Start()
    {
        UpdateCoinUI();
    }

    public int GetCoing()
    {
        return coin;
    } 

    public void SetCoin(int coinToAdd)
    {
        coin += coinToAdd;
        UpdateCoinUI();
    }

    private void UpdateCoinUI()
    {
        amount.text = coin.ToString() + " / " + GameManager.Instance.maxBatteryInGame;
    }
}
