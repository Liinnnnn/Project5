using UnityEngine;

public class WeaponPosition : MonoBehaviour
{
    [field: SerializeField] public Weapon weapon{get ; private set;}
    public void assignWeapon(Weapon w,int lv)
    {
        w.UpgradeTo(lv);
        
        Instantiate(w,transform);

        w.transform.localRotation = Quaternion.identity;
    }
}
