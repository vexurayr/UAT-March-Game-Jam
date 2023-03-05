using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Abstract means an object of this class will never be made or a function will never be called within that class
public abstract class Pawn : MonoBehaviour
{
    /// <summary>
    /// Variables that will determine how fast an inhereting object will move
    /// </summary>
    public float m_MoveSpeed;

    protected Mover m_Mover;
    protected Shooter m_Shooter;

    public GameObject m_ProjectilePrefab;
    public float m_ProjectileFireForce;
    public float m_DamageDone;
    public float m_ProjectileLifeSpan;
    public float m_ShotsPerSecond;
    protected float m_SecondsPerShot;
    protected float m_TimeUntilNextEvent;

    // Virtual means child classes can override this method
    // Protected keyword is necessary because no access keyword defaults to private
    // And we don't want outside scripts calling these functions
    public virtual void Start()
    {
        // Gives pawn objects a reference to the mover class
        m_Mover = GetComponent<Mover>();

        // Takes a reference of the Shooter class or its children to call its functions
        m_Shooter = GetComponent<Shooter>();

        m_SecondsPerShot = 1 / m_ShotsPerSecond;

        m_TimeUntilNextEvent = 0;
    }

    public virtual void Update()
    {}

    public abstract void MoveForward();
    public abstract void MoveBackward();
    public abstract void MoveLeft();
    public abstract void MoveRight();
    public abstract void Shoot();
    public abstract void ShootCooldown();
}