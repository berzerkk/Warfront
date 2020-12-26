using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemisSpawner : MonoBehaviour {
    [SerializeField]
    private GameObject _simpleEnnemy;

    void Start () {
        InvokeRepeating ("SpawnSimpleEnnemy", 3f, 3f);
    }

    private void SpawnSimpleEnnemy () {
        Instantiate (_simpleEnnemy, transform.position, Quaternion.identity);
    }
}