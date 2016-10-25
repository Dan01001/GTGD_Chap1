using UnityEngine;
using System.Collections;

namespace S3
{
    public class Item_Tag : MonoBehaviour {

        public string itemTag;

        void OnEnable()
        {
            if(itemTag == "")
            {
                itemTag  = "Untagged";
            }

            transform.tag = itemTag;
        }
        
       
    }
}