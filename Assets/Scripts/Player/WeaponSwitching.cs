using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int currentWeapon = 0;

    public int maxWeapons = 4;
    public GameObject weapons;
    public GameObject weaponsUI;

    public GameObject weaponsAbilitiesBar;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentWeapon + 1 <= maxWeapons)
            {
                currentWeapon++;
            }
            else
            {
                currentWeapon = 0;
            }
            SelectWeapon(currentWeapon);
        }
        else if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currentWeapon - 1 >= 0)
            {
                currentWeapon--;
            }
            else
            {
                currentWeapon = maxWeapons;
            }
            SelectWeapon(currentWeapon);
        }

        if (currentWeapon == maxWeapons + 1)
        {
            currentWeapon = 0;
        }

        if (currentWeapon == -1)
        {
            currentWeapon = maxWeapons;
        }
    }

    void SelectWeapon(int index)
    {
        for (int i = 0; i < weapons.transform.childCount; i++)
        {
            if (i == index)
            {
                weapons.transform.GetChild(i).gameObject.SetActive(true);
                weaponsUI.transform.GetChild(i).GetChild(0).gameObject.SetActive(true);
                weaponsAbilitiesBar.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                weapons.transform.GetChild(i).gameObject.SetActive(false);
                weaponsUI.transform.GetChild(i).GetChild(0).gameObject.SetActive(false);
                weaponsAbilitiesBar.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
