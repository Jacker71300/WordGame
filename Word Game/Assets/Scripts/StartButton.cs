﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {

	// Instance variables
	public string sceneName = "MainMenu";
    
	private string fileName = "";
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

	public void setFileName(){
		fileName = GameObject.Find ("Text").GetComponent<GUIText> ().ToString ();
		string fileDirectory = System.IO.Directory.GetCurrentDirectory ();

		fileDirectory.Substring (0, fileDirectory.Length - 21);
		fileDirectory += "/Assets/Vocab Lists/Selection.txt";
		System.IO.File.WriteAllText (fileDirectory, string.Empty);
		print (fileDirectory);
		System.IO.File.WriteAllText (fileDirectory, fileName);
	}
}
