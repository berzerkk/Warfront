using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class TreeController : MonoBehaviour
{
    public int treeHealth = 5;
    void Update()
    {
        if (treeHealth == 0)
        {
            DestroyTree();
        }
    }

    void DestroyTree()
    {
        SavedVariables.woodCounter += 5;
        Destroy(this.gameObject);
    }
}
