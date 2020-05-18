using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LostScript : MonoBehaviour 
{
	private Button restart;
	private Text Text;

	// Use this for initialization
	void Start () 
	{
		restart = GetComponent <Button>();
		Text = GetComponent<Text>();

	}
	

	public void restartGame()
	{
		SceneManager.LoadScene ("Main");
	}

	public void Exit()
	{
		Application.Quit ();
	}
}
