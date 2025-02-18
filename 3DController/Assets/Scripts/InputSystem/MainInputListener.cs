using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainInputListener : MonoBehaviour
{
    [SerializeField] private Transform _player;

    [SerializeField] private float _moveSpeed;

    private MainInputActions _mainInputActions;
    private void Awake()
    {
        _mainInputActions = new();
        Bind();
        _mainInputActions.Enable();
    }

    private void Bind()
    {
        _mainInputActions.Game.Fire.performed += OnFire;
        _mainInputActions.Game.HorizontalMove.performed += OnArrowsMove;
    }

    private void OnArrowsMove(InputAction.CallbackContext context)
    {
        _player.transform.position += new Vector3(2, 0, 0) * _moveSpeed;
    }

    private void OnFire(InputAction.CallbackContext context)
    {
        Debug.Log("Fire!");
    }

    private void Expose()
    {
        _mainInputActions.Game.Fire.performed -= OnFire;
    }

    private void OnDestroy()
    {
        _mainInputActions.Disable();
        Expose();
    }
}
