using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI upgradeNameText;
    [SerializeField] private TextMeshProUGUI upgradeValuesText;
    [field : SerializeField] public Button button{get;private set;}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void configure(Sprite icon , string name , string val)
    {
        image.sprite = icon;
        upgradeNameText.text = name;
        upgradeValuesText.text   = val;
    }
}
