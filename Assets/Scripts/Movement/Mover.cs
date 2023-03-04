using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : MonoBehaviour
{
    // Gets a reference to the rigidbody component
    protected Rigidbody2D m_Rigidbody;

    public abstract void Start();

    public abstract void Move(Vector3 direction, float speed);
}