using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    public int rockHealth = 5;
    void Update()
    {
        if (rockHealth == 0)
        {
            DestroyRock();
        }
    }

    void DestroyRock()
    {
        SavedVariables.ironCounter += 5;
        Destroy(this.gameObject);
    }
}
