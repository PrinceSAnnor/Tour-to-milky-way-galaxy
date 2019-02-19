using System.Collections; //access namespace
using System.Collections.Generic; //access namespace
using UnityEngine; //access namespace
using UnityEngine.UI; //access namespace

public class alt3 : MonoBehaviour { //class definition
	//List of alternatives for choice three
	List<string> alte3 = new List<string>() {"Mars", "8", "Jupiter", "Jupiter", "Earth", "Earth", "Saturn", "Venus", "Earth", "Uranus", "Uranus", "Uranus", "365 days", "Mars", "Uranus", "Jupiter", "Saturn", "Transformers", "Saturn"};
	public Text text3; //reference to alt 2's text

	void Start() //runs once
	{
		text3 = text3.GetComponent<Text> (); //initialize button's text
	}
	/*
     *General selection system code below from https://www.youtube.com/watch?v=Nu5m6tOVInw
     */
	void Update()
	{
		if (question.randQuestion > -1) { //if question is loaded
			text3.text = alte3 [question.randQuestion]; //display alternative
		}
	}

	public void alternative3() //onclick function called
	{
		question.selectedAnswer = "3"; //if button is selected, register button to question class
		question.choiceSelected = "y"; //register selection to question class

	}
}
