using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : PerformAction {
    private List<GameObject> _targets = new List<GameObject> ();
    private Animator _animator;
    [SerializeField]
    private ParticleSystem _swing;
    public int _damage = 5;
    protected override void Start () {
        _cdOriginal = 0.75f;
        _animator = GetComponent<Animator> ();
    }
    public override void Action () {
        if (_cdActual <= 0f) {
            _cdActual = _cdOriginal / ((SavedVariables._swordAttackSpeed + 100) / 100);
            _animator.Play ("swing", 0);
            _animator.speed = ((SavedVariables._swordAttackSpeed + 100) / 100);
            _swing.Play();
            if (_targets.Count != 0) {
                _targets.RemoveAll (item => item == null);
                foreach (GameObject target in _targets) {
                    target.GetComponent<EnnemyIA> ().TakeDamage (_damage + SavedVariables._swordDamage);
                }
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