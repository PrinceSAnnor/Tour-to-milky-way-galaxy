using System.Collections; //access namespace
using System.Collections.Generic; //access namespace
using UnityEngine; //access namespace
using UnityEngine.SceneManagement; //access namespace

public class LoadOnCLick : MonoBehaviour { //class definition

	public void LoadScene() //load quiz scene
	{
		GetComponent<Animator>().speed = 0; //pause animation before loadscene
		SceneManager.LoadScene ("Quiz"); //load quiz scene
	}

}
