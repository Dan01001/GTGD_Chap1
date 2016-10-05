using UnityEngine;
using System.Collections;

namespace Chapter1
{
    public class WalkThroughWall : MonoBehaviour
    {

        private Color myColor = new Color(0.5f, 1, 0.5f, 0.3f);
        private GameManger_EventMaster eventMasterScript;

        void OnEnable()
        {
            eventMasterScript = GameObject.Find("GameManager").GetComponent<GameManger_EventMaster>();
            eventMasterScript.myGeneralEvent += SetLayerToNotSolid;
        }

        void OnDisable()
        {
            eventMasterScript.myGeneralEvent -= SetLayerToNotSolid;
        }
        
       public void SetLayerToNotSolid()
        {
             gameObject.layer = LayerMask.NameToLayer("NotSolid");
            GetComponent<Renderer>().material.SetColor("_Color", myColor);
        }

        


    }

}

