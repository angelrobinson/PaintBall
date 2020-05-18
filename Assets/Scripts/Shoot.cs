using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour 
{
	public GameObject pbPrefab, pbSpawn;

	private GameObject paintball;
	private float throwForce;
	private int ranColor;

	// Use this for initialization
	void Start () 
	{
		throwForce = 2000f;

	}
	
	// Update is called once per frame
	void Update () 
	{
		ShootPaintBall ();
	}

	private void setColor(int num)
	{
		//set color and tag of the paintball
		switch (num)
		{
		case 1:
			paintball.GetComponent <Renderer> ().material.color = Color.red;
			paintball.tag = "Red";
			break;
		case 2:
			paintball.GetComponent <Renderer>().material.color = Color.yellow;
			paintball.tag = "Yellow";
			break;
		case 3:
			paintball.GetComponent <Renderer>().material.color = Color.green;
			paintball.tag = "Green";
			break;
		case 4:
			paintball.GetComponent <Renderer>().material.color = new Color32 (128,0,128,1);
			paintball.tag = "Purple";
			break;
		case 5:
			paintball.GetComponent <Renderer>().material.color = new Color32 (255,165,0,1);
			paintball.tag = "Orange";
			break;
		default:
			paintball.GetComponent <Renderer>().material.color = Color.blue;
			paintball.tag = "Blue";
			break;
		}
	}

	public void ShootPaintBall()
	{
		//choose a random number to determine which color to set paintball
		ranColor = Random.Range (0, 6);

		//fire the paintball
		if (Input.GetButtonDown ("Fire1"))
		{
			paintball = Instantiate (pbPrefab, pbSpawn.transform.position+transform.forward,Quaternion.identity ) as GameObject;
			setColor (ranColor);
			paintball.GetComponent <Rigidbody>().AddForce (throwForce * transform.forward);
		}
	}
}
