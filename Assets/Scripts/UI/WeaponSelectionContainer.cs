using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelectionContainer : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Image icon ;
    [SerializeField] private TextMeshProUGUI Wname ;
    [SerializeField] private TextMeshProUGUI LV ;
    [field : SerializeField] public Button button{get;private set;}
    [Header("Color")]
    [SerializeField] private Image levelImage;

    public void Configure(Sprite sprite, string name,int level)
    {
        icon.sprite =sprite;
        Wname.text = name;
        LV.text = "Level " + level.ToString();
        Color imgColor = ColorHolder.getColor(level);
        Debug.Log(level + " IMG");
        levelImage.color = imgColor;
    }

    public void DeSelect()
    {
        transform.localScale = Vector3.one;
    }

    public void Select()
    {
        transform.localScale = new Vector3(1.1f,1.1f,1.1f);
    }
}
