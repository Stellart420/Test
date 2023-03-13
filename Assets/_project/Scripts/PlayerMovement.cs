using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _speed = 15f;
    [SerializeField] private Animator _animator;

    private Vector3 _move;

    private void Update()
    {
        var dirX = _joystick.Horizontal;
        var dirZ = _joystick.Vertical;

        _animator.SetFloat("Speed", Mathf.Abs(dirX) + Mathf.Abs(dirZ));

        var direction = new Vector3(dirX, 0, dirZ);
        _controller.Move(direction * _speed * Time.deltaTime);
    }

    internal void Rotate(Vector3 lookInput)
    {
        _controller.transform.Rotate(transform.up, lookInput.x);
    }
}
