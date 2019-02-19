using System.Collections; //access namespace
using System.Collections.Generic;//access namespace
using UnityEngine; //access namespace
using UnityEngine.UI; //access namespace

public class alt2 : MonoBehaviour { //class definition
	//List of alternatives for choice two
	List<string> alte2 = new List<string>() {"Uranus", "10", "Mars", "Earth", "Venus", "Jupiter", "Neptune", "Mercury", "Uranus", "Saturn", "Saturn", "Venus", "1 year", "Jupiter", "Mars", "Pluto", "Uranus", "Spaceship", "Neptune"};
	public Text text2; //reference to alt 2's text 
	void Start()//runs once per scene
	{
		text2 = text2.GetComponent<Text> (); //initialize button's text
	}
	/*
     *General selection system code below from https://www.youtube.com/watch?v=Nu5m6tOVInw
     */
	void Update() 
	{
		if (question.randQuestion > -1) { //if question is loaded
			text2.text = alte2 [question.randQuestion]; //display alternative
		}
	}
	public void alternative2() //onclick function called
	{
		question.selectedAnswer = "2"; //if button is selected, register button to question class
		question.choiceSelected = "y"; //register selection to question class

	}
}
