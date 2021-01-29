using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class EnnemyIA : MonoBehaviour {
    public List<Transform> _path = new List<Transform> ();
    private int _indexPath = 0;
    
    public GameObject _target = null;
    public TextMeshPro _lifeText;
    public GameObject _fireball; // todo voir pour changer la facon de drop un spell a un pnj
    [SerializeField] 
    private ParticleSystem _damageParticle;
    // stats
    public float _hp = 40f;
    private float _initialhp;
    public float _damage = 10f;
    public float _attackSpeed = 1f;
    public float _sightRange = 100f;
    public float _attackRange = 1f;
    public float _speed = 1f;
    public bool _melee = true;
    private float _timeBeforeAttack = 0f;
    public LayerMask whatIsGround, whatIsTargetable, whatIsPlayer;
    private UnityEngine.AI.NavMeshAgent _agent;
    private Vector3 _positionBeforeTarget;
    public bool _reset = false;
    public bool alreadyAttacked;
    public bool targetInSightRange, targetInAttackRange;
    private List<GameObject> _targets = new List<GameObject> ();
    public enum Order
    {
        Idle,
        Attack,
        Follow
    };
    public Order _order;

    void Awake () {
        _agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
        _agent.speed = _speed;
        _positionBeforeTarget = this.transform.position;
        _target = null;
        _initialhp = _hp;
    }
    void Update ()
    {
        if (_order == Order.Idle)
        {
            if (_targets.Count == 0 || Vector3.Distance(this.transform.position, _positionBeforeTarget) >= 100f)
            {
                Reset();
            }
            if(Vector3.Distance(this.transform.position, _positionBeforeTarget ) < 10f)
            {
                _hp = _initialhp;
                _reset = false;
                transform.LookAt(Vector3.back);
            }
        }
        if (_order == Order.Attack)
        {
            if (_targets.Count == 0)
            {
                //Debug.Log("On va au prochain point");
                GoToNextStepPath ();
                CheckForNextStepPath ();
            }
        }
        
        

        if (!_reset)
        {
            if (_targets.Count > 0)
            {
                Debug.Log("Il y a plein de target : " + _targets.Count);
                _target = _targets[0];
            }
            if (_target != null)
            {
                if (_target.tag == "Ally")
                {
                    targetInSightRange = Physics.CheckSphere(transform.position, _sightRange, whatIsTargetable);
                    targetInAttackRange = Physics.CheckSphere(transform.position, _attackRange, whatIsTargetable);
                }
                else if (_target.tag == "Player")
                {
                    targetInSightRange = Physics.CheckSphere(transform.position, _sightRange, whatIsPlayer);
                    targetInAttackRange = Physics.CheckSphere(transform.position, _attackRange, whatIsPlayer);
                }

                if (!alreadyAttacked)
                {
                    if (targetInSightRange && !targetInAttackRange) ChaseTarget();
                    if (targetInSightRange && targetInAttackRange) AttackTarget();
                }
            
            }

            if (_target == null && _targets.Count > 0)
            {
                _targets.RemoveAll(x => x == null);
                _target = _targets[0];
            }
        }

    }

    private void ChaseTarget()
    {
        Debug.Log("je cours vers ma cible");
        _agent.SetDestination(_target.transform.position);
    }

    private void AttackTarget()
    {
        Debug.Log("je commence a attaquer ma cible");
        _agent.SetDestination(transform.position);
        transform.LookAt(_target.transform);
        if (_melee)
        {
            Debug.Log("j'attaque ma cible en melee");
            Debug.Log("ma cible c'est :" + _target.ToString());
            if (_target.tag == "Ally")
            {
                _target.GetComponent<AllyIA>().TakeDamage(_damage);
            }
            else if(_target.tag == "Player")
            {
                _target.GetComponent<PlayerStats>().TakeDamage(_damage);
            }
            
            
        }
        else
        {
            Fireball();
        }
        if (!alreadyAttacked)
        {
            Debug.Log("je suis fatigué je me repose avant la prochaine attaque");
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), 1f/_attackSpeed);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void Reset()
    {
        _agent.SetDestination(_positionBeforeTarget);
        _reset = true;
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
        _targets.Add (newTarget.gameObject);
        Debug.Log("add Target");
    }
    public void RemoveTarget (Transform target) {
        if (_targets.Contains (target.gameObject))
            _targets.Remove (target.gameObject);
        
        Debug.Log("target removed");
    }
    
    private void Fireball () {
        GameObject tmp = Instantiate (_fireball, transform.position, Quaternion.identity);
        tmp.GetComponent<Projectile> ()._target = _target;
        tmp.GetComponent<Projectile> ()._damage = _damage;
    }

    public void TakeDamage (float damage) {
        _hp -= damage;
        _damageParticle.Play();
        if (_hp <= 0f)
            Destroy (this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ally" || other.gameObject.tag == "Player")
        {
            AddTarget(other.transform);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ally" || other.gameObject.tag == "Player")
        {
            RemoveTarget(other.transform);
        }
    }
}