using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointPrinter : MonoBehaviour {
	//Variable
	public ArrayList listWords = new ArrayList();
	string points;
    public Text pointtext = null;

	// Use this for initialization
	void Start ()
    {
        string fileDirectory = System.IO.Directory.GetCurrentDirectory ();

        fileDirectory.Substring (0, fileDirectory.Length - 24);
        points = System.IO.File.ReadAllText(fileDirectory + "/Assets/Resources/TextFiles/points.txt");

        listWords.AddRange(System.IO.File.ReadAllLines (fileDirectory, System.Text.Encoding.GetEncoding("iso-8859-1")));
        pointtext.text = "You got " + points + " out of " + listWords.Count + " points!";
	}
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            pointtext.text = "Text has changed.";
        }
    }
}
