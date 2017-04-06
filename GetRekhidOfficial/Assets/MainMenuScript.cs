using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour {

    public Canvas mainMenu;
    public Canvas quitMenu;
    public Canvas keybindMenu;

	// Use this for initialization
	void Start () {
        mainMenu = mainMenu.GetComponent<Canvas>();
        quitMenu = quitMenu.GetComponent<Canvas>();
        mainMenu.enabled = true;
        quitMenu.enabled = false;
        keybindMenu.enabled = false;

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

}
