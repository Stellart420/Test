using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    private int _leftFingerId, _rightFingerId;

    private float _halfScreenWidth;

    private void Start()
    {
        _leftFingerId = _rightFingerId = -1;
        _halfScreenWidth = Screen.width / 2;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);

                switch (touch.phase)
                {
                    case TouchPhase.Began: OnBeganTouch(touch); break;
                    case TouchPhase.Canceled: OnCanceledTouch(touch); break;
                    case TouchPhase.Ended: break;
                }
            }
        }
    }

    private void OnCanceledTouch(Touch touch)
    {
        if (touch.fingerId == _leftFingerId)
        {
            _leftFingerId = -1;
            Debug.Log("Stop Tracking left finger.");
        }
        else if (touch.fingerId == _rightFingerId)
        {
            _rightFingerId = -1;
            Debug.Log("Stop Tracking right finger.");
        }
    }

    private void OnBeganTouch(Touch touch)
    {
        if (touch.position.x < _halfScreenWidth && _leftFingerId == -1)
        {
            _leftFingerId = touch.fingerId;
            Debug.Log("Tracking left finger.");
        }
        else if (touch.position.x > _halfScreenWidth && _rightFingerId == -1)
        {
            _rightFingerId = touch.fingerId;
            Debug.Log("Tracking right finger.");
        }
    }
}
