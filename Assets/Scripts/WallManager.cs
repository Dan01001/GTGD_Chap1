using UnityEngine;
using System.Collections;
namespace Chapter1
{
    public class WallManager : MonoBehaviour
    {

        private GameManger_EventMaster eventMasterScript;
        Animator animator;
        Animator sphereAnimator;

        void OnEnable()
        {
            animator = GameObject.Find("WallFront").GetComponent<Animator>();
            sphereAnimator = GameObject.Find("SphereAnimated").GetComponent<Animator>();
            eventMasterScript = GameObject.Find("GameManager").GetComponent<GameManger_EventMaster>();
            eventMasterScript.myWallFrontEvent += LowerWallFront;
            eventMasterScript.myWallFrontEvent += CallPulsateSphere;
        }

        void OnDisable()
        {
            eventMasterScript.myWallFrontEvent -= LowerWallFront;
            eventMasterScript.myWallFrontEvent -= CallPulsateSphere;
        }

        void LowerWallFront()
        {
            animator.SetTrigger("FrontWallTrigger");
        }

        void CallPulsateSphere()
        {
            sphereAnimator.SetTrigger("PulsateSphereTrigger");
        }
    }
}

