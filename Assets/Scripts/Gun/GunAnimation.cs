using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnimation : MonoBehaviour
{
    [SerializeField] private string _reloadTriggerName;

    private Animator _animator;

    private void Start() 
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayReloadAnimation()
    {
        _animator.SetTrigger(_reloadTriggerName);
    }
}
