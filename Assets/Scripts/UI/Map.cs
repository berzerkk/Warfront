using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {
    [SerializeField]
    private PlayerController _playerController;
    [SerializeField]
    private GameObject _mapObject;
    void Start () {

    }

    void Update () {
        _mapObject.SetActive (_playerController._map);
    }
}