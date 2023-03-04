using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float m_MaxHealth;
    private float m_CurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        m_CurrentHealth = m_MaxHealth;
    }

    public float GetHealth()
    {
        return m_CurrentHealth;
    }

    public void TakeDamage(float amount, Pawn source)
    {
        m_CurrentHealth = m_CurrentHealth - amount;

        // Makes sure current health never goes below 0 or higher than max health
        m_CurrentHealth = Mathf.Clamp(m_CurrentHealth, 0, m_MaxHealth);

        Debug.Log(source.name + " did " + amount + " damage to " + gameObject.name);

        if (m_CurrentHealth <= 0)
        {
            Die(source);
        }
    }

    public void Die(Pawn source)
    {
        Destroy(gameObject);
    }
}