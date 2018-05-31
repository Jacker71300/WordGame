using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointPrinter : MonoBehaviour {
	//Variables
	public ArrayList listWords = new ArrayList();
	string points;
    public Text pointtext = null;

	// Use this for initialization
	void Start ()
    {
        //Declares the Current File Directory
        string fileDirectory = System.IO.Directory.GetCurrentDirectory ();

        //Takes in only the points text file that is created in Game Controller after each correct guess
        fileDirectory.Substring (0, fileDirectory.Length - 24);
        points = System.IO.File.ReadAllText(fileDirectory + "/Assets/Resources/TextFiles/points.txt");
        
        //Supposedly takes in all the words
        listWords.AddRange(System.IO.File.ReadAllLines (fileDirectory, System.Text.Encoding.GetEncoding("iso-8859-1")));

        //Supposedly changes text
        pointtext.text = "If this works, it will read this.";
	}
}
