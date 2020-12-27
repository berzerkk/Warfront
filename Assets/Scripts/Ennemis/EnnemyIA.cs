using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnnemyIA : MonoBehaviour {
    [SerializeField]
    private GameObject _finalPosition;
    [SerializeField]
    private float _speed = 1f;
    public GameObject _target = null;
    public TextMeshPro _lifeText;

    // stats
    public float _hp = 40f;
    public float _damage = 10f;
    public float _attackSpeed = 1f;
    public float _range = 1f;

    public float _timeBeforeAttack = 0f;
    // todo voir pour changer la facon de drop un spell a un pnj
    public GameObject _fireball;

    private UnityEngine.AI.NavMeshAgent _agent;

    void Start () {
        _agent = GetComponent<UnityEngine.AI.NavMeshAgent>(); // agent.destination = goal.position; 
        _agent.speed = _speed;
     }
    void Update () {
        if (_target != null) { // si ennemi à portée
            if (Vector3.Distance (transform.position, _target.transform.position) > _range) {
                _agent.destination = _target.transform.position;
                // Vector3 tmp = Vector3.MoveTowards (transform.position, _target.transform.position, _speed * Time.deltaTime);
                // Collider[] col = Physics.OverlapSphere (transform.position, 10);
                // if (col.Length > 0) {
                //     Debug.Log ("already someone");
                // }
             //   transform.position = tmp;
            } else {
                AttackTarget ();
            }
        } else { // run a la base ennemie
        _agent.destination = _finalPosition.transform.position;
            //transform.position = Vector3.MoveTowards (transform.position, _finalPosition.transform.position, _speed * Time.deltaTime);
            if (Vector3.Distance (transform.position, _finalPosition.transform.position) < 3f)
                Destroy (this.gameObject);
        }
        // decremente temps avant prochaine attaque dispo
        _timeBeforeAttack -= (_timeBeforeAttack - Time.deltaTime > -1f ? Time.deltaTime : 0f);
        _lifeText.SetText (_hp.ToString ());

    }
    private void AttackTarget () {
        if (_timeBeforeAttack <= 0f) {
            // _target.GetComponent<AllyIA>().TakeDamage (_damage); // todo à l'impact du spell/attaque
            Fireball ();
            _timeBeforeAttack = _attackSpeed;
        }
    }
    private void Fireball () {
        GameObject tmp = Instantiate (_fireball, transform.position, Quaternion.identity);
        tmp.GetComponent<Projectile> ()._target = _target;
        tmp.GetComponent<Projectile> ()._damage = _damage;
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
    void OnTriggerStay (Collider col) {
        if (_target == null && col.gameObject.tag == "Ally") {
            _target = col.gameObject;
        }
    }
}