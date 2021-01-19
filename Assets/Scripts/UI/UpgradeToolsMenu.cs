using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeToolsMenu : MonoBehaviour {
    private int[] _bowProjectileValue = { 1, 1, 1, 1 };
    private (int wood, int iron) [] _bowProjectilePrice = {
        (10, 10),
        (20, 20),
        (30, 30),
        (40, 40)
    };
    private int _bowProjectileIndex = 0;

    private int[] _bowDamageValue = { 5, 5, 5, 5 };
    private (int wood, int iron) [] _bowDamagePrice = {
        (10, 10),
        (20, 20),
        (30, 30),
        (40, 40)
    };
    private int _bowDamageIndex = 0;

    private int[] _bowShotRateValue = { 10, 10, 10, 10 };
    private (int wood, int iron) [] _bowShotRatePrice = {
        (10, 10),
        (10, 10),
        (10, 10),
        (10, 10)
    };
    private int _bowShotRateIndex = 0;

    private int[] _swordDamageValue = { 5, 5, 5, 5 };
    private (int wood, int iron) [] _swordDamagePrice = {
        (10, 10),
        (10, 10),
        (10, 10),
        (10, 10)
    };
    private int _swordDamageIndex = 0;

    private int[] _swordAttackSpeedValue = { 20, 20, 20, 20 };
    private (int wood, int iron) [] _swordAttackSpeedPrice = {
        (10, 10),
        (10, 10),
        (10, 10),
        (10, 10)
    };
    private int _swordAttackSpeedIndex = 0;

    [SerializeField]
    private PlayerController _playerController;

    public void BuyBowProjectile () {
        if (_bowProjectileIndex < _bowProjectileValue.Length && _bowProjectilePrice[_bowProjectileIndex].wood <= SavedVariables.woodCounter && _bowProjectilePrice[_bowProjectileIndex].iron <= SavedVariables.ironCounter) {
            SavedVariables.woodCounter -= _bowProjectilePrice[_bowProjectileIndex].wood;
            SavedVariables.ironCounter -= _bowProjectilePrice[_bowProjectileIndex].iron;
            SavedVariables._bowProjectile += _bowProjectileValue[_bowProjectileIndex];
            _bowProjectileIndex++;
        }
    }

    public void BuyBowDamage () {
        if (_bowDamageIndex < _bowDamageValue.Length && _bowDamagePrice[_bowDamageIndex].wood <= SavedVariables.woodCounter && _bowDamagePrice[_bowDamageIndex].iron <= SavedVariables.ironCounter) {
            SavedVariables.woodCounter -= _bowDamagePrice[_bowDamageIndex].wood;
            SavedVariables.ironCounter -= _bowDamagePrice[_bowDamageIndex].iron;
            SavedVariables._bowDamage += _bowDamageValue[_bowDamageIndex];
            _bowDamageIndex++;
        }
    }

    public void BuyBowShotRate () {
        if (_bowShotRateIndex < _bowShotRateValue.Length && _bowShotRatePrice[_bowShotRateIndex].wood <= SavedVariables.woodCounter && _bowShotRatePrice[_bowShotRateIndex].iron <= SavedVariables.ironCounter) {
            SavedVariables.woodCounter -= _bowShotRatePrice[_bowShotRateIndex].wood;
            SavedVariables.ironCounter -= _bowShotRatePrice[_bowShotRateIndex].iron;
            SavedVariables._bowShotRate += _bowShotRateValue[_bowShotRateIndex];
            _bowShotRateIndex++;
        }
    }

    public void BuySwordDamage () {
        if (_swordDamageIndex < _swordDamageValue.Length && _swordDamagePrice[_swordDamageIndex].wood <= SavedVariables.woodCounter && _swordDamagePrice[_swordDamageIndex].iron <= SavedVariables.ironCounter) {
            SavedVariables.woodCounter -= _swordDamagePrice[_swordDamageIndex].wood;
            SavedVariables.ironCounter -= _swordDamagePrice[_swordDamageIndex].iron;
            SavedVariables._swordDamage += _swordDamageValue[_swordDamageIndex];
            _swordDamageIndex++;
        }
    }

    public void BuySwordAttackSpeed () {
        if (_swordAttackSpeedIndex < _swordAttackSpeedValue.Length && _swordAttackSpeedPrice[_swordAttackSpeedIndex].wood <= SavedVariables.woodCounter && _swordAttackSpeedPrice[_swordAttackSpeedIndex].iron <= SavedVariables.ironCounter) {
            SavedVariables.woodCounter -= _swordAttackSpeedPrice[_swordAttackSpeedIndex].wood;
            SavedVariables.ironCounter -= _swordAttackSpeedPrice[_swordAttackSpeedIndex].iron;
            SavedVariables._swordAttackSpeed += _swordAttackSpeedValue[_swordAttackSpeedIndex];
            _swordAttackSpeedIndex++;
        }
    }

    public void ExitMenu () {
        _playerController.SwitchCursorMode (true);
        _playerController._menu = false;
        this.gameObject.SetActive (false);
    }
}