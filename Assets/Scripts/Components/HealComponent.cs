using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealComponent : MonoBehaviour
{
    [SerializeField] [Min(0.0f)] private float _heal;

    private void OnTriggerEnter(Collider other) 
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if(playerHealth != null)
        {
            playerHealth.RestoreHealth(_heal);
        }
    }
}
