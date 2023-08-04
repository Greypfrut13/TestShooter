using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAnimation : MonoBehaviour
{
    [SerializeField] private string _takeDamageTriggerName;

    private Animator _animator;

    private void Start() 
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayTakeDamageAnimation()
    {
        _animator.SetTrigger(_takeDamageTriggerName);
    }
}
