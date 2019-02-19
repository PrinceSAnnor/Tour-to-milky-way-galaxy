using System.Collections; //access namespace
using System.Collections.Generic;//access namespace
using UnityEngine; //access namespace
using UnityEngine.UI; //access namespace

public class question : MonoBehaviour { //class question definition
	//List containing questions
	List<string> questions = new List<string>() {"Which planet is closest to Jupiter?", "How many planets are there in our solar system?", "Which is the smallest planet?", "What is the largest planet?", "Which planet is closest to the Sun?", "Which planet is farthest from the Sun?", "What is the coldest planet?", "What is the hottest planet?", "Which planet has one moon?", "Which planet is the flattest planet?", "Which planet has the largest rings?", "Which planet has similar size and mass as Earth?", "How many days is a year on Earth?", "Which planet is known as the \"Red Planet\"?", "Which planet has a giant red spot that could fit three Earths inside it?", "Which planet is also known as the \"Ice Giant\"?", "Which planet comes next to Jupiter?", "What is the name of the mode of transport you used to roam about space?", "Which planet has the largest moon in the solar system?"};
	//encoded list containing answers
	List<string> correctAnswers = new List<string> () {"4", "3", "4", "3", "1", "4", "2", "3", "3", "2", "2", "2", "3", "3", "1", "1", "3", "2","1"};
	//random number variable that sychronises question list with four alternative list and eventually with the correctAnswer list
	public static int randQuestion = -1;
	public static string selectedAnswer; //variable for user selected choice
	public static int maxquestions = 0; //max questions a user can solve per quiz
	public static GameObject[] objects; //array of game objects with tag "Finish"
	public static string choiceSelected = "n"; //string to check if user clicks an alternative
	private GameObject nextButton,restart; //game object reference for nextbutton and
	public Transform closing; //reference to transform to closing text object
	public static AudioSource audio1; //reference to audio source on question object
	public Text nextText; //reference to text on next button
	private List<int> usedRands = new List<int>(); //list to store random numbers already used to pick questions
	public static GameObject closing_image; //reference to closing image
	public Transform resultObj; //reference to result text transform
	public GameObject[] pemObjs;
	public static GameObject[] pemObjslevel;
	public int UniqueRandomInt(int min, int max) //non repeating random function from http://answers.unity3d.com/questions/498289/not-repeat-random-number-randomrange.html
	{
		int val = Random.Range(min, max);
		while(usedRands.Contains(val))
		{
			val = Random.Range(min, max);
		}
		return val;
	} //returns a non repeating random number

	void Start () { //runs only once for initializing references etc
		//initializing references declared above
		audio1 = GetComponent<AudioSource> (); //initializing audio
		GameObject temp; //temp variable for holding temporal references  
		restart = GameObject.FindGameObjectWithTag ("restart"); //get reference to restart button 
		temp = restart; //store reference to restart button into temp as it would be lost 
		restart.SetActive (false); //turn off restart button, reference lost
		restart = temp; //get reference to restart button back from temp
		closing_image = GameObject.FindGameObjectWithTag ("image"); //get loading image object
		temp = closing_image; //store reference to loading image into temp as it would be lost 
		closing_image.SetActive (false); //turn off closing image, reference lost
		closing_image = temp; // get reference to closing image back from temp
		nextButton = next.pemNext;//get reference to next button from next class(script) 
		objects = GameObject.FindGameObjectsWithTag ("Finish"); //store objects with tag finish into objects array
		pemObjs = GameObject.FindGameObjectsWithTag("BoomBoom"); //audio object array for level win
		pemObjslevel = GameObject.FindGameObjectsWithTag("Boomlevel"); //audio object array for final win
		GameObject[] tempObjs = pemObjs;
		for (int i = 0; i < tempObjs.Length; i++) {
			tempObjs [i].SetActive (false);
		}
		tempObjs = pemObjslevel;
		for (int i = 0; i < tempObjs.Length; i++) {
			tempObjs [i].SetActive (false);
		}
	}
	/*
     *General selection system code below from https://www.youtube.com/watch?v=Nu5m6tOVInw
     */
	// Update is called once per frame
	void Update () {
		if (randQuestion == -1) { //if randQuestion is negative one, generate new random number. Would work if next button is clicked
			randQuestion = UniqueRandomInt (0, 19); //generate random number between 0 and 21
			usedRands.Add (randQuestion); //add random question to usedRandom number lists
		}
		if (randQuestion > -1) { //if random question is greater than -1, question chosen
			GetComponent<TextMesh>().text = questions [randQuestion]; //put question string into question's object
		}

		if (choiceSelected == "y") { //if any button is clicked
			choiceSelected = "n";//set no button is clicked
			if (correctAnswers [randQuestion] == selectedAnswer) { //if answer is correct
				for (int i = 0; i < pemObjslevel.Length; i++) {//turn on level fireworks animation array
					pemObjslevel [i].SetActive (true);
				}
				audio1.Play();//play audio file
				if(maxquestions == 9)//if on the last question
				{
					resultObj.GetComponent<TextMesh> ().text = "Correct!!! Click FINISH to conclude..."; //display text
					nextText.text = "FINISH";//display finish on button
				}
				else //if not on the last question
					resultObj.GetComponent<TextMesh> ().text = "Correct!!! Click Next to continue..."; //display text
				GameObject[] temps = objects;
				if (correctAnswers [randQuestion] == "1") { //2, objects array index, if answer is first alt
					objects [6].SetActive (false);
					objects [1].SetActive (false);
					objects [3].SetActive (false);
				}//set all other buttons off
				else if (correctAnswers [randQuestion] == "2") {//6, objects array index, if answer is second alt
					objects [1].SetActive (false);
					objects [2].SetActive (false);
					objects [3].SetActive (false);
				}// turn off other buttons off
				else if (correctAnswers [randQuestion] == "3") {//1, objects array index, if answer is third alt
					objects [6].SetActive (false);
					objects [2].SetActive (false);
					objects [3].SetActive (false);
				} //turn off other buttons off
				else if (correctAnswers [randQuestion] == "4") {//3, objects array index, if answer is fourth alt
					objects [6].SetActive (false);
					objects [1].SetActive (false);
					objects [2].SetActive (false);
				} //turn off other buttons off
				objects = temps;//restore references lost
				nextButton.SetActive (true);//turn on next button because user got the question right
			} 
			else {//user clicks wrong button
				resultObj.GetComponent<TextMesh> ().text = "Incorrect!!! Try again..."; //display text
			}
		}
		if (maxquestions == 10) { //if all questions are answered
			for (int i = 0; i < pemObjs.Length; i++) { //turn on all firework animations
				pemObjs [i].SetActive (true);
			}
			closing.GetComponent<AudioSource> ().Play ();//play closing track
			closing.GetComponent<TextMesh> ().text = "Congratulations!!!\nYou know our solar system!!!"; //display text
			for (int i = 0; i < objects.Length; i++) {//turn off objects with tag finish to clear screen
				restart.SetActive (true); //turn on reset button
				objects [i].SetActive (false);
			}
			maxquestions = 0; //set questions answered to zero
		}


	}
}
