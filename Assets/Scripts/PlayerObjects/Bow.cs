using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : PerformAction {
    public GameObject _arrow;
    public float _radiusArrow = 2.5f;
    protected override void Start () {
        _cdOriginal = 0.75f;
    }

    public override void Action () {
        if (_cdActual <= 0f) {
            _cdActual = _cdOriginal / ((SavedVariables._bowShotRate + 100) / 100);
            for (int i = 0; i < (SavedVariables._bowProjectile * 2) + 1; i++) {
                GameObject tmp = Instantiate (_arrow, transform.position, Quaternion.identity);
                tmp.GetComponent<Projectile> ()._targetedProjectile = false;
                tmp.GetComponent<Projectile>()._damage += SavedVariables._bowDamage;
                tmp.transform.rotation = this.transform.parent.parent.parent.parent.rotation;
                tmp.transform.rotation = Quaternion.Euler (transform.parent.parent.eulerAngles.x, tmp.transform.eulerAngles.y + ((0 - (((SavedVariables._bowProjectile*2) * _radiusArrow) / 2)) + (i * _radiusArrow)), tmp.transform.eulerAngles.z);
                Destroy (tmp, 5f);
            }
        }
    }
}


