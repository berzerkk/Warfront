using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlliesSpawner : MonoBehaviour {
    [SerializeField]
    private GameObject _simpleAlly;

    void Start () {
        InvokeRepeating ("SpawnSimpleAlly", 3f, 3f);
    }

    private void SpawnSimpleAlly () {
        Instantiate (_simpleAlly, transform.position, Quaternion.identity);
    }
}