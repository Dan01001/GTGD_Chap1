using UnityEngine;
using System.Collections;

namespace S3
{
    public class Player_DetectItem : MonoBehaviour
    {

        [Tooltip("What layer is being use for items.")]
        public LayerMask layerToDetect;
        [Tooltip("What transform will the ray be fired from?")]
        public Transform rayTransformPivot;
        [Tooltip("the editor input button that will be used for picking up items.")]
        public string buttonPickup;

        private Transform itemAvailableforPickup;
        private RaycastHit hit;
        private float detectRange = 3;
        private float detectRadius = 0.7f;
        private bool itemInRange;

        private float labelWidth = 200;
        private float labelHeight = 50;


	
        
        void Update () 
        {
            CastRayForDetectingItems();
            CheckForItemPickupAttempt();
           
        }

        void CastRayForDetectingItems()
        {
            if(Physics.SphereCast(rayTransformPivot.position, detectRadius, rayTransformPivot.forward, out hit, detectRange, layerToDetect))
            {
                itemAvailableforPickup = hit.transform;
                itemInRange = true;
            }
            else
            {
                itemInRange = false;
            }
        }

        void CheckForItemPickupAttempt()
        {
            if(Input.GetButtonDown(buttonPickup) && Time.timeScale > 0 && itemInRange && itemAvailableforPickup.root.tag != GameManager_References._playerTag)
            {
               
                // itemAvailableforPickup.GetComponent<Item_Master>().CallEventPickupAction(rayTransformPivot);
                itemAvailableforPickup.GetComponent<Item_Master>().CallEventPickupAction(rayTransformPivot);
            }
        }

        void OnGUI()
        {
            if (itemInRange && itemAvailableforPickup != null)
            {
                GUI.Label(new Rect(Screen.width / 2 - labelWidth / 2, Screen.height / 2, labelWidth, labelHeight), itemAvailableforPickup.name);
            }
        }
    }
}