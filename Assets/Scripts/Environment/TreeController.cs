using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class TreeController : MonoBehaviour
{
    private int treeHealth = 5;


    public TextMeshPro woodCounter;
    public GameObject tree;
    // Start is called before the first frame update
    void Start()
    {
        tree = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (treeHealth <= 0)
        {
            DestroyTree();
        }
    }

    void DestroyTree()
    {
        Destroy(tree);

        woodCounter.text = "Youpi le bois";
    }
}
