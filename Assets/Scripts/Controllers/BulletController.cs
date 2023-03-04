using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : Controller
{
    // The number of walls bullets will bounce off of before being destroyed
    public int m_MaxNumberOfBounces;
    private int m_NumberOfBounces = 0;

    // Used for data from SoldierShooter
    private Vector3 m_CurrentTrajectory;
    private Vector3 m_NewTrajectory;
    private float m_BulletSpeed;

    public void GetBulletData()
    {
        m_CurrentTrajectory = transform.position;
        m_BulletSpeed = m_Pawn.m_ProjectileFireForce;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        GetBulletData();

        // Don't want trajectory to change on hitting other bullets or player
        if (collision.tag == "Wall")
        {
            if (m_NumberOfBounces < m_MaxNumberOfBounces)
            {
                Ray2D ray = new Ray2D(transform.position, transform.right);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, m_BulletSpeed);

                if (hit.collider != null)
                {
                    Debug.Log("Hit");
                    Debug.DrawLine(ray.origin, hit.point);
                    m_CurrentTrajectory = Vector3.Reflect(ray.direction, hit.normal);
                    float rot = 90 - Mathf.Atan2(m_CurrentTrajectory.x, m_CurrentTrajectory.y) * Mathf.Rad2Deg;
                    Debug.DrawRay(hit.point, m_CurrentTrajectory, Color.red);
                    transform.eulerAngles = new Vector3(0, 0, rot);
                    collision.GetComponent<Rigidbody2D>().AddForce(m_CurrentTrajectory * m_BulletSpeed);
                }

                m_NumberOfBounces++;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}