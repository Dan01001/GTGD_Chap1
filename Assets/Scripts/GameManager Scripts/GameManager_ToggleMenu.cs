using UnityEngine;
using System.Collections;
namespace S3
{
    public class GameManager_ToggleMenu : MonoBehaviour
    {
        private GameManager_Master gameManagerMaster;
        public GameObject menu;

        void Start()
        {           
            ToggleMenu();
        }


        void Update()
        {
            CheckForMenuToggleRequest();
        }

        void OnEnable()
        {
            gameManagerMaster = GetComponent<GameManager_Master>();
            gameManagerMaster.GameOverEvent += ToggleMenu;
        }

        void OnDisable()
        {
            gameManagerMaster.GameOverEvent -= ToggleMenu;
        }

        void CheckForMenuToggleRequest()
        {
            if(Input.GetKeyUp(KeyCode.Escape) && !gameManagerMaster.isGameOver && !gameManagerMaster.isInventoryUiOn)
            {
                ToggleMenu();
            }
        }

        void ToggleMenu()
        {
            
            if(menu != null)
            {
                menu.SetActive(!menu.activeSelf);
                gameManagerMaster.isMenuOn = !gameManagerMaster.isMenuOn;
                gameManagerMaster.CallEventMenuToggle();
            }
            else
            {
                Debug.LogWarning("You need to assign a UI GameObjec to the toggle menu script in the inspector");
            }
        }

    }
}
