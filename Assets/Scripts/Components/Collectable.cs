using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int pointsAwarded;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Character>() != null)
        {
            PointsManager.instance.SetPlayerScore(PointsManager.instance.GetPlayerScore() + pointsAwarded);

            Destroy(this.gameObject);
        }
    }
}