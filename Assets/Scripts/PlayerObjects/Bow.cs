using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : PerformAction {
    public GameObject _arrow;

    public override void Action () {
        GameObject tmp = Instantiate (_arrow, transform.position, Quaternion.identity);
        tmp.GetComponent<Projectile> ()._targetedProjectile = false;
        tmp.transform.rotation = this.transform.parent.parent.parent.parent.rotation;
        tmp.transform.rotation = Quaternion.Euler (transform.parent.parent.eulerAngles.x, tmp.transform.eulerAngles.y, tmp.transform.eulerAngles.z);
        Destroy (tmp, 5f);
    }
}