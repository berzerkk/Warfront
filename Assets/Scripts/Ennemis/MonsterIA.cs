using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterIA : MonoBehaviour {
    [SerializeField]
    private GameObject _monster;
    private UnityEngine.AI.NavMeshAgent _agent;
    private Vector3 _destination;
    public float _destinationVariance = 8f;

    void Start () {
        _agent = _monster.GetComponent<UnityEngine.AI.NavMeshAgent> ();
        SetupNewDestination ();
    }

    void Update () {
        if (Vector3.Distance (_monster.transform.position, _destination) <= 1f)
            SetupNewDestination ();
    }

    private void SetupNewDestination () {
        _destination = new Vector3 (transform.position.x + Random.Range (_destinationVariance * -1, _destinationVariance),
            transform.position.y, transform.position.z + Random.Range (_destinationVariance * -1, _destinationVariance));
        _agent.destination = _destination;
    }
}