using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    
    [SerializeField] private WeaponPosition[] WParents;
    public void AddWeapon(WeaponDataSO w,int lv)
    {
        WParents[Random.Range(0,WParents.Length)].assignWeapon(w.weapon,lv);
        Debug.Log(lv);
    }
}
