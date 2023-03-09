using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float m_MaxHealth;
    private float m_CurrentHealth;
    public bool isEnemy;
    public int pointsOnDeath;
    public bool isDebugging;

    // Start is called before the first frame update
    void Start()
    {
        m_CurrentHealth = m_MaxHealth;
    }

    public float GetHealth()
    {
        return m_CurrentHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Character>().GetCharacterType() !=
           this.gameObject.GetComponent<Character>().GetCharacterType())
        {
            TakeDamage(1);
            Debug.Log(collision.gameObject.name);
        }
    }

    public void TakeDamage(float amount, Pawn source)
    {
        m_CurrentHealth = m_CurrentHealth - amount;

        // Makes sure current health never goes below 0 or higher than max health
        m_CurrentHealth = Mathf.Clamp(m_CurrentHealth, 0, m_MaxHealth);

        if (isDebugging)
        {
            Debug.Log(source.name + " did " + amount + " damage to " + gameObject.name);
        }

        if (m_CurrentHealth <= 0)
        {
            Die(source);
        }
        else
        {
            AudioManager.instance.PlaySound("EnemyHitFile");
        }
    }

    public void TakeDamage(float amount)
    {
        m_CurrentHealth = m_CurrentHealth - amount;

        // Makes sure current health never goes below 0 or higher than max health
        m_CurrentHealth = Mathf.Clamp(m_CurrentHealth, 0, m_MaxHealth);

        if (m_CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Die(Pawn source)
    {
        if (isEnemy)
        {
            PointsManager.instance.SetPlayerScore(PointsManager.instance.GetPlayerScore() + pointsOnDeath);

            AudioManager.instance.PlaySound("EnemyDeathFile");
        }
        else
        {
            AudioManager.instance.PlaySound("WilhelmScream");
            SceneManager.LoadScene("MainMenu");
        }

        gameObject.SetActive(false);
    }

    public void Die()
    {
        if (isEnemy)
        {
            PointsManager.instance.SetPlayerScore(PointsManager.instance.GetPlayerScore() + pointsOnDeath);
        }
        else
        {
            AudioManager.instance.PlaySound("WilhelmScream");
            LevelLoader.instance.Lose();
        }

        gameObject.SetActive(false);
    }
}