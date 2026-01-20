using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    
    [SerializeField] private Transform WParents;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddWeapon(WeaponDataSO w,int lv)
    {
        Instantiate(w.weapon,WParents);
    }
}
