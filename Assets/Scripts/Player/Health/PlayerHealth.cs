using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] [Min(0.0f)] private float _maxHealth;
    [SerializeField] [Min(0.0f)] private float _chipSpeed;

    [Header("UI")]
    [SerializeField] private Image _frontHealthBar;
    [SerializeField] private Image _backHealthBar;
    [SerializeField] private Color _damageHealthBarColor;
    [SerializeField] private Color _healHealthBarColor;

    [Header("Damage Overlay")]
    [SerializeField] private Image _overlayImage;
    [SerializeField] private float _duration;
    [SerializeField] private float _fadeSpeed;

    private float _health;
    private float _lerpTimer;
    private float _overlayDurationTimer;

    private void Start() 
    {
        _health = _maxHealth;
        _overlayImage.color = new Color(_overlayImage.color.r , _overlayImage.color.g, _overlayImage.color.b, 0);
    }

    private void Update() 
    {
        _health = Mathf.Clamp(_health, 0, _maxHealth);
        UpdateHealthUI();

        ApplyDamageOverlay();
    }

    private void ApplyDamageOverlay()
    {
        if(_overlayImage.color.a > 0)
        {
            _overlayDurationTimer += Time.deltaTime;
            if(_overlayDurationTimer > _duration)
            {
                float tempAlpha = _overlayImage.color.a;
                tempAlpha -= Time.deltaTime * _fadeSpeed;
                _overlayImage.color = new Color(_overlayImage.color.r , _overlayImage.color.g, _overlayImage.color.b, tempAlpha);
            }
        }
    }

    public void UpdateHealthUI()
    {
        float fillFront = _frontHealthBar.fillAmount;
        float fillBack = _backHealthBar.fillAmount;
        float healthFraction = _health / _maxHealth;

        if(fillBack > healthFraction)
        {
            _backHealthBar.color = _damageHealthBarColor;
            _frontHealthBar.fillAmount = healthFraction;

            _lerpTimer += Time.deltaTime;
            float percentComplete = _lerpTimer / _chipSpeed;
            percentComplete *= percentComplete;

            _backHealthBar.fillAmount = Mathf.Lerp(fillBack, healthFraction, percentComplete);
        }
        if(fillFront < healthFraction)
        {
            _backHealthBar.color = _healHealthBarColor;
            _backHealthBar.fillAmount = healthFraction;

            _lerpTimer += Time.deltaTime;
            float percentComplete = _lerpTimer / _chipSpeed;
            percentComplete *= percentComplete;

            _frontHealthBar.fillAmount = Mathf.Lerp(fillFront, _backHealthBar.fillAmount, percentComplete);
        }
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        _lerpTimer = 0f;

        _overlayDurationTimer = 0;
        _overlayImage.color = new Color(_overlayImage.color.r , _overlayImage.color.g, _overlayImage.color.b, 1);
    }

    public void RestoreHealth(float healAmount)
    {
        _health += healAmount;
        _lerpTimer = 0f;
    }
}
