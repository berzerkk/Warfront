using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public GameObject _target = null;
    public float _damage = 10f;
    [SerializeField]
    private float _speed = 5f;
    void Update () {
        if (_target == null) Destroy (this.gameObject);
        else {
            transform.position = Vector3.MoveTowards (transform.position, _target.transform.position, _speed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation (Vector3.RotateTowards (transform.forward, _target.transform.position, _speed * Time.deltaTime, 0.0f));
            if (Vector3.Distance (transform.position, _target.transform.position) <= 1f) {
                if (_target.tag == "Ally")
                    _target.GetComponent<AllyIA> ().TakeDamage (_damage);
                else if (_target.tag == "Ennemy")
                    _target.GetComponent<EnnemyIA> ().TakeDamage (_damage);
                Destroy (this.gameObject);
            }
        }
    }

    // void OnTriggerEnter (Collider col) {
    //     if (col.gameObject == _target && _target != null) {
    //         if (_target.tag == "Ally")
    //             _target.GetComponent<AllyIA> ().TakeDamage (_damage);
    //         else if (_target.tag == "Ennemy")
    //             _target.GetComponent<EnnemyIA> ().TakeDamage (_damage);
    //         Destroy (this.gameObject);
    //     }
    // }
}