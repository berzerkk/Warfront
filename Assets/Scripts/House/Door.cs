using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
    private enum State {
        CLOSE,
        CLOSING,
        OPEN,
        OPENING
    }
    private State _state = State.CLOSE;
    public GameObject _mesh;
    public float _speed = 1f;

    void Start () {
    }

    void Update () { 
        if (_state == State.CLOSING) {
            _mesh.transform.localRotation  = Quaternion.Euler(-90, 0, 0);
            _state = State.CLOSE;
        } else if (_state == State.OPENING) {
            _mesh.transform.localRotation  = Quaternion.Euler(-90, 0, 90);
            _state = State.OPEN;
        }
    }

    void OnTriggerEnter (Collider col) {

        if ((col.gameObject.tag == "Player" || col.gameObject.tag == "Ennemy"|| col.gameObject.tag == "Ally") && _state == State.CLOSE) {
            _state = State.OPENING;
        }
    }
     void OnTriggerExit (Collider col) {

        if ((col.gameObject.tag == "Player" || col.gameObject.tag == "Ennemy"|| col.gameObject.tag == "Ally") && _state == State.OPEN) {
            _state = State.CLOSING;
        }
    }
}