using System.Collections; //access namespace
using System.Collections.Generic; //access namespace
using UnityEngine;//access namespace

public class canvasappear : MonoBehaviour { //class definition
	private GameObject canvas1; //canvas reference
	private GameObject temp; //canvas reference
	// Use this for initialization
	void Start () {
		canvas1 = GameObject.FindGameObjectWithTag("canvas1"); //get reference to canvas object with canvas1 tag
		temp = canvas1; //temp store the reference
		canvas1.SetActive (false); //kill canvas, reference lost
		canvas1 = temp; //get reference back from temp

	}
	
	// Update is called once per frame
	void appear() // function runs from animation event
	{
		canvas1.SetActive (true); // make the canvas reappear
	}
}
