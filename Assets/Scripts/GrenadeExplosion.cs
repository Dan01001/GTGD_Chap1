using UnityEngine;
using System.Collections;

namespace Chapter1
{
    public class GrenadeExplosion : MonoBehaviour
    {
        public float destroyTime = 1f;
        private Collider[] hitColliders;
        public float blastRadius;
        public float explosionPower;
        public LayerMask explosionLayers;

        void start()
        {
           
        }

        void OnCollisionEnter(Collision col)
        {
            ExplostionWork(col.contacts[0].point);
            Destroy(gameObject);
        }

        void ExplostionWork(Vector3 explosionPoint)
        {
            hitColliders = Physics.OverlapSphere(explosionPoint, blastRadius, explosionLayers);
            foreach (Collider hitCol in hitColliders)
            {
                if(hitCol.GetComponent<NavMeshAgent>() != null)
                {
                    hitCol.GetComponent<NavMeshAgent>().enabled = false;
                }
                if(hitCol.GetComponent<Rigidbody>() != null)
                {
                    hitCol.GetComponent<Rigidbody>().isKinematic = false;
                    hitCol.GetComponent<Rigidbody>().AddExplosionForce(explosionPower, explosionPoint, blastRadius, 1, ForceMode.Impulse);
                }

                if (hitCol.CompareTag("Enemy"))
                {
                    Destroy(hitCol.gameObject, destroyTime);
                }
            }

        }
    }

}