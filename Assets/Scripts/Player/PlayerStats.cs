using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public float _life = 100;
    public float _lifeMax = 100;
    public float _mana = 100;
    public float _manaMax = 100;
    public float _manaRegen = 1;
    public float _stamina = 100;
    public float _staminaRegen = 10;
    public float _staminaMax = 100;

    [SerializeField]
    private ProgressiveBar _lifeBar, _manaBar, _staminaBar;

    public GameObject _objectifUI;

    void Update () {
        _staminaBar.Active (!(_stamina == _staminaMax));
        _lifeBar.SetBarValue (_life / _lifeMax);
        _manaBar.SetBarValue (_mana / _manaMax);
        _staminaBar.SetBarValue (_stamina / _staminaMax);
        _mana = (_mana + (_manaRegen * Time.deltaTime) <= _manaMax ? _mana + (_manaRegen * Time.deltaTime) : _manaMax);
        _stamina = (_stamina + (_staminaRegen * Time.deltaTime) <= _staminaMax ? _stamina + (_staminaRegen * Time.deltaTime) : _staminaMax);

    }

    public void TakeDamage (float damage) {
        _life = (_life - damage >= 0f ? _life - damage : 0f);
    }
}