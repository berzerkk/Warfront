using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionBase : MonoBehaviour {
    [SerializeField]
    private ParticleSystem _ring;

    [SerializeField]
    private ProgressiveBar _ennemyBar;
    [SerializeField]
    private ProgressiveBar _allyBar;

    private int _ennemyValue = 50;
    private int _allyValue = 50;

    private List<Transform> _ennemisList = new List<Transform> ();
    private List<Transform> _alliesList = new List<Transform> ();
    private PlayerStats _player;

    void Start () {

    }

    void Update () {
        Color color;
        _alliesList.RemoveAll (item => item == null);
        _ennemisList.RemoveAll (item => item == null);
        if (_ennemisList.Count > _alliesList.Count) {
            color = new Color (1f, 0f, 0f, 1f);
            _ennemyValue += (_ennemyValue + 1 <= 100 ? 1 : 0);
            _allyValue -= (_allyValue - 1 >= 0 ? 1 : 0);
        } else if (_ennemisList.Count < _alliesList.Count) {
            color = new Color (0f, 0f, 1f, 1f);
            _ennemyValue -= (_ennemyValue - 1 >= 0 ? 1 : 0);
            _allyValue += (_allyValue + 1 <= 100 ? 1 : 0);
        } else {
            color = new Color (1f, 1f, 1f, 1f);
        }
        if (_player != null) {
            _player._objectifUI.GetComponent<BaseProgression>().RefreshValues(_ennemyValue, _allyValue);
        }
        var main = _ring.main;
        main.startColor = color;
        _ennemyBar.SetBarValue ((float) _ennemyValue / 100);
        _allyBar.SetBarValue ((float) _allyValue / 100);

    }

    public void AddTarget (Transform newTarget, bool ennemy) {
        if (ennemy) {
            _ennemisList.Add (newTarget);
        } else {
            _alliesList.Add (newTarget);
        }
    }

    public void RemoveTarget (Transform target, bool ennemy) {
        if (ennemy) {
            if (_ennemisList.Contains (target))
                _ennemisList.Remove (target);
        } else {
            if (_alliesList.Contains (target))
                _alliesList.Remove (target);
        }
    }

    void OnTriggerEnter (Collider col) {
        if (col.gameObject.tag == "Ennemy") {
            AddTarget (col.transform, true);
        } else if (col.gameObject.tag == "Ally") {
            AddTarget (col.transform, false);
        } else if (col.gameObject.tag == "Player") {
            AddTarget (col.transform, false);
            _player = col.transform.gameObject.GetComponent<PlayerStats>();
            _player._objectifUI.SetActive(true);
        }
    }
    void OnTriggerExit (Collider col) {
        if (col.gameObject.tag == "Ennemy") {
            RemoveTarget (col.transform, true);
        } else if (col.gameObject.tag == "Ally") {
            RemoveTarget (col.transform, false);
        } else if (col.gameObject.tag == "Player") {
            _player._objectifUI.SetActive(false);
            _player = null;
            RemoveTarget (col.transform, false);
        }
    }
}