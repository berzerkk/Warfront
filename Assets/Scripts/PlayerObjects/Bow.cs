using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : PerformAction {
    public GameObject _arrow;
    protected override void Start () {
        _cdOriginal = 0.75f;
    }

    public override void Action () {
        if (_cdActual <= 0f) {
            _cdActual = _cdOriginal;
            GameObject tmp = Instantiate (_arrow, transform.position, Quaternion.identity);
            tmp.GetComponent<Projectile> ()._targetedProjectile = false;
            tmp.transform.rotation = this.transform.parent.parent.parent.parent.rotation;
            tmp.transform.rotation = Quaternion.Euler (transform.parent.parent.eulerAngles.x, tmp.transform.eulerAngles.y, tmp.transform.eulerAngles.z);
            Destroy (tmp, 5f);
        }
    }
}