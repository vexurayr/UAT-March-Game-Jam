using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float initialHealth = 10f;
    [SerializeField] private float maxHealth = 10f;

    [Header("Settings")]
    [SerializeField] private bool destroyObject;

    private Character character;
    private CharacterController controller;
    private Collider collider;
    private SpriteRenderer spriteRenderer;

    /// <summary>
    /// Controls the current health of the object
    /// </summary>
    public float CurrentHealth { get; set; }

    private void Awake()
    {
        character = GetComponent<Character>();
        controller = GetComponent<CharacterController>();
        collider = GetComponent<Collider>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        CurrentHealth = initialHealth;
    }

    private void Update()
    {
        //debug TakeDamage function
        if (Input.GetKeyDown(KeyCode.L))
        {
            TakeDamage(1);
        }
    }

    /// <summary>
    /// Take the amount of damage we pass in the parameters
    /// </summary>
    /// <param name="damage">Amount to damage</param>
    public void TakeDamage(int damage)
    {
        if (CurrentHealth > 0)
        {
            AudioManager.instance.PlaySound("AIHit");
            CurrentHealth -= damage;
            return;
        }

        if (CurrentHealth <= 0)
        {
            AudioManager.instance.PlaySound("AIDie");
            Die();
        }
    }

    /// <summary>
    /// Kills the object
    /// </summary>
    private void Die()
    {
        if (character != null)
        {
            collider.enabled = false;
            spriteRenderer.enabled = false;
            character.enabled = false;
            controller.enabled = false;
        }

        if (destroyObject)
        {
            DestroyObject();
        }
    }
    /// <summary>
    /// If destoryObject is selected, we destroy this object
    /// </summary>
    private void DestroyObject()
    {
        gameObject.SetActive(false);
    }
}
