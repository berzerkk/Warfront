using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : PerformAction {
    public List<GameObject> _spells = new List<GameObject> ();
    private int _indexSpell = 0;
    [SerializeField]
    private PlayerStats _player;
    protected override void Start() {
        _cdOriginal = 2f;
    }

    public override void Action () {
        if (_cdActual <= 0f && _player._mana >= 20f) {
            _cdActual = _cdOriginal;
            _player._mana -= 20f;
            GameObject tmp = Instantiate (_spells[_indexSpell], transform.position, Quaternion.identity);
            tmp.GetComponent<Projectile> ()._targetedProjectile = false;
            tmp.transform.rotation = this.transform.parent.parent.parent.parent.rotation;
            tmp.transform.rotation = Quaternion.Euler (transform.parent.parent.eulerAngles.x, tmp.transform.eulerAngles.y, tmp.transform.eulerAngles.z);
            Destroy (tmp, 5f);
        }
    }
}