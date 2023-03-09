using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMover : Mover
{
    public override void Start()
    {
        m_Rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
    }

    public override void Move(Vector3 direction, float speed)
    {
        // Gives a value in units per second
        Vector3 moveVector = direction.normalized * speed * Time.deltaTime;

        // Applies movement to rigidbody instead of transform to make sure collisions are consistant
        m_Rigidbody.transform.position = m_Rigidbody.transform.position + moveVector;
    }

    public void OnDisable()
    {
        m_Rigidbody = null;
    }
}