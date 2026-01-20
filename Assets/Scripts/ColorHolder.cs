using Unity.VisualScripting;
using UnityEngine;

public class ColorHolder : MonoBehaviour
{
    public static ColorHolder instance;
    [Header("Data")]
    [SerializeField] private PalleteSO palleteSO;
    public static Color getColor(int level)
    {
        return instance.palleteSO.lvColor[level];
    }
    public static Color getOutlineColor(int level)
    {
        return instance.palleteSO.lvOulineColor[level];
    }
    void Awake()
    {
        instance = this;
    }
}
