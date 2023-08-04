using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private TargetAnimation _animation;

    private void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(float amount)
    {
        _animation.PlayTakeDamageAnimation();
        _health -= amount;

        if(_health <= 0)
        {
            Die();
        }
    }
}
