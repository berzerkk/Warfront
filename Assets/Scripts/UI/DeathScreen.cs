using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathScreen : MonoBehaviour {
    private float _resurrectTimer = 20f;
    [SerializeField]
    private TextMeshProUGUI _timer;
    [SerializeField]
    private GameObject _button;
    [SerializeField]
    private PlayerController _playerController;

    void OnEnable () {
        _resurrectTimer = 20f;
        _timer.enabled = true;
        _button.SetActive (false);
        _playerController.SwitchCursorMode (false);
        _playerController._menu = true;
    }

    void Update () {
        _resurrectTimer -= Time.deltaTime;
        _timer.text = (int) _resurrectTimer + "..";
        if (_resurrectTimer <= 0f) {
            _timer.enabled = false;
            _button.SetActive (true);
        }
    }
    public void Revive () {
        _playerController.SwitchCursorMode (true);
        _playerController._menu = false;
        _playerController.Revive ();
        this.gameObject.SetActive (false);
    }
}