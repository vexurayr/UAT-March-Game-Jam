using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOffWalls : MonoBehaviour
{
    // The number of walls bullets will bounce off of before being destroyed
    public int m_MaxNumberOfBounces;
    private int m_NumberOfBounces = 0;

    // Used to calculate new force after colliding with a wall
    private Vector3 m_CurrentTrajectory;
    private Vector3 m_NewTrajectory;
    private float m_BulletSpeed;

    public void GetBulletData()
    {
        m_CurrentTrajectory = transform.position;
        m_BulletSpeed = GetComponent<Rigidbody2D>().velocity.magnitude;
        //Debug.Log("Trajectory = " + m_CurrentTrajectory + ", Speed = " + m_BulletSpeed);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        GetBulletData();

        if (m_NumberOfBounces < m_MaxNumberOfBounces)
        {
            float selfToWallAngle = Vector3.Angle(m_CurrentTrajectory, collision.transform.position);
            float newAngle = selfToWallAngle * -1;
            GetComponent<Rigidbody2D>().rotation = newAngle;
            m_CurrentTrajectory.x = m_CurrentTrajectory.x * -1;
            m_CurrentTrajectory.y = m_CurrentTrajectory.y * -1;

            if (GetComponent<Rigidbody2D>() != null)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<Rigidbody2D>().AddForce(m_CurrentTrajectory * m_BulletSpeed);
                Debug.Log("Trajectory = " + m_CurrentTrajectory + ", Speed = " + m_BulletSpeed);
            }

            m_NumberOfBounces++;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}