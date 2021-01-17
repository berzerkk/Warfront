using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysic : MonoBehaviour {
    [SerializeField]
    private ParticleSystem _groundParticle;
    public bool _grounded = true;
    void OnTriggerEnter (Collider other) {
        if (_grounded == false && other.gameObject.tag == "Ground") {
            _grounded = true;
            _groundParticle.Play ();
        }
    }
    void OnTriggerStay (Collider other) {
        if (_grounded == false && other.gameObject.tag == "Ground") {
            _grounded = true;
        }
    }
}