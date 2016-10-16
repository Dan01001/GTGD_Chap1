using UnityEngine;
using System.Collections;
namespace S3
{
    public class GameManager_GameOver : MonoBehaviour
    {

        private GameManager_Master gameManager_Master;
        public GameObject panelGameOver;

        void OnEnable()
        {
            gameManager_Master = GetComponent<GameManager_Master>();
            gameManager_Master.GameOverEvent += TurnOnGameOverPanel;
        }

        void OnDisable()
        {
            gameManager_Master.GameOverEvent -= TurnOnGameOverPanel;
        }

        void TurnOnGameOverPanel()
        {
            if(panelGameOver != null)
            {
                panelGameOver.SetActive(true);
            }
        }
        
    }
}

