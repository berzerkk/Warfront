using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : PerformAction {
    private GameObject target = null;
    private Animator animator;
    private int damage = 0;

    protected override void Start () {
        _cdOriginal = 0.75f;
        animator = GetComponent<Animator> ();
    }

    public override void Action () {
        if (_cdActual <= 0f) {
            _cdActual = _cdOriginal;
            animator.Play ("Chop", 0);
            if (target != null) {
                target.GetComponent<TreeController> ().treeHealth -= 1;
            }
        }
    }

    private void OnTriggerEnter (Collider other) {
        if (other.gameObject.tag == "Tree") {
            damage = 1;
            target = other.gameObject;
        }
    }

    private void OnTriggerExit (Collider other) {

        if (target == other.gameObject) {
            target = null;
        }
    }
}