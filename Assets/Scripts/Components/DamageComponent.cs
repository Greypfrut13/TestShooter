using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    [SerializeField] [Min(0.0f)] private float _damage;

    private void OnTriggerEnter(Collider other) 
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if(playerHealth != null)
        {
            playerHealth.TakeDamage(_damage);
        }
    }
}
