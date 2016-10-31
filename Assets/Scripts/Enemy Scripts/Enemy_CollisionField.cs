using UnityEngine;
using System.Collections;

namespace S3
{
    public class Enemy_CollisionField : MonoBehaviour {

        private Enemy_Master enemyMaster;
        private Rigidbody rigidBodyStrikingMe;
        private int damageToApply;
        public float massRequirement = 50;
        public float speedRequirment = 5;
        private float damageFactor = 0.1f;

        void OnEnable()
        {
            SetIntialReferences();
            enemyMaster.EventEnemyDie += DisableThis;
        }
        
        void OnDisable()
        {
            enemyMaster.EventEnemyDie -= DisableThis;
        }

        void SetIntialReferences()
        {
            enemyMaster = transform.root.GetComponent<Enemy_Master>();
        }

        void OnTriggerEnter(Collider other)
        {
            if(other.GetComponent<Rigidbody>() != null)
            {
                rigidBodyStrikingMe = other.GetComponent<Rigidbody>();

                if (rigidBodyStrikingMe.mass >= massRequirement && rigidBodyStrikingMe.velocity.sqrMagnitude > speedRequirment * speedRequirment)
                {
                    damageToApply = (int)(damageFactor * rigidBodyStrikingMe.mass * rigidBodyStrikingMe.velocity.magnitude);
                    enemyMaster.CallEventEnemyDeductHealth(damageToApply);
                }
            }
        }

        void DisableThis()
        {
            gameObject.SetActive(false);
        }
    }
}