using UnityEngine;
using System.Collections;
namespace Chapter1
{
    public class GameManger_EventMaster : MonoBehaviour
    {
        public delegate void GeneralEvent();
        public event GeneralEvent myGeneralEvent;
        public event GeneralEvent myWallFrontEvent;
        public event GeneralEvent myPulsateSphereEvent;

        public void CallMyGeneralEvent()
        {
            if(myGeneralEvent != null)
            {
                myGeneralEvent();
            }
        }

        public void CallWallFrontEvent()
        {
            if (myGeneralEvent != null)
            {
                myWallFrontEvent();
            }
        }

        public void CallSpherePulsate()
        {
            if (myGeneralEvent != null)
            {
                myPulsateSphereEvent();
            }
        }
    }
}

