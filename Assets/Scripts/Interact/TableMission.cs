using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableMission : AbstractInteract {
    public GameObject _menuUI;
    [SerializeField]
    private PlayerController _playerController;

    void Start () {
        _menuUI.SetActive (false);
    }
    public override void Interact () {
        _menuUI.SetActive (true);
    _playerController.SwitchCursorMode(false);
    _playerController._menu = true;
    }

}