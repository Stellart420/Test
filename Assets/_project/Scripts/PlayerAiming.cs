using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private Transform _cameraTranform;
    [SerializeField] private float _sensitivity = 0.2f;

    private Vector3 _lookInput;
    private int _fingerId;

    private bool _aiming;
    private Camera _cam;
    private float _cameraPitch;

    private void Awake()
    {
        _cam = Camera.main;
        _fingerId = -1;
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                var touch = Input.GetTouch(i);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        OnBegan(touch); break;
                    case TouchPhase.Moved: OnMoved(touch); break;
                        case TouchPhase.Ended: break;
                    case TouchPhase.Canceled: OnCanceled(touch); break;
                }
            }
        }
    }

    private void OnMoved(Touch touch)
    {
        if (touch.fingerId == _fingerId)
        {
            _lookInput = touch.deltaPosition * _sensitivity * Time.deltaTime;
        }
    }

    private void OnCanceled(Touch touch)
    {
        if (touch.fingerId == _fingerId)
        {
            _aiming = false;
            _fingerId = -1;
        }
    }

    private void OnBegan(Touch touch)
    {
        if (touch.position.x > Screen.width / 2 && _fingerId == -1)
        {
            _fingerId = touch.fingerId;
            _aiming = true;
        }
    }

    private void LookAround()
    {
        _cameraPitch = Mathf.Clamp(_cameraPitch - _lookInput.y, -90f, 90f);
        _cameraTranform.localRotation = Quaternion.Euler(_cameraPitch, 0, 0);

        _movement.Rotate(_lookInput);
    }
}
