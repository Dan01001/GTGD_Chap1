using UnityEngine;
using System.Collections;
namespace Chapter1
{
    public class WallManager : MonoBehaviour
    {

        private GameManger_EventMaster eventMasterScript;
       

        void OnEnable()
        {
            eventMasterScript = GameObject.Find("GameManager").GetComponent<GameManger_EventMaster>();
            eventMasterScript.myWallFrontEvent += LowerWallFront;
        }

        void OnDisable()
        {
            eventMasterScript.myWallFrontEvent -= LowerWallFront;
        }

        void LowerWallFront()
        {

        }
    }
}

