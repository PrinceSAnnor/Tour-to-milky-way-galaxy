using System.Collections; //access namespace
using System.Collections.Generic; //access namespace
using UnityEngine;//access namespace
using UnityEngine.UI; //access namespace

public class next : MonoBehaviour { //class definition
	public Button next_button; //reference to next button
	private GameObject tempButton; //temp button for storing references
	public static GameObject pemNext; //reference to next button's text
	public Transform resultObj; //reference to result text object
	private GameObject[] tempObjslevel; //temp reference to question's fireworks object

	// Use this for initialization
	void Start () {
		//initialize references above
		next_button = next_button.GetComponent<Button> ();  //initialize next button reference
		pemNext = GameObject.FindGameObjectWithTag ("next");//initialize next button's text
		tempButton = pemNext; //store reference into temp
		tempButton.SetActive (false); //kill button, reference lost
		tempButton = pemNext; //get reference back from temp
	}
	// Update is called once per frame
	public void nextQuestion() //onclick function
	{
		tempObjslevel = question.pemObjslevel; //get questions permanent animation object
		for (int i = 0; i < tempObjslevel.Length; i++) { //turn off all level animation objects with tempObjslevel variable
			tempObjslevel [i].SetActive (false);
		}
		question.audio1.Stop (); //stop audio after next button is pressed
		question.randQuestion = -1; //set randomQuestion back to -1 to change question
		tempButton.SetActive (false); //turn next button off, reference lost
		tempButton = pemNext; //get reference back to next button from pemNext
		resultObj.GetComponent<TextMesh> ().text = "";//set result text empty
		question.maxquestions++;//increment next button
		//turn on alternative buttons
		question.objects [6].SetActive (true);
		question.objects [1].SetActive (true);
		question.objects [2].SetActive (true);
		question.objects [3].SetActive (true);
	}
}
