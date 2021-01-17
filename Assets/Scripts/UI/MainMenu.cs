using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private PlayerController _playerController;
    [SerializeField]
    private GameObject _mainMenuObject;
    void Start () {

    }

    void Update () {
        _mainMenuObject.SetActive (_playerController._escapeMenu);
    }
}
