using System;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager instance;
    [field:SerializeField] public int Currency {get;private set;}
    [field:SerializeField] public TextMeshProUGUI currentCurrency {get;private set;}
    public static Action spent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateText();
    }

    void Awake()
    {
        instance = this;
    }
    [Button]
    private void Add5000()
    {
        AddCurrency(1000);
    }
    public void AddCurrency(int price)
    {
        Currency += price;
        UpdateText();
        spent?.Invoke();
    }

    private void UpdateText()
    {
        CurrencyText[] text = FindObjectsByType<CurrencyText>(FindObjectsInactive.Include,FindObjectsSortMode.None);

        foreach (CurrencyText c in text)
        {
            c.UpdateText(Currency.ToString());
        } 
    }

    public bool HasEnough(int rerollPrice)
    {
        return Currency >= rerollPrice;
    }

    public void UseCoin(int rerollPrice)
    {
        AddCurrency(-rerollPrice);
        spent?.Invoke();

    }
}
