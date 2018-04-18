/*
 * J. Hoffman
 * Create a new hint available for the player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hint : MonoBehaviour {
	public Text text = null;

	private string currentWord = "";
	private string hint = "";

	// Use this for initialization
	void Start () {

	}

	// Called when clicked on
	public void GiveHint () {
		// Get file directory
		string fileDirectory = System.IO.Directory.GetCurrentDirectory ();

		fileDirectory.Substring (0, fileDirectory.Length - 24);
		fileDirectory += "/Assets/TextFiles/CurrentWord.txt";

		// Read in the file and see if it is still the same
		string holder = System.IO.File.ReadAllText (fileDirectory);
		print (holder);
		print (currentWord);

		// If the word hasn't changed, don't generate a new hint
		if (holder != currentWord) {
			currentWord = holder;
			GenerateHint ();
		}

		// Print the hint
		text.text = (hint);
	}

	// Called when a new word appears
	void GenerateHint () {
		// Generate what indecies will be blanked out
		int[] randomNums = new int[(int)(currentWord.Length / 2.0 + .5)];

		for (int i = 0; i < (int)(currentWord.Length / 2.0 + .5); i++) {
			randomNums[i] = Random.Range (0, currentWord.Length - 1);

			if (i != 0 && (-1 == System.Array.IndexOf(randomNums, randomNums[i]) ||
				i != System.Array.IndexOf(randomNums, randomNums[i]))) {
				i--;
			}
		}

		// Sort the random numbers for easier replacement
		System.Array.Sort (randomNums);
		hint = currentWord;

		// Change each letter at the random indecies into an underscore
		for (int i = 0; i < randomNums.Length; i++) {
			if (randomNums [i] == 0) {
				hint = ("_") + hint.Substring (1);
				//print (hint);
			}
			else
				hint = hint.Substring (0, randomNums [i]) + ("_") + hint.Substring (randomNums [i] + 1);
			hint = hint.ToUpper ();
		}

	}
}