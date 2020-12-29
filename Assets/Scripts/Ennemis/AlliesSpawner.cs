using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlliesSpawner : MonoBehaviour {
    [SerializeField]
    private GameObject[] _allies;
    public int _sizeGroupSpawn = 4;

    void Start () {
        InvokeRepeating ("SpawnSimpleAlly", 2f, 5f);
    }

    private void SpawnSimpleAlly () {
        for (int i = 0; i < _sizeGroupSpawn; i++) {
            Instantiate (_allies[Random.Range (1, 3)], new Vector3 (transform.position.x + (i % 3), transform.position.y, transform.position.z + Mathf.Floor (i / 3)), Quaternion.identity);
        }
    }
}