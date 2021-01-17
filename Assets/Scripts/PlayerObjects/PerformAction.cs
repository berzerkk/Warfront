using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PerformAction : MonoBehaviour {
    protected float _cdActual;
    protected float _cdOriginal;
    protected virtual void Start () {
        _cdActual = 0f;
    }
    void Update () {
        _cdActual -= Time.deltaTime;
        if (_cdActual < -1f)
            _cdActual = -1f;
    }
    public abstract void Action ();
}