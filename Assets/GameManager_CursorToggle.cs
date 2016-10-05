using UnityEngine;
using System.Collections;

namespace Chapter1
{
    public class GameManager_CursorToggle : MonoBehaviour
    {
        private bool isCursorLocked = false;

        void Start()
        {
            ToggleCursorState();
        }

        void Update()
        {
            CheckForInput();
            CheckifCursorShouldBeLocked();
        }

        void ToggleCursorState()
        {
            isCursorLocked = !isCursorLocked;
        }

        void CheckForInput()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ToggleCursorState();
            }
        }

        void CheckifCursorShouldBeLocked()
        {
            if (isCursorLocked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

    }
}

