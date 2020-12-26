using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnnemyIA : MonoBehaviour {
    [SerializeField]
    private GameObject _finalPosition;
    [SerializeField]
    private float _speed = 1f;
    private GameObject _target = null;
    public TextMeshPro _lifeText;

    // stats
    public float _hp = 40f;
    public float _damage = 10f;
    public float _attackSpeed = 1f;
    //  public float _moveSpeed = 10;

    private float _timeBeforeAttack = 0f;
    void Start () { }
    void Update () {
        if (_target != null) { // si ennemi à portée
            if (Vector3.Distance (transform.position, _target.transform.position) > 1f)
                transform.position = Vector3.MoveTowards (transform.position, _target.transform.position, _speed * Time.deltaTime);
            AttackTarget ();
        } else { // run a la base ennemie
            transform.position = Vector3.MoveTowards (transform.position, _finalPosition.transform.position, _speed * Time.deltaTime);
            if (Vector3.Distance (transform.position, _finalPosition.transform.position) < .01f)
                Destroy (this.gameObject);
        }
        // decremente temps avant prochaine attaque dispo
        _timeBeforeAttack -= (_timeBeforeAttack - Time.deltaTime >= 0f ? Time.deltaTime : 0f);
                _lifeText.SetText(_hp.ToString());

    }
    private void AttackTarget () {
        if (_timeBeforeAttack == 0f) {
            _target.GetComponent<AllyIA>().TakeDamage (_damage);
            _timeBeforeAttack = _attackSpeed;
        }
    }
    public void TakeDamage (float damage) {
        _hp -= damage;
        if (_hp <= 0f)
            Destroy (this.gameObject);
    }
    void OnTriggerEnter (Collider col) {
        if (_target == null && col.gameObject.tag == "Ally") {
            _target = col.gameObject;
        }
    }
}