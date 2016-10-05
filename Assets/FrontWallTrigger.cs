using UnityEngine;
using System.Collections;
namespace Chapter1
{
    public class FrontWallTrigger : MonoBehaviour
    {
        private GameManger_EventMaster eventMasterScript;



        void Start()
        {
            eventMasterScript = GameObject.Find("GameManager").GetComponent<GameManger_EventMaster>();
           
        }

        void OnTriggerEnter(Collider other)
        {
            Debug.Log("Entered WallFront Trigger");
            eventMasterScript.CallWallFrontEvent();
            
        }

    }
}

