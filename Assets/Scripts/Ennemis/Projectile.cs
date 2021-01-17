using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public bool _targetedProjectile = true;
    public GameObject _target = null;
    public float _damage = 10f;
    [SerializeField]
    private float _speed = 5f;

    void Update () {
        if (_targetedProjectile == true && _target == null) {
            Destroy (this.gameObject);
        } else if (_targetedProjectile == true) { // targeted spell routine
            transform.position = Vector3.MoveTowards (transform.position, _target.transform.position, _speed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation (Vector3.RotateTowards (transform.forward, _target.transform.position, _speed * Time.deltaTime, 0.0f));
            if (Vector3.Distance (transform.position, _target.transform.position) <= 1f) {
                if (_target.tag == "Ally")
                    _target.GetComponent<AllyIA> ().TakeDamage (_damage);
                else if (_target.tag == "Ennemy")
                    _target.GetComponent<EnnemyIA> ().TakeDamage (_damage);
                else if (_target.tag == "Player")
                    _target.GetComponent<PlayerStats> ().TakeDamage (_damage);
                Destroy (this.gameObject);
            }
        } else { // untargeted spell routine
            transform.position += transform.rotation * Vector3.forward.normalized * (_speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter (Collider col) {
        if (!_targetedProjectile && col.gameObject.tag == "Ennemy") {
            col.gameObject.GetComponent<EnnemyIA> ().TakeDamage (_damage);
            Destroy (this.gameObject);
        }
    }
}