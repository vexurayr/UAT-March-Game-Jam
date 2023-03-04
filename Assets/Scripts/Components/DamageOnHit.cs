using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    public float m_DamageDone;
    public Pawn m_Owner;

    // Built in function that detects when colliders of pawns are overlapping
    public void OnTriggerEnter2D(Collider2D collider)
    {
        // Gets health component from colliding objects
        Health otherHealth = collider.gameObject.GetComponent<Health>();

        // Deals damage to that object only if it has a health component and
        // it won't deal damage to the object that fired the bullet
        if (otherHealth != null && collider.gameObject != m_Owner.gameObject)
        {
            otherHealth.TakeDamage(m_DamageDone, m_Owner);
        }
    }
}