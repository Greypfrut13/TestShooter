using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] [Min(0.0f)] private float _speed;

    [Header("Jump")]
    [SerializeField] [Min(0.0f)] private float _jumpHeight;
    [SerializeField] private float _gravity = -9.81f;
    
    private Vector3 _playerVelocity;
    private bool _isGrounded;

    private CharacterController _controller;

    private void Start() 
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update() 
    {
        _isGrounded = _controller.isGrounded;
    }

    private void ApplyGravity()
    {
        _playerVelocity.y += _gravity * Time.deltaTime;

        if(_isGrounded && _playerVelocity.y < 0)
        {
            _playerVelocity.y = -2f;
        }

        _controller.Move(_playerVelocity * Time.deltaTime);
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        _controller.Move(transform.TransformDirection(moveDirection) * _speed * Time.deltaTime);

        ApplyGravity();
    }

    public void Jump()
    {
        if(_isGrounded)
        {
            _playerVelocity.y = Mathf.Sqrt(_jumpHeight * -3f * _gravity);
        }
    }
}
