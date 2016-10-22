using UnityEngine;
using System.Collections;

namespace S3
{
    public class Item_Pickup : MonoBehaviour {

        private Item_Master itemMaster;
        

        void OnEnable()
        {
            itemMaster = GetComponent<Item_Master>();
            itemMaster.EventPickupAction += CarryOutPickupActions;
        }
        
        void OnDisable()
        {
            itemMaster.EventPickupAction -= CarryOutPickupActions;
        }

        void CarryOutPickupActions(Transform tParent)
        {
            transform.SetParent(tParent);
            itemMaster.CallEventObjectPickup();
            transform.gameObject.SetActive(false);

        }
    }
}