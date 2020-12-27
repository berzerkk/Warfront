using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private bool activated = false;
    //public GameObject[] weapons;
    //public GameObject CurrentWeapon;
    public float inventoryTime = 0;
    //public int weaponNumber = 0;
    public Canvas canvas;


    private void Start()
    {
        //CurrentWeapon = weapons[0];
    }

    private void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel") != 0){
            activated = true;
            inventoryTime = 2f;
            if(Input.GetAxis("Mouse ScrollWheel") > 0){
                //weaponNumber = (weaponNumber + 1);
            }
            if(Input.GetAxis("Mouse ScrollWheel") < 0){
                //weaponNumber = (weaponNumber - 1);
            }
        }
        else if(inventoryTime < 0f)
        {
            activated = false;
        }
        
        //CurrentWeapon = weapons[weaponNumber];
        if (inventoryTime >= -1f)
        {
            inventoryTime = inventoryTime - Time.deltaTime;
        }
        canvas.enabled = activated;
    }
}
