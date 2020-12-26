using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyIA : MonoBehaviour {
    [SerializeField]
    private GameObject _finalPosition;
    [SerializeField]
    private float _speed = 1f;

    private GameObject _target = null;

    void Start () {

    }

    void Update () {
        if (_target != null) { // si ennemi à portée
            if (Vector3.Distance (transform.position, _target.transform.position) >.1f)
                transform.position = Vector3.MoveTowards (transform.position, _target.transform.position, _speed * Time.deltaTime);
        } else { // run a la base ennemie
            transform.position = Vector3.MoveTowards (transform.position, _finalPosition.transform.position, _speed * Time.deltaTime);
            if (Vector3.Distance (transform.position, _finalPosition.transform.position) < .01f)
                Destroy (this.gameObject);
        }
    }

    void OnTriggerEnter (Collider col) {
        if (_target == null && col.gameObject.tag == "AlliesIA") {
            _target = col.gameObject;
        }
    }
}