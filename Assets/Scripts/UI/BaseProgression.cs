using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProgression : MonoBehaviour {
    [SerializeField]
    private ProgressiveBar _ennemyBar;
    [SerializeField]
    private ProgressiveBar _allyBar;

    public void RefreshValues(int ennemy, int ally) {
        _ennemyBar.SetBarValue((float) ennemy / 100);
        _allyBar.SetBarValue((float) ally / 100);
    }
}