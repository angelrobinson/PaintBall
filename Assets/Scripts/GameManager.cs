using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
	
	public static GameManager Instance;

	public GameObject mainMenu, blue, green, red, yellow, purple, orange, playerPrefab;
	[SerializeField] private GameObject player, movableBox;
	[SerializeField] private Camera main, pov;
	[SerializeField] private Text livesText, scoreText, timeText, instText, optText;
	[SerializeField] private int lives, score;
	private float time;



	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		} else
		{
			Debug.Log ("There can only be one GameManager");
		}

	}



	// Use this for initialization
	void Start () 
	{
		lives = 3;
		livesText.text = "Lives: " + lives.ToString();
		Score (0);
		time = 300f;
	}

	// Update is called once per frame
	void Update () 
	{
		UpdateTimer ();
		RespawnPlayer ();


		//win if score 1000 points
		if (score == 1000)
		{
			SceneManager.LoadScene ("Win");
		}

		//bring up option/main menu when escape key is pressed
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			ChangeToMain ();
		}

		//shows cursor when option/main menu shown, else hides cursor
		if (mainMenu.GetComponent<Camera> ().isActiveAndEnabled)
		{
			Cursor.visible = true;
		} else 
		{
			Cursor.visible = false;
		}
						

	}



	public void ChangeToPOV()
	{
		pov.enabled = true;
		main.enabled = false;
	}

	public void ChangeToMain()
	{
		main.enabled = true;
		pov.enabled = false;

	}


	public void Score(int addNum)
	{
		score += addNum;
		scoreText.text = "Score: " + score.ToString ();

	}

	public void UpdateTimer()
	{
		//pause timer while options window is open.
		if (mainMenu.GetComponent<Camera> ().isActiveAndEnabled)
		{
			time = time;
		} else
		{
			time -= Time.deltaTime;
			if (time < 0)
			{
				time = 0;
				SceneManager.LoadScene ("Lost");
			} 


			timeText.text = "Timer: " + Mathf.Round (time);

		}
	}

	public void RespawnPlayer()
	{
		//if player collides with the moving box, take away a life and show lost scene if none left
		if (player == null)
		{
			lives -= 1;
			livesText.text = "Lives: " + lives.ToString ();
			player = Instantiate (playerPrefab);
			pov = Camera.main;
			if (lives == 0)
			{
				SceneManager.LoadScene ("Lost");
			}

		}
	}


}
  