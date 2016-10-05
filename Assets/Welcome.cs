using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Chapter1
{
    public class Welcome : MonoBehaviour
    {
        public string myMessage = "Welcome";
        private Text textWelcome;

        public GameObject canvasWelcome;

        void Start()
        {
            textWelcome = GameObject.Find("TextWelcome").GetComponent<Text>();
            MyWelcomeMessage();
        }

        void MyWelcomeMessage()
        {
            if(textWelcome != null)
            {
                textWelcome.text = myMessage;
            }
            else
            {
                Debug.Log("welcomeText not assigned");
            }

            StartCoroutine(DisableCanvas(0.2f));

        }

        IEnumerator DisableCanvas(float time)
        {
            yield return new WaitForSeconds(time);
            canvasWelcome.SetActive(false);
        }



        void Update()
        {

        }
    }
}

