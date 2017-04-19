using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public Canvas pauseMenu;
    public Canvas quitMenu;

    public AudioSource[] sounds;
    public AudioSource music;
    public AudioSource pause;

    // Use this for initialization
    void Start()
    {
        quitMenu = quitMenu.GetComponent<Canvas>();
        pauseMenu = pauseMenu.GetComponent<Canvas>();
        pauseMenu.enabled = false;
        quitMenu.enabled = false;

        sounds = GetComponents<AudioSource>();

        music = sounds[0];
        pause = sounds[1];

        music.Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenu.enabled && !quitMenu.enabled)
            {
                music.Pause();
                pause.Play();
                Time.timeScale = 0;
                pauseMenu.enabled = true;
            }
            else
            {
                pause.Pause();
                music.Play();
                Time.timeScale = 1;
                pauseMenu.enabled = false;
                quitMenu.enabled = false;
            }
        }
    }

    public void ResumeGame()
    {
        pause.Pause();
        music.Play();
        pauseMenu.enabled = false;
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void ExitPress()
    {
        pauseMenu.enabled = false;
        quitMenu.enabled = true;
    }

    public void QuitToMainMenuPress()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void CancelPress()
    {
        pauseMenu.enabled = true;
        quitMenu.enabled = false;
    }

    public void QuitToDesktopPress()
    {
        Application.Quit();
    }

   
}
