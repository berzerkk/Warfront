using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmController : MonoBehaviour
{
    private WeaponSwitching weaponSwitching;

    private bool hasAxe = false;

    private bool isSwinging = false;
    // Start is called before the first frame update
    void Start()
    {
        weaponSwitching = GetComponent<WeaponSwitching>();
        if (weaponSwitching.currentWeapon == 3)
        {
            hasAxe = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
