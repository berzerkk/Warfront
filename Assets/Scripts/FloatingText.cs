using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour {
    void Update () {
        transform.rotation = Quaternion.LookRotation (transform.position - Camera.main.transform.position);
    }
}