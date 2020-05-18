using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintIt : MonoBehaviour 
{
	private Renderer cube;

	// Use this for initialization
	void Start () 
	{
		cube = gameObject.GetComponent <Renderer> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter(Collider other)
	{
		//based on color of paintball, create splatter on the cube and move the cube in a certain direction
		switch (other.tag)
		{
		case "Red":
			cube.material.color = Color.red;
			GameManager.Instance.Score (1);
			break;
		case "Blue":
			cube.material.color = Color.blue;
			GameManager.Instance.Score (2);
			break;
		case "Green":
			cube.material.color = Color.green;
			GameManager.Instance.Score (3);
			break;
		case "Yellow":
			cube.material.color = Color.yellow;
			GameManager.Instance.Score (4);
			break;
		case "Purple":
			cube.material.color = new Color32 (127,0,255,1);
			GameManager.Instance.Score (5);
			break;
		case "Orange":
			cube.material.color = new Color32 (255, 128, 0, 1);
			GameManager.Instance.Score (6);
			break;
		}



	}
}
