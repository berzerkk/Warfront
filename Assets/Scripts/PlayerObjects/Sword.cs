﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : PerformAction {
    private List<GameObject> _targets = new List<GameObject> ();
    private Animator _animator;
    public int _damage = 5;

    private void Start () {
        _animator = GetComponent<Animator> ();
    }

    public override void Action () {
        _animator.Play ("swing", 0);
        if (_targets.Count != 0) {
            _targets.RemoveAll (item => item == null);
            foreach (GameObject target in _targets) {
                target.GetComponent<EnnemyIA> ().TakeDamage (_damage);
            }
        }
    }

    private void OnTriggerEnter (Collider other) {
        if (other.gameObject.tag == "Ennemy") {
            _targets.Add (other.gameObject);
        }
    }

    private void OnTriggerExit (Collider other) {
        if (other.gameObject.tag == "Ennemy" && _targets.Contains (other.gameObject)) {
            _targets.Remove (other.gameObject);
        }
    }
}