/*
 * J. Hoffman
 * Changes scenes, simple as that
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Changes scenes
public class StartButton : MonoBehaviour {

	// Instance variables
	public string sceneName = "MainMenu";
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}

	// Handles when the start button has been pressed
    public void changeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
