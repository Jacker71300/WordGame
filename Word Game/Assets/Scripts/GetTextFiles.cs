using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTextFiles : MonoBehaviour {
	public Dropdown drop = null;

	List<string> files = new List<string>();
	string fileDirectory = System.IO.Directory.GetCurrentDirectory ();

	// Use this for initialization
	void Start () {
		fileDirectory += "/Assets/Vocab Lists/";
		fetchNames ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void fetchNames(){
		files.AddRange(System.IO.Directory.GetFiles (fileDirectory, "*.txt"));

		for (int i = 0; i < files.Count; i++) {
			//print (files [i]);
			//print (files [i].Length - 4);
			int start = files [i].IndexOf ("Vocab Lists") + 12;
			files [i] = files [i].Substring (start, (files [i].Length - 4) - start);
			//print (files [i]);
		}

		drop.ClearOptions ();
		drop.AddOptions (files);

		files.Clear ();
	}
}
