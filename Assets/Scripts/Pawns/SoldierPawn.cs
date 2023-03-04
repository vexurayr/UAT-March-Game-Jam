using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierPawn : Pawn
{
    public override void Start()
    {
        // Use base."Name"(); if you want to call the parent's function
        base.Start();
    }

    public override void Update()
    {
        base.Update();

        if (m_TimeUntilNextEvent >= 0)
        {
            m_TimeUntilNextEvent -= Time.deltaTime;
            m_TimeUntilNextEvent = Mathf.Clamp(m_TimeUntilNextEvent, 0, m_SecondsPerShot);
        }
        reloadText.text = "Reloading: " + m_TimeUntilNextEvent.ToString("n2");
    }

    // Inherits mover object from Pawn class and gets the component from Pawn's Start()
    public override void MoveForward()
    {
        // Calls the Move function in the mover class, but the function in TankMover is run because that is the script attached to the pawn
        m_Mover.Move(transform.up, m_MoveSpeed);
    }

    public override void MoveBackward()
    {
        m_Mover.Move(transform.up, -m_MoveSpeed);
    }

    public override void MoveLeft()
    {
        m_Mover.Move(transform.right, -m_MoveSpeed);
    }

    public override void MoveRight()
    {
        m_Mover.Move(transform.right, m_MoveSpeed);
    }

    public override void Shoot()
    {
        if (m_TimeUntilNextEvent <= 0)
        {
            // Calls a function in Shooter using the reference in Pawn and gives the data saved in Pawn
            m_Shooter.Shoot(m_ProjectilePrefab, m_ProjectileFireForce, m_DamageDone, m_ProjectileLifeSpan);

            // Starts the cooldown after the player has shot
            ShootCooldown();
        }
    }

    // A countdown method timer
    public override void ShootCooldown()
    {
        if (m_TimeUntilNextEvent <= 0)
        {
            m_TimeUntilNextEvent = m_SecondsPerShot;
        }
    }
}