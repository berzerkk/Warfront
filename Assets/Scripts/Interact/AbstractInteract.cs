using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractInteract : MonoBehaviour {
    public GameObject _interactText;
    private bool _gotPlayer = false;
    public abstract void Interact ();
    void start () {
        _interactText.SetActive (false);
    }
    void Update () {
        if (_gotPlayer && Input.GetKeyDown (KeyCode.E))
            Interact ();
    }
    private void OnTriggerEnter (Collider other) {
        if (other.gameObject.tag == "Player") {
            _interactText.SetActive (true);
            _gotPlayer = true;
        }
    }
    private void OnTriggerExit (Collider other) {
        if (other.gameObject.tag == "Player") {
            _interactText.SetActive (false);
            _gotPlayer = false;
        }
    }
}