using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableMission : AbstractInteract {
    public GameObject _menuUI;

    void Start () {
        _menuUI.SetActive (false);
    }
    public override void Interact () {
        _menuUI.SetActive (true);
        Debug.Log ("Table Mission Interact");
    }

}