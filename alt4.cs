using System.Collections; //access namespace
using System.Collections.Generic; //access namespace
using UnityEngine; //access namespace
using UnityEngine.UI; //access namespace

public class alt4 : MonoBehaviour { //class definition
	//List of alternatives for choice three
	List<string> alte4 = new List<string>() {"Saturn", "12", "Mercury", "Moon", "Mars", "Neptune", "Mars", "Earth", "Mars", "Neptune", "Earth", "Pluto", "366 days", "Venus", "Earth", "Sun", "Mercury", "Airplane", "Venus"};
	public Text text4; //reference to alt 4's text
	void Start() //runs once
	{
		text4 = text4.GetComponent<Text> (); //initialize button's text
	}
	/*
     *General selection system code below from https://www.youtube.com/watch?v=Nu5m6tOVInw
     */
	void Update()
	{
		if (question.randQuestion > -1) { //if question is loaded
			text4.text = alte4 [question.randQuestion]; //display alternative
		}
	}
	public void alternative4() //onclick function called
	{
		question.selectedAnswer = "4"; //if button is selected, register button to question class
		question.choiceSelected = "y"; //register selection to question class

	}
}
