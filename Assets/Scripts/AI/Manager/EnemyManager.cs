
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : CharacterManager
{
    EnemyLocomotionManager enemyLocomotionManager;
    public bool isPreformingAction;

    [Header("A.I. Settins")]
    public float detectionRadius = 20f;
    public float minimumDetectionAngle = -50f;
    public float maximumDetectionAngle = 50f;

    private void Awake()
    {
        enemyLocomotionManager = GetComponent<EnemyLocomotionManager>();
    }

    // Update is called once per frame
    private void Update()
    {

    }
    private void FixedUpdate()
    {
        HandleCurrentAction();
    }

    private void HandleCurrentAction()
    {
        if (enemyLocomotionManager.currentTarget == null)
        {
            enemyLocomotionManager.HandleDetection();
        }
        else
        {
            enemyLocomotionManager.HandleMoveToTarget();
        }
    }
}
