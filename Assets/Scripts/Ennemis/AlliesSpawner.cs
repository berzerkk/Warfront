using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlliesSpawner : MonoBehaviour {
    [SerializeField]
    private GameObject[] _allies;
    public int _sizeGroupSpawn = 1;
    [SerializeField]
    private List<Transform> _leftPath = new List<Transform> ();
    [SerializeField]
    private List<Transform> _middlePath = new List<Transform> ();
    [SerializeField]
    private List<Transform> _rightPath = new List<Transform> ();
    void Start () {
        InvokeRepeating ("SpawnSimpleAlly", 2f, 10f);
    }

    private void SpawnSimpleAlly () {
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < _sizeGroupSpawn + SavedVariables._additionnalAllySpawnPerWave; j++) {
                //Spawn ally in line 
                GameObject tmp = Instantiate (_allies[Random.Range (0, 3)], new Vector3 (transform.position.x + (j % 3), transform.position.y, transform.position.z + Mathf.Floor (j / 3)), Quaternion.identity);
                if (i == 0) {
                    tmp.GetComponent<AllyIA> ()._path = _leftPath;
                } else if (i == 1) {
                    tmp.GetComponent<AllyIA> ()._path = _middlePath;
                } else {
                    tmp.GetComponent<AllyIA> ()._path = _rightPath;
                }
            }
        }
    }
}