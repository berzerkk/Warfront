using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyIA : MonoBehaviour {
    [SerializeField]
    private GameObject _finalPosition;
    [SerializeField]
    private float _speed = 1f;
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        transform.position = Vector3.MoveTowards (transform.position, _finalPosition.transform.position, _speed * Time.deltaTime);
        if (Vector3.Distance (transform.position, _finalPosition.transform.position) < .01f)
            Destroy (this.gameObject);
    }
}