using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemisSpawner : MonoBehaviour {
    [SerializeField]
    private GameObject[] _ennemis;
    public int _sizeGroupSpawn = 4;

    void Start () {
        InvokeRepeating ("SpawnSimpleEnnemy", 2f, 5f);
    }

    private void SpawnSimpleEnnemy () {
        for (int i = 0; i < _sizeGroupSpawn; i++) {
            Instantiate (_ennemis[Random.Range (2, 3)], new Vector3(transform.position.x + (i % 3), transform.position.y, transform.position.z + Mathf.Floor(i / 3)), Quaternion.identity);
        }
    }
}