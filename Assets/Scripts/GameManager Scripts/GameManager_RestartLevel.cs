using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace S3
{
    public class GameManager_RestartLevel : MonoBehaviour
    {
        private GameManager_Master gameManager_Master;

        void OnEnable()
        {
            gameManager_Master = GetComponent<GameManager_Master>();
            gameManager_Master.RestartLevelEvent += RestartLevel;

        }

        void OnDisable()
        {
            gameManager_Master.RestartLevelEvent -= RestartLevel;
        }

        void RestartLevel()
        {
            SceneManager.LoadScene("Game");
        }
    }

}

