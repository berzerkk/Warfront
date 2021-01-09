using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionRange : MonoBehaviour {
    private Component _IAScript;

    void Start () {
        _IAScript = (transform.parent.gameObject.tag == "Ally" ? (Component) transform.parent.gameObject.GetComponent<AllyIA> () : (Component) transform.parent.gameObject.GetComponent<EnnemyIA> ());
    }

    void OnTriggerEnter (Collider col) {
        if ((col.gameObject.tag == "Ally" || col.gameObject.tag == "Player") && transform.parent.gameObject.tag == "Ennemy")
            ((EnnemyIA) _IAScript).AddTarget (col.transform);
        else if (col.gameObject.tag == "Ennemy" && transform.parent.gameObject.tag == "Ally")
            ((AllyIA) _IAScript).AddTarget (col.transform);

    }
    void OnTriggerExit (Collider col) {
        if ((col.gameObject.tag == "Ally" || col.gameObject.tag == "Player") && transform.parent.gameObject.tag == "Ennemy")
            ((EnnemyIA) _IAScript).RemoveTarget (col.transform);
        else if (col.gameObject.tag == "Ennemy" && transform.parent.gameObject.tag == "Ally")
            ((AllyIA) _IAScript).RemoveTarget (col.transform);
    }
}