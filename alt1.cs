using System.Collections; //access namespace
using System.Collections.Generic; //access namespace
using UnityEngine;//access namespace
using UnityEngine.UI; //access namespace

public class alt1 : MonoBehaviour { //class definition
	public Text text1;//reference to alt 1's button text
	//List of alternatives for choice one
	List<string> alte1 = new List<string>() {"Mercury", "9", "Sun", "Sun", "Mercury", "Pluto", "Earth", "Sun", "Saturn", "Jupiter", "Sun", "Mars", "24 hours 56 minutes 4 seconds", "Sun", "Jupiter", "Uranus", "Neptune", "Rocket", "Jupiter"};
	//runs once per scene
	void Start()
	{
		text1 = text1.GetComponent<Text> (); //initialize button's text
	}
	/*
     *General selection system code below from https://www.youtube.com/watch?v=Nu5m6tOVInw
     */
	void Update()
	{
		if (question.randQuestion > -1) { //if question is loaded
			text1.text = alte1 [question.randQuestion];//display alternative
		}
	}

	public void alternative1() //onclick function called
	{
		question.selectedAnswer = "1";//if button is selected, register button to question class
		question.choiceSelected = "y"; //register selection to question class
	}
}
