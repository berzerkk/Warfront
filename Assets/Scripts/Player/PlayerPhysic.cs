using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysic : MonoBehaviour {
    public bool _grounded = true;
    void OnTriggerEnter (Collider other) {
        if (_grounded == false && other.gameObject.tag == "Ground") {
            _grounded = true;
        }
    }
    void OnTriggerStay (Collider other) {
        if (_grounded == false && other.gameObject.tag == "Ground") {
            _grounded = true;
        }
    }
}