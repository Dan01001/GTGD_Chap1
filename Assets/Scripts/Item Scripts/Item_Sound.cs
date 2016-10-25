using UnityEngine;
using System.Collections;

namespace S3
{
    public class Item_Sound : MonoBehaviour {

        private Item_Master itemMaster;
        public float defaultVolume;
        public AudioClip throwSound;

        void OnEnable()
        {
            itemMaster = GetComponent<Item_Master>();
            itemMaster.EventObjectThrow += PlayThrowSound;
        }
        
        void OnDisable()
        {
            itemMaster.EventObjectThrow -= PlayThrowSound;
        }

        void PlayThrowSound()
        {
            if(throwSound != null)
            {
                AudioSource.PlayClipAtPoint(throwSound, transform.position, defaultVolume);
            }
        }
        
       
    }
}