using System;
using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager instance;
    [field:SerializeField] public int Currency {get;private set;}
    [field:SerializeField] public TextMeshProUGUI currentCurrency {get;private set;}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentCurrency.text = Currency.ToString();       
    }

    void Awake()
    {
        instance = this;
    }
    public void AddCurrency(int price)
    {
        Currency += price;
        UpdateText();
    }

    private void UpdateText()
    {
        CurrencyText[] text = FindObjectsByType<CurrencyText>(FindObjectsInactive.Include,FindObjectsSortMode.None);

        foreach (CurrencyText c in text)
        {
            c.UpdateText(Currency.ToString());
        } 
    }
}
