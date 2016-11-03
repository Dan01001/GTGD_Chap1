using UnityEngine;
using System.Collections;

namespace S3
{
    public class Item_RigidBodies : MonoBehaviour {

        private Item_Master itemMaster;
        public Rigidbody[] rigidBodies;

        void OnEnable()
        {
            itemMaster = GetComponent<Item_Master>();
            
            itemMaster.EventObjectThrow += SetIsKinematicToFalse;
            itemMaster.EventObjectPickup += SetIsKinematicToTrue;
        }
        
        void OnDisable()
        {
            itemMaster.EventObjectThrow -= SetIsKinematicToFalse;
            itemMaster.EventObjectPickup -= SetIsKinematicToTrue;
        }

        void start()
        {
            CheckIfStartsInInventory();
        }
        
        void CheckIfStartsInInventory()
        {
            if (transform.root.CompareTag(GameManager_References._playerTag))
            {
                SetIsKinematicToTrue();
            }
        }

        void SetIsKinematicToTrue()
        {
            if (rigidBodies.Length > 0)
            {
                foreach(Rigidbody rBody in rigidBodies)
                {
                    rBody.isKinematic = true;
                }
            }
        }

        void SetIsKinematicToFalse()
        {
            if (rigidBodies.Length > 0)
            {
                foreach (Rigidbody rBody in rigidBodies)
                {
                    rBody.isKinematic = false;
                }
            }
        }
    }
}