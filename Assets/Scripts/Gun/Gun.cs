using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float _damage;
    [SerializeField] private float _range;
    [SerializeField] private int _bulletsInClip;

    [Header("UI and Animation")]
    [SerializeField] private BulletsCounter _bulletsCounter;
    [SerializeField] private GunAnimation _animation;
    
    [Header("Effects")]
    [SerializeField] private ParticleSystem _muzzleFlash;
    [SerializeField] private ParticleSystem _hitEffect;
    [SerializeField] private float _hitParticleDuration;

    private Camera _camera;

    public int _currentBulletsCount;
    private bool _isReloading = false;

    private void Awake() 
    {
        _camera = Camera.main;
        _currentBulletsCount = _bulletsInClip;

        _bulletsCounter.SetGun(this, _bulletsInClip, _currentBulletsCount);
    }
    
    private void Shoot()
    {
        _muzzleFlash.Play();

        RaycastHit hit;
        if(Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, _range))
        {
            _currentBulletsCount--;
            _bulletsCounter.UpdateCurrentBulletsText(_currentBulletsCount);

            Target target = hit.transform.GetComponent<Target>();

            if(target != null)
            {
                target.TakeDamage(_damage);
            }

            ParticleSystem hitEffect = Instantiate(_hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(hitEffect.gameObject, _hitParticleDuration);
        }
    }

    private void Reload()
    {
        _isReloading = true;
        _animation.PlayReloadAnimation();
    }

    public void ResetReleasedBullets()
    {
        _currentBulletsCount = _bulletsInClip;
        _bulletsCounter.UpdateCurrentBulletsText(_currentBulletsCount);

        _isReloading = false;
    }

    public void ApplyShoot()
    {
        if(_currentBulletsCount > 0)
        {
            Shoot();
        }
        else
        {
            if(_isReloading) return;
            
            Reload();
        }
    }
}
