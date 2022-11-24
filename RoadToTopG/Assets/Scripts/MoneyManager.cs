using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    
    [SerializeField]
    private Text moneyText;
    private int currentMoney;

    // Start is called before the first frame update
    void Start()
    {
        currentMoney = 0;
        moneyText.text = "Money: " + currentMoney;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMoney(int moneyToAdd) {
        currentMoney += moneyToAdd;
        moneyText.text = "Money: " + currentMoney;
    }

    public void RemoveMoney(int moneyToRemove) {
        currentMoney -= moneyToRemove;
        moneyText.text = "Money: " + currentMoney;
    }

    public int getMoney()
    {
        return currentMoney;
    }
}