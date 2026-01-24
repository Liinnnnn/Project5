using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemContainer : MonoBehaviour
{
    [Header("REF")]
    [SerializeField] private Image container;
    [SerializeField] private Image iconItem;
    [SerializeField] private Button view;
    public Weapon weapon {get;private set;}
    public int Index {get;private set;}
    public ObjectDataSO objectDataSO {get;private set;}
    public void configure(Color containerColor , Sprite icon)
    {
        container.color = containerColor;
        iconItem.sprite = icon;
    }
    public void Configure(Weapon oData,int index,Action clickedCalled)
    {
        Color container = ColorHolder.getColor(oData.Level);
        Sprite icon = oData.weaponData.Sprite;
        configure(container,icon);
        view.onClick.RemoveAllListeners();
        view.onClick.AddListener(() => clickedCalled?.Invoke());
        weapon = oData;
        Index = index;
    }
    public void Configure(ObjectDataSO oData,Action clickedCalled)
    {
        Color container = ColorHolder.getColor(oData.rarity);
        Sprite icon = oData.icon;
        configure(container,icon);
        view.onClick.RemoveAllListeners();
        view.onClick.AddListener(() => clickedCalled?.Invoke());
        objectDataSO = oData;

    }
}
