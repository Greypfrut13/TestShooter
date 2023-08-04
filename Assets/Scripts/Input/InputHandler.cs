using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Gun _gun;
    [SerializeField] private PlayerLook _playerLook;

    private PlayerInput _playerInput;
    private PlayerInput.OnFootActions _onFoot;

    private void Awake() 
    {
        _playerInput = new PlayerInput();
        _onFoot = _playerInput.OnFoot;

        _onFoot.Jump.performed += ctx => _playerMovement.Jump();
        _onFoot.Shoot.performed += ctx => _gun.ApplyShoot();
    }

    private void Update() 
    {
        _playerMovement.ProcessMove(_onFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate() 
    {
        _playerLook.ProcessLook(_onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable() 
    {
        _onFoot.Enable();
    }

    private void OnDisable() 
    {
        _onFoot.Disable();
    }
}
