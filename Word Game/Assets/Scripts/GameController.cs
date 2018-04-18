/*
 * J. Hoffman
 * Controls the game while words are being guessed
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Controls the game screen and behind the scenes calculations
public class GameController : MonoBehaviour {

	// Instance Variables
	public ArrayList listWords = new ArrayList();
	public ArrayList letterPics = new ArrayList();
	public Transform Letter;
	public Transform canvas;
	public Text text;

	private string guess = "";
	private string currentWord = "";

	// Use this for initialization
	void Start () {
		// Find the vocab list file and read all vocab words into an array
		string fileDirectory = System.IO.Directory.GetCurrentDirectory ();
		string fileChoice;

		fileDirectory.Substring (0, fileDirectory.Length - 24);
		fileChoice = System.IO.File.ReadAllText(fileDirectory + "/Assets/TextFiles/Selection.txt");

		fileDirectory += "/Assets/Vocab Lists/" + fileChoice + ".txt";

		listWords.AddRange(System.IO.File.ReadAllLines (fileDirectory, System.Text.Encoding.GetEncoding("iso-8859-1")));

		// Shuffle the words
		for(int i = Random.Range(0, 101); i > 0; i --){
			int temp = (int)Random.Range (0.0f, listWords.Count);
			string word = (string) listWords[temp];
			listWords.RemoveAt(temp);
			listWords.Add(word);
		}
		CreateWord ();
	}
	
	// Update is called once per frame
	void Update () {
		// Polls for the guess which is saved to a file
		string fileDirectory = System.IO.Directory.GetCurrentDirectory ();

		fileDirectory.Substring (0, fileDirectory.Length - 24);
		fileDirectory += "/Assets/TextFiles/Guess.txt";
		try{
			guess = System.IO.File.ReadAllLines(fileDirectory)[0];
			text.text = guess;
		}
		catch{
			guess = "";
			text.text = guess;
		}

		// Checks to see if guess is correct
		if(guess.ToUpper().Replace(" ", "").Equals(currentWord.ToUpper().Replace(" ", ""))){
			WordSuccess();
		}
	}

	// Handles when word is guessed correctly
	void WordSuccess(){

		// Delete all game instances of letters
		while(letterPics.Count > 0){
			for(int i = letterPics.Count - 1; i >= 0; i--) {
				GameObject holder = letterPics[i] as GameObject;
				letterPics.RemoveAt(i);
				print ("destroy " + holder);
				DestroyImmediate (holder);
			}
		}
			
		try{
			CreateWord ();
		}
		catch{
			Win ();
		}
	}

	// Handles when all words have been completed
	void Win(){
		// Change scene to main menu
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Win");
	}

	// Handles creating a new word out of images
	void CreateWord(){
		currentWord = (string) listWords [0];
		listWords.RemoveAt (0);
		currentWord = currentWord.ToLower ().Replace(" ", "");

		// Puts the word in a file to be accessed by the hint script
		string fileDirectory = System.IO.Directory.GetCurrentDirectory ();

		fileDirectory.Substring (0, fileDirectory.Length - 24);
		fileDirectory += "/Assets/TextFiles/CurrentWord.txt";

		System.IO.File.WriteAllText (fileDirectory, string.Empty);
		System.IO.File.WriteAllText (fileDirectory, currentWord);

		char[] letters = shuffle(currentWord.ToCharArray ());

		// Create the positions where the pictures will show up
		// Each object will use their respective index in the array
		float[] positionsX = new float[letters.Length];
		float[] positionsY = new float[letters.Length];

		float WIDTH = Screen.width;
		float HEIGHT = Screen.height * 3f/5f;
		float MAX_PER_LINE = 10;
		int numLetters = letters.Length;

		// Set y values
		if (numLetters > MAX_PER_LINE) {
			print ("moreThan5");

			int lines = (int)((float)numLetters / MAX_PER_LINE + 0.999f);
			int numPerLineHighest = (int)((float)numLetters / lines + 0.999f);

			for (int i = 0; i < lines; i++) {
				try{
					for (int holder = numPerLineHighest * i; holder < (numPerLineHighest * (i + 1)); holder++) {
						positionsY [holder] = HEIGHT / lines * (i + 1);
						//print(positionsY[holder]);
						//print(holder);
						//print(HEIGHT/lines*(i+1));
					}
				}
				catch{/* Values are finished being set */}
			}
		} else {
			print ("lessThan5");
			for (int i = 0; i < positionsY.Length; i++) {
				positionsY [i] = HEIGHT * 1 / 2;
			}
		}

		// Set x values
		int counter = 1;
		int lineNumber = 1;

		for (int i = 0; i < numLetters; i++) {
			try{
				if (positionsY [i] == positionsY [i + 1]) {
					counter++;;
				}
				else{
					for(int x = 0; x < counter; x++){
						positionsX[i-x] = WIDTH/(counter + 1) * (x + 1);
					}
					lineNumber++;
					counter = 1;
				}
			}
			catch{
				for(int x = 0; x < counter; x++){
					positionsX[i-x] = WIDTH/(counter + 1) * (x + 1);
				}
				lineNumber = 1;
				counter = 1;
			}
		}

		for (int i = 0; i < positionsX.Length; i++) {
			print ("( " + positionsX [i] + " , " + positionsY[i] + " )");
		}
			
		// Clear the arraylist to make sure nothing is left over from the last word
		letterPics.Clear ();

		// Create the pictures in the game
		for(int i = 0; i < letters.Length; i++){
			// Add a new instance of the prefab
			Transform holder = (Instantiate (Letter, new Vector3 (positionsX[i], positionsY[i]), Quaternion.identity) as RectTransform);

			// Name it and add it to the UI canvas
			holder.SetParent (canvas);
			holder.name = "unity" + i;

			// Get the file name of the picture representing the character and set as sprite
			string filename = letters [i].ToString ().ToUpper ();
			print (letters [i].ToString ().ToUpper ());
			print (letters [i].ToString ());
			holder.GetComponent<Image> ().sprite = Resources.Load<Sprite>(filename);

			// Add the game reference of the current object to an arraylist for deletion later
			letterPics.Add (GameObject.Find(holder.name));
		}

	}

	// Shuffle method for any char array
	char[] shuffle(char[] charArray){
		char[] shuffled = new char[charArray.Length];
		int random;

		for (int i = charArray.Length; i >= 1; i--) {
			random = (int)Random.Range (1f, i + 1f) - 1;
			shuffled [i - 1] = charArray [random];
			charArray [random] = charArray [i - 1];
		}
		return shuffled;
	}
}