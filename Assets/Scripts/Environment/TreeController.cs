using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class TreeController : MonoBehaviour
{
    public int treeHealth = 5;
    public GameObject woodCounter;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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
