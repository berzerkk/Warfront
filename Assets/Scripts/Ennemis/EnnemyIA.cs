using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnnemyIA : MonoBehaviour {
    public List<Transform> _path = new List<Transform> ();
    private int _indexPath = 0;

    public GameObject _target = null;
    public TextMeshPro _lifeText;
    public GameObject _fireball; // todo voir pour changer la facon de drop un spell a un pnj

    // stats
    public float _hp = 40f;
    public float _damage = 10f;
    public float _attackSpeed = 1f;
    public float _range = 1f;
    public float _speed = 1f;
    public bool _melee = false;

    private float _timeBeforeAttack = 0f;
    private UnityEngine.AI.NavMeshAgent _agent;

    private Vector3 _positionBeforeTarget;
    public bool _reset = false;

    private List<Transform> _targets = new List<Transform> ();

    void Start () {
        _agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
        _agent.speed = _speed;
    }
    void Update () {
        // todo synthetise this
        Transform tmp;
        if (!_reset) {
            tmp = FindTarget ();
            if (tmp != null)
                SetupNewTarget (tmp.gameObject);
        }

        AttackTarget ();
        if (_target == null && !_reset) { // run a la base ennemie
            GoToNextStepPath ();
            CheckForNextStepPath ();
            // if (Vector3.Distance (transform.position, _finalPosition.transform.position) < 3f) // fix ça
            //     Destroy (this.gameObject);
        } else if (_target != null && !_reset) {
            if (Vector3.Distance (transform.position, _positionBeforeTarget) >= 20f) {
                _agent.destination = _positionBeforeTarget;
                _agent.stoppingDistance = 2f;
                _reset = true;
                _target = null;
            } else
                _agent.destination = _target.transform.position;
        }
        if (_reset && Vector3.Distance (transform.position, _positionBeforeTarget) <= 2f) {
            _reset = false;
            GoToNextStepPath ();
            CheckForNextStepPath ();
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

    private void GoToNextStepPath () {
        _agent.stoppingDistance = 1f;
        _agent.destination = _path[_indexPath].position;
    }
    private void CheckForNextStepPath () {
        if (Vector3.Distance (transform.position, _path[_indexPath].position) <= 5f) {
            _indexPath++;
            if (_indexPath >= 3)
                Destroy (this.gameObject);
            else
                GoToNextStepPath ();

        }
    }

    public void AddTarget (Transform newTarget) {
        _targets.Add (newTarget);
    }
    public void RemoveTarget (Transform target) {
        if (_targets.Contains (target))
            _targets.Remove (target);
    }

    private void AttackTarget () {
        if (_target != null && Vector3.Distance (transform.position, _target.transform.position) <= _range && _timeBeforeAttack <= 0f) {
            if (_melee) {
                if (_target.tag == "Ally") {
                _target.GetComponent<AllyIA> ().TakeDamage (_damage);
                } else {
                    Debug.Log("melee against player");
                }
            } else {
                Fireball ();
            }
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
            _positionBeforeTarget = transform.position;
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