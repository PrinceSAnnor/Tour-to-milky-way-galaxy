using System.Collections; //access namespace
using System.Collections.Generic; //access namespace
using UnityEngine; //access namespace
using UnityEngine.SceneManagement; //access namespace

public class LoadOnClick1 : MonoBehaviour { //class definition

	// Use this for initialization
	public void LoadScene() //load first scene
	{
		for (int i = 0; i < question.objects.Length; i++) { //kill all objects with tag finish
			question.objects [i].SetActive (false);
		} //kill all other objects except image object
		GameObject.FindGameObjectWithTag ("closing").SetActive(false);
		GameObject.FindGameObjectWithTag ("restart").SetActive(false);
		GameObject.FindGameObjectWithTag ("quit").SetActive(false);
		question.closing_image.SetActive (true);
		SceneManager.LoadScene ("FirstScene"); //load first scene
	}
}
