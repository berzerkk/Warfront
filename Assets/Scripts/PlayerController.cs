using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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

    private Vector3 _lastDirectionIntent;
    private float _lastRotationIntent;
    private Vector2 _lastMousePosition;
    private float _lastPitchIntent;

    // Update is called once per frame
    private void Update()
    {
        _lastDirectionIntent = Vector3.zero;
        _lastRotationIntent = 0.0f;

        _lastRotationIntent = Input.mousePosition.x - _lastMousePosition.x;
        _lastPitchIntent = Input.mousePosition.y - _lastMousePosition.y;

        _lastMousePosition = Input.mousePosition;

        if (Input.GetKey(KeyCode.D))
        {
            _lastDirectionIntent += Vector3.right;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            _lastDirectionIntent += Vector3.left;
        }

        if (Input.GetKey(KeyCode.Z))
        {
            _lastDirectionIntent += Vector3.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _lastDirectionIntent += Vector3.back;
        }

        _lastDirectionIntent = _lastDirectionIntent.normalized;
    }

    private void FixedUpdate()
    {
        playerTransform.Rotate(0f, _lastRotationIntent * yawRotationSpeed * Time.fixedDeltaTime, 0f);
        playerEyesTransform.Rotate(-_lastPitchIntent * pitchRotationSpeed * Time.fixedDeltaTime, 0f, 0f);

        var rotationX = playerEyesTransform.rotation.eulerAngles.x;
        if (rotationX > 180f)
        {
            rotationX = -360f + rotationX;
        }
        
        playerEyesTransform.localRotation = Quaternion.Euler(
            Mathf.Clamp(rotationX, -80f, 80f),
            0f,
            0f);

        playerTransform.position +=
            playerTransform.rotation * _lastDirectionIntent * (Time.fixedDeltaTime * playerSpeed);
    }

    private void OnEnable()
    {
        _lastMousePosition = Input.mousePosition;
    }

    private void OnDisable()
    {
        playerEyesTransform.localRotation = Quaternion.identity;
    }
}