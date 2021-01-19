using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField]
    private TextMeshProUGUI _lifeText, _manaText;
    [SerializeField]
    private GameObject _hurtEffect, _deathScreen;
    public GameObject _objectifUI;
    public bool _dead = false;

    void Start () {
        _hurtEffect.SetActive (false);
        _deathScreen.SetActive(false);
    }

    void Update () {
        _staminaBar.Active (!(_stamina == _staminaMax));
        _lifeBar.SetBarValue (_life / _lifeMax);
        _lifeText.text = (int) _life + "/" + (int) _lifeMax;
        _manaBar.SetBarValue (_mana / _manaMax);
        _manaText.text = (int) _mana + "/" + (int) _manaMax;
        _staminaBar.SetBarValue (_stamina / _staminaMax);
        _mana = (_mana + (_manaRegen * Time.deltaTime) <= _manaMax ? _mana + (_manaRegen * Time.deltaTime) : _manaMax);
        _stamina = (_stamina + (_staminaRegen * Time.deltaTime) <= _staminaMax ? _stamina + (_staminaRegen * Time.deltaTime) : _staminaMax);
        if (!_dead && _life == 0f) {
            _dead = true;
            DeathScreen();
        }
    }

    public void TakeDamage (float damage) {
        _life = (_life - damage >= 0f ? _life - damage : 0f);
        _hurtEffect.SetActive (true);
        StartCoroutine(CancelHurtEffect());
    }

    private void DeathScreen() {
        _deathScreen.SetActive(true);
    }

    private IEnumerator CancelHurtEffect () {
        yield return new WaitForSeconds (0.5f);
        _hurtEffect.SetActive (false);
    }
}