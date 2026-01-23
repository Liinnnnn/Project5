using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private WeaponPosition[] WParents;
    public bool tryAddWeapon(WeaponDataSO w,int lv)
    {
        for (int i = 0; i < WParents.Length; i++)
        {
            if(WParents[i].weapon != null)
            {
                continue;
            }
            WParents[i].assignWeapon(w.weapon,lv);
            return true;
        }
        return false;
    }
}