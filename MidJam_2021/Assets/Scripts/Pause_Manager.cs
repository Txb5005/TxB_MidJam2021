using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Manager : MonoBehaviour
{
    bool paused = false;
    [SerializeField] GameObject controls;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
#if UNITY_EDITOR // for testing without losing mouse due to Unity's IDE
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Pause();
        }
#endif
    }

    void Pause()
    {
        if (!paused)
        {
            paused = true;
            Show(true);
            PauseMode();
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
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1;
    }
    public void PlayMode()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }
    public void PauseMode()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }
    void Show(bool active)
    {
        transform.GetChild(0).gameObject.SetActive(active);
    }
    public void ShowControls(bool active)
    {
        controls.SetActive(active);
    }
    public void LoadScene(string scene)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(scene);
    }
    public void Quit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
