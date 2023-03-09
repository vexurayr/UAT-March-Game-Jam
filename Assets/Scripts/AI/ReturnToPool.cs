using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToPool : MonoBehaviour
{
    [SerializeField] private float lifeTime = 2f;
    [SerializeField] private GameObject player;

    private float distanceToPlayer;


    private void Return()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        distanceToPlayer = Vector2.Distance(player.transform.position, transform.position);

        if (distanceToPlayer > 40)
        {
            Invoke(nameof(Return), lifeTime);
        }
        else
        {
            CancelInvoke();
        }
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
