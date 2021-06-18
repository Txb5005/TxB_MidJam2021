using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Manager : MonoBehaviour
{
    bool paused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                paused = true;
                Show(true);
                PauseMode();
            }
        }
    }

    public void Resume()
    {
        paused = false;
        Show(false);
        PlayMode();
    }
    public void MenuMode()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1;
    }
    public void PlayMode()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }
    public void PauseMode()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }
    void Show(bool active)
    {
        transform.GetChild(0).gameObject.SetActive(active);
    }
}
