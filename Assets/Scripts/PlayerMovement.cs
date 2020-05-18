using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour 
{
	public float speed, gravity, rotationSpeed;
	private CharacterController controller;
	//private Vector3 lookUP, lookDown;



	// Use this for initialization
	void Start () 
	{
		speed = rotationSpeed = 5.0f;
		gravity = 20.0f;
		//lookUP = Vector3.up * 100;
		//lookDown = Vector3.down * 100;
		controller = GetComponent <CharacterController> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		//set the movement of character to use arrow keys or the WASD keys
		Vector3 move = new Vector3(Input.GetAxis ("Horizontal"),-gravity*Time.deltaTime,Input.GetAxis ("Vertical"));
		Vector3 moving = transform.TransformDirection (move);
		moving *= speed;

		//run when either shift key are pressed down
		if (Input.GetButtonDown ("Run"))
		{
			speed += 10.0f;
		} else if (Input.GetButtonUp ("Run"))
		{
			speed = 5.0f;
		}


		//move the character
		controller.Move (moving * Time.deltaTime);

	
	}




}
