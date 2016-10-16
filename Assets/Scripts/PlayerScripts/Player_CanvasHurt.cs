using UnityEngine;
using System.Collections;

namespace S3
{
    public class Player_CanvasHurt : MonoBehaviour {

        public GameObject hurtCanvas;
        private Player_Master playerMaster;
        private float secondsTillHide = 2;

        void OnEnable()
        {
            playerMaster = GetComponent<Player_Master>();
            playerMaster.EventPlayerHealthDeduction += TurnOnHurtEffect;
        }
        
        void OnDisable()
        {
            playerMaster.EventPlayerHealthDeduction -= TurnOnHurtEffect;
        }
        
        void TurnOnHurtEffect(int dummy)
        {
            if(hurtCanvas != null)
            {
                StopAllCoroutines();
                hurtCanvas.SetActive(true);
                StartCoroutine(ResetHurtCanvas());
            }
        }

        IEnumerator ResetHurtCanvas()
        {
            yield return new WaitForSeconds(secondsTillHide);
            hurtCanvas.SetActive(false);
        }
    }
}