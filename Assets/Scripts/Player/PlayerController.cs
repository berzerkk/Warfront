using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private Transform playerEyesTransform;

    [SerializeField]
    private float playerSpeed;

    [SerializeField]
    private float yawRotationSpeed;

    [SerializeField]
    private float pitchRotationSpeed;

    [SerializeField]
    private float _accelerationRate = 10f;

    private Vector3 _lastDirectionIntent;
    private float _lastRotationIntent;
    // private Vector2 _lastMousePosition;
    private float _lastPitchIntent;
    private bool _sprint = false;

    [SerializeField]
    private PlayerPhysic _playerPhysic;
    [SerializeField]
    private PlayerStats _playerStats;
    [SerializeField]
    private GameObject _sprintParticleObject;
    private ParticleSystem _sprintParticleSystem;
    // private ParticleSystem.EmissionModule _sprintEmission;

    // Action depending on what player hold
    [SerializeField]
    private List<GameObject> _tools = new List<GameObject> ();
    private WeaponSwitching _weaponSwitching;

    public bool _menu = false;
    public bool _escapeMenu = false;
    public bool _map = false;

    void Start () {
        _weaponSwitching = GetComponent<WeaponSwitching> ();
        SwitchCursorMode (true);
        _sprintParticleSystem = _sprintParticleObject.GetComponent<ParticleSystem> ();
    }

    private void Update () {
        if (Input.GetKeyDown (KeyCode.M) && !_escapeMenu) {
            _map = !_map;
            SwitchCursorMode (!_map);
        }

        if (Input.GetKeyDown (KeyCode.Escape)) {
            _escapeMenu = !_escapeMenu;
            SwitchCursorMode (!_escapeMenu);
        }
        _lastDirectionIntent = Vector3.zero;
        _lastRotationIntent = 0.0f;

        // _lastRotationIntent = Input.mousePosition.x - _lastMousePosition.x;
        // _lastPitchIntent = Input.mousePosition.y - _lastMousePosition.y;

        _lastRotationIntent = Input.GetAxis ("Mouse X");
        _lastPitchIntent = Input.GetAxis ("Mouse Y");

        //  _lastMousePosition = Input.mousePosition;

        if (_map || _menu || _escapeMenu)
            return;

        if (Input.GetKey (KeyCode.LeftShift) && (_playerStats._stamina - (100f * Time.deltaTime) >= 0f)) {
            _playerStats._stamina -= (100f * Time.deltaTime);
            _sprint = true;
        } else
            _sprint = false;
        var em = _sprintParticleSystem.emission;
        em.rateOverTime = (_sprint ? 20f : 0f);

        if (Input.GetKey (KeyCode.D)) {
            _lastDirectionIntent += Vector3.right;
        }

        if (Input.GetKey (KeyCode.Q)) {
            _lastDirectionIntent += Vector3.left;
        }

        if (Input.GetKey (KeyCode.Z)) {
            _lastDirectionIntent += Vector3.forward;
        }

        if (Input.GetKey (KeyCode.S)) {
            _lastDirectionIntent += Vector3.back;
        }

        _lastDirectionIntent = _lastDirectionIntent.normalized;
        if (Input.GetMouseButtonDown (0)) { // performe action depending on what player hold
            _tools[_weaponSwitching.currentWeapon].GetComponent<PerformAction> ().Action ();
        }

        playerTransform.Rotate (0f, _lastRotationIntent * yawRotationSpeed * Time.fixedDeltaTime, 0f);
        playerEyesTransform.Rotate (-_lastPitchIntent * pitchRotationSpeed * Time.fixedDeltaTime, 0f, 0f);

        var rotationX = playerEyesTransform.rotation.eulerAngles.x;
        if (rotationX > 180f) {
            rotationX = -360f + rotationX;
        }

        playerEyesTransform.localRotation = Quaternion.Euler (
            Mathf.Clamp (rotationX, -80f, 80f),
            0f,
            0f);
    }

    public void SwitchCursorMode (bool blocked) { //Switch from invisible blocked cursor to visible movable cursor
        Cursor.lockState = (blocked ? CursorLockMode.Locked : CursorLockMode.None); 
        Cursor.visible = !blocked;
    }

    private void FixedUpdate () {
        if (Input.GetKey (KeyCode.Space) && _playerPhysic._grounded) { // move part of input on Update()
            _playerPhysic._grounded = false;
            playerTransform.gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 100, 0), ForceMode.Impulse);
        }
        playerTransform.position +=
            playerTransform.rotation * _lastDirectionIntent * (Time.fixedDeltaTime * (_sprint ? playerSpeed * (1 + (_accelerationRate / 100)) : playerSpeed));
    }

    // private void OnEnable () {
    //     _lastMousePosition = Input.mousePosition;
    // }

    /*
        private void OnDisable () {
            playerEyesTransform.localRotation = Quaternion.identity;
        }
    */
}