using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour {

    public Canvas mainMenu;
    public Canvas quitMenu;
    public Canvas keybindMenu;
    public Canvas HowTo;

    public AudioSource[] sounds;

    public AudioSource talking;

    // Use this for initialization
    void Start () {
        mainMenu = mainMenu.GetComponent<Canvas>();
        quitMenu = quitMenu.GetComponent<Canvas>();
        mainMenu.enabled = true;
        quitMenu.enabled = false;
        keybindMenu.enabled = false;
        HowTo.enabled = false;

        sounds = GetComponents<AudioSource>();
        talking = sounds[0];
        talking.Play();
    }
	
	public void QuitPress()
    {
        mainMenu.enabled = false;
        quitMenu.enabled = true;
    }

    public void CancelPress()
    {
        mainMenu.enabled = true;
        quitMenu.enabled = false;
    }

    public void YesPress()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void KeybindsPress()
    {
        mainMenu.enabled = false;
        keybindMenu.enabled = true;
    }

    public void KeybindsExit()
    {
        mainMenu.enabled = true;
        keybindMenu.enabled = false;
    }

    public void HowToPress()
    {
        mainMenu.enabled = false;
        HowTo.enabled = true;
    }

    public void HowToExit()
    {
        mainMenu.enabled = true;
        HowTo.enabled = false;
    }
}
