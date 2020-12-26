using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsController : MonoBehaviour {
    public float _speed = 1f;
    private float _verticalAxis, _horizontalAxis;
    private float rotationX = 0;
    private float rotationY = 0;
    public float _speedCameraX, _speedCameraY = 1f;
    public Camera _camera;
    public GameObject _fireball;

    void Update () {
        _horizontalAxis = Input.GetAxis ("Horizontal") * _speed * Time.deltaTime;
        _verticalAxis = Input.GetAxis ("Vertical") * _speed * Time.deltaTime;
        transform.Translate (_horizontalAxis, 0f, _verticalAxis);
        rotationX += -Input.GetAxis ("Mouse Y")* _speedCameraX;
        rotationY += Input.GetAxis ("Mouse X") * _speedCameraY;
        _camera.transform.localRotation = Quaternion.Euler (rotationX, rotationY, 0);
        if (Input.GetKeyDown ("space")) {
            GetComponent<Rigidbody> ().AddForce (Vector3.up * 10, ForceMode.Impulse);
        }
        if (Input.GetKeyDown ("a")) {
            GameObject tmp = Instantiate (_fireball, transform.position, Quaternion.identity);
            tmp.GetComponent<Rigidbody> ().AddForce (transform.forward * 100);
        }
    }
}