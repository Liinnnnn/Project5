using TMPro;
using UnityEngine;

public class DiamondText : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private TextMeshProUGUI text;
    public void UpdateText(string curency)
    {
        if(text == null)
        {
            text = GetComponent<TextMeshProUGUI>();
        }
        text.text = curency;
    }
}
