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

    private List<Transform> _targets = new List<Transform> ();

    void Start () {
        _agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
        _agent.speed = _speed;
    }
    void Update () {
        // todo synthetise this
        Transform tmp;
        tmp = FindTarget ();
        if (tmp != null)
            SetupNewTarget (tmp.gameObject);
            
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

    private Transform FindTarget () {
        if (_targets.Count == 0)
            return null;
        _targets.RemoveAll (item => item == null);
        if (_targets.Count <= 0)
            return null;
        return _targets[0]; // Add intelligent targeting;
    }

    public void AddTarget (Transform newTarget) {
        _targets.Add (newTarget);
        // Debug.Log(_targets.Count);
    }
    public void RemoveTarget (Transform target) {
        if (_targets.Contains (target))
            _targets.Remove (target);
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

    public void SetupNewTarget (GameObject target) {
        if (_target == null) {
            _target = target;
            _agent.stoppingDistance = _range;
            _agent.destination = _target.transform.position;
        }
    }

    public void TakeDamage (float damage) {
        _hp -= damage;
        if (_hp <= 0f)
            Destroy (this.gameObject);
    }

}