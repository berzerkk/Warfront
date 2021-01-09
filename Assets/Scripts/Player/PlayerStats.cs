using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float _life = 100;
    public float _lifeMax = 100;
    public float _mana = 100;
    public float _manaMax = 100;
    public float _stamina = 100;
    public float _staminaMax = 100;

    [SerializeField]
    private ProgressiveBar _lifeBar, _manaBar;

    void Update() {
        _lifeBar.SetBarValue(_life / _lifeMax);
        _manaBar.SetBarValue(_mana / _manaMax);
    }

    public void TakeDamage(float damage) {
        _life = (_life - damage >= 0f ? _life - damage : 0f);
    }
}
