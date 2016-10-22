using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace S3
{
    public class Player_AmmoBox : MonoBehaviour {

        private Player_Master playerMaster;

        [System.Serializable]
        public class AmmoTypes
        {
            public string ammoName;
            public int ammoCurrentCarried;
            public int ammoMaxQuantity;

            public AmmoTypes(string aName, int aMaxQuantity, int aCurrentCarried)
            {
                ammoName = aName;
                ammoCurrentCarried = aMaxQuantity;
                ammoMaxQuantity = aCurrentCarried;
            }
        }

        public List<AmmoTypes> typesOfAmmunition = new List<AmmoTypes>();


        void OnEnable()
        {
            playerMaster = GetComponent<Player_Master>();
            playerMaster.EventPickedUpAmmo += PickedUpAmmo;
        }
        
        void OnDisable()
        {
            playerMaster.EventPickedUpAmmo -= PickedUpAmmo;
        }
        
       void PickedUpAmmo(string ammoName, int quantity)
        {
            for(int i = 0; i < typesOfAmmunition.Count; i++)
            {
                if(typesOfAmmunition[i].ammoName == ammoName)
                {
                    typesOfAmmunition[i].ammoCurrentCarried += quantity;

                    if(typesOfAmmunition[i].ammoCurrentCarried > typesOfAmmunition[i].ammoMaxQuantity)
                    {
                        typesOfAmmunition[i].ammoCurrentCarried = typesOfAmmunition[i].ammoMaxQuantity;
                    }

                    playerMaster.CallEventAmmoChanged();

                    break;
                }
            }
        }
    }
}