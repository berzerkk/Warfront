using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemisSpawner : MonoBehaviour {
    [SerializeField]
    private GameObject[] _ennemis;
    public int _sizeGroupSpawn = 4;
    [SerializeField]
    private List<Transform> _leftPath = new List<Transform> ();
    [SerializeField]
    private List<Transform> _middlePath = new List<Transform> ();
    [SerializeField]
    private List<Transform> _rightPath = new List<Transform> ();
    void Start () {
        InvokeRepeating ("SpawnSimpleEnnemy", 2f, 10f);
    }

    private void SpawnSimpleEnnemy () {
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < _sizeGroupSpawn; j++) {
                GameObject tmp = Instantiate (_ennemis[Random.Range (0, 3)], new Vector3 (transform.position.x + (j % 3), transform.position.y, transform.position.z + Mathf.Floor (j / 3)), Quaternion.identity);
                if (i == 0) {
                    tmp.GetComponent<EnnemyIA>()._path = _leftPath;
                } else if (i == 1) {
                    tmp.GetComponent<EnnemyIA>()._path = _middlePath;
                } else {
                    tmp.GetComponent<EnnemyIA>()._path = _rightPath;
                }
            }
        }
    }
}