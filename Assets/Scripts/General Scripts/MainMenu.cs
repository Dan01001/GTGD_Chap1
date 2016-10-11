using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace S3
{
    public class MainMenu : MonoBehaviour
    {
        public void PlayGame()
        {
            SceneManager.LoadScene("Game");
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }

}
