using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    public float m_DamageDone;
    public Pawn m_Owner;

    // Built in function that detects when colliders of pawns are overlapping
    public void OnTriggerEnter2D(Collider2D other)
    {
        // Gets health component from colliding objects
        Health otherHealth = other.gameObject.GetComponent<Health>();

        // Deals damage to that object only if it has a health component
        if (otherHealth != null)
        {
            otherHealth.TakeDamage(m_DamageDone, m_Owner);
        }
    }
}