using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//switching to different unity scenes
public class SceneSwitching : MonoBehaviour {

    //Canvases
    public Canvas TitleScreen;
    public Canvas TutorialScreen;
    public Canvas AuthorScreen;

	// Use this for initialization
	void Start () {
        TutorialScreen.enabled = false;
        AuthorScreen.enabled = false;
        TitleScreen.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void LoadMainGame()
    {
        TitleScreen.enabled = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }

    public void SwitchToTutorial()
    {
        TitleScreen.enabled = false;
        AuthorScreen.enabled = false;
        TutorialScreen.enabled = true;
    }

    public void SwitchToAuthorPage()
    {
        TitleScreen.enabled = false;
        TutorialScreen.enabled = false;
        AuthorScreen.enabled = true;
    }

    public void SwitchToMain()
    {
        TitleScreen.enabled = true;
        TutorialScreen.enabled = false;
        AuthorScreen.enabled = false;
    }
    
}
