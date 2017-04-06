using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class KeybindScript : MonoBehaviour {

    public Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    public Text P1UpKeyText, P1LeftKeyText, P1DownKeyText, P1RightKeyText, P2UpKeyText, P2LeftKeyText, P2DownKeyText, P2RightKeyText;
    public GameObject currentButton;

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this);

        keys.Add("P1 Up", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("P1 Up", "W")));
        keys.Add("P1 Down", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("P1 Down", "S")));
        keys.Add("P1 Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("P1 Left", "A")));
        keys.Add("P1 Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("P1 Right", "D")));

        keys.Add("P2 Up", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("P2 Up", "UpArrow")));
        keys.Add("P2 Down", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("P2 Down", "DownArrow")));
        keys.Add("P2 Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("P2 Left", "LeftArrow")));
        keys.Add("P2 Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("P2 Right", "RightArrow")));

        P1UpKeyText.text = keys["P1 Up"].ToString();
        P1DownKeyText.text = keys["P1 Down"].ToString();
        P1LeftKeyText.text = keys["P1 Left"].ToString();
        P1RightKeyText.text = keys["P1 Right"].ToString();

        P2UpKeyText.text = keys["P2 Up"].ToString();
        P2DownKeyText.text = keys["P2 Down"].ToString();
        P2LeftKeyText.text = keys["P2 Left"].ToString();
        P2RightKeyText.text = keys["P2 Right"].ToString();

        SaveKeys();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        if (currentButton != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                keys[currentButton.name] = e.keyCode;
                currentButton.transform.GetChild(0).GetComponent<Text>().text = Event.current.keyCode.ToString();
                currentButton = null;
            }
        }
    }

    public void ChangeKeyPressed(GameObject button)
    {
        currentButton = button;
    }

    public void SaveKeys()
    {
        foreach(var key in keys)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }

        PlayerPrefs.Save();
        Debug.Log("PREFS SAVED");
    }
}
