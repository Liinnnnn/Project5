using UnityEngine;

[CreateAssetMenu(fileName = "PalleteSO", menuName = "Scriptable Objects/PalleteSO")]
public class PalleteSO : ScriptableObject
{
    [field: SerializeField] public Color[] lvColor{get; private set;}
    [field: SerializeField] public Color[] lvOulineColor{get; private set;}
}
