using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : PerformAction
{
    public override void Action() { // fonction call quand la hache est équipée et qu'il y a un input clique gauche 
        Debug.Log("coup de hache ^^");
    }

}
