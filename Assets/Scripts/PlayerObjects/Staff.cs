using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : PerformAction
{
    public List<GameObject> _spells = new List<GameObject>();
    private int _indexSpell = 0;

    public override void Action() {
        GameObject tmp = Instantiate(_spells[_indexSpell], transform.position, Quaternion.identity);
        tmp.GetComponent<Projectile>()._targetedProjectile = false;
        tmp.transform.rotation = this.transform.parent.parent.parent.parent.rotation;
        tmp.transform.rotation = Quaternion.Euler(transform.parent.parent.eulerAngles.x, tmp.transform.eulerAngles.y, tmp.transform.eulerAngles.z);
        Destroy(tmp, 5f);
    }
}
