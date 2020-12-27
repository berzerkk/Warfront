using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnnemyIA : MonoBehaviour {
    [SerializeField]
    private GameObject _finalPosition;
    public GameObject _target = null;
    public TextMeshPro _lifeText;
    public GameObject _fireball; // todo voir pour changer la facon de drop un spell a un pnj

    // stats
    public float _hp = 40f;
    public float _damage = 10f;
    public float _attackSpeed = 1f;
    public float _range = 1f;
    public float _speed = 1f;

    private float _timeBeforeAttack = 0f;
    private UnityEngine.AI.NavMeshAgent _agent;

    void Start () {
        _agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
        _agent.speed = _speed;
    }
    void Update () {
        AttackTarget ();
        if (_target == null) { // run a la base ennemie
            _agent.stoppingDistance = 0f;
            _agent.destination = _finalPosition.transform.position;
            if (Vector3.Distance (transform.position, _finalPosition.transform.position) < 3f)
                Destroy (this.gameObject);
        }
        // decremente temps avant prochaine attaque dispo
        _timeBeforeAttack -= (_timeBeforeAttack - Time.deltaTime > -1f ? Time.deltaTime : 0f);
        _lifeText.SetText (_hp.ToString ());

    }
    private void AttackTarget () {
        if (_target != null && Vector3.Distance (transform.position, _target.transform.position) <= _range && _timeBeforeAttack <= 0f) {
            // _target.GetComponent<AllyIA>().TakeDamage (_damage);  todo à l'impact du spell/attaque
            Fireball ();
            _timeBeforeAttack = _attackSpeed;
        }
    }
    private void Fireball () {
        GameObject tmp = Instantiate (_fireball, transform.position, Quaternion.identity);
        tmp.GetComponent<Projectile> ()._target = _target;
        tmp.GetComponent<Projectile> ()._damage = _damage;
    }

    private void SetupNewTarget (GameObject target) {
        _target = target;
        _agent.stoppingDistance = _range;
        _agent.destination = _target.transform.position;
    }

    public void TakeDamage (float damage) {
        _hp -= damage;
        if (_hp <= 0f)
            Destroy (this.gameObject);
    }
    void OnTriggerEnter (Collider col) {
        if (_target == null && col.gameObject.tag == "Ally")
            SetupNewTarget (col.gameObject);
    }
    void OnTriggerStay (Collider col) {
        if (_target == null && col.gameObject.tag == "Ally")
            SetupNewTarget (col.gameObject);
    }
}