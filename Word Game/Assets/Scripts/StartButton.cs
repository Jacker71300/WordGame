using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {

	// Instance variables
	public string sceneName = "MainMenu";
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void changeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
