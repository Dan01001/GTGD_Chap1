﻿using UnityEngine;
using System.Collections;
namespace Chapter1
{
    public class EnemyChase : MonoBehaviour
    {
        public LayerMask detectionLayer;
        private Transform myTransform;
        private NavMeshAgent myNavMeshAgent;
        private Collider[] hitColliders;
        private float checkRate;
        private float nextCheck;
        private float detectionRadius = 50;

        void Start()
        {
            myTransform = transform;
            myNavMeshAgent = GetComponent<NavMeshAgent>();
            checkRate = Random.Range(0.8f, 1.2f);
        }


        void Update()
        {
            CheckIfPlayerInRange();
        }

        void CheckIfPlayerInRange()
        {
            if(Time.time>nextCheck && myNavMeshAgent.enabled == true)
            {
                nextCheck = Time.time + checkRate;
                hitColliders = Physics.OverlapSphere(myTransform.position, detectionRadius, detectionLayer);

                if(hitColliders.Length > 0)
                {
                    myNavMeshAgent.SetDestination(hitColliders[0].transform.position);
                }
            }
        }
    }
}

