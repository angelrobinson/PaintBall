using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PaintNMove : MonoBehaviour 
{
	public Transform showSplat;
	[SerializeField]private float speed = 50f;

	// Use this for initialization
	void Start () 
	{
		//speed = 50.0f;

	}

	// Update is called once per frame
	void Update () 
	{

	}

	void OnTriggerEnter(Collider other)
	{
		gameObject.GetComponent <Rigidbody>().velocity = Vector3.zero;
		gameObject.GetComponent <Rigidbody>().angularVelocity = Vector3.zero;

		//based on color of paintball, create splatter on the cube and move the cube in a certain direction
		switch (other.tag)
		{
		case "Red":
			Instantiate (GameManager.Instance.red, showSplat.position, Quaternion.identity);
			gameObject.GetComponent <Rigidbody>().AddRelativeForce (Vector3.forward*speed);
			break;
		case "Blue":
			Instantiate (GameManager.Instance.blue, showSplat.position, Quaternion.identity);
			gameObject.GetComponent <Rigidbody>().AddRelativeForce (Vector3.forward*speed);
			break;
		case "Green":
			Instantiate (GameManager.Instance.green, showSplat.position, Quaternion.identity);
			gameObject.GetComponent <Rigidbody>().AddRelativeForce (Vector3.right*speed);
			break;
		case "Yellow":
			Instantiate (GameManager.Instance.yellow, showSplat.position, Quaternion.identity);
			gameObject.GetComponent <Rigidbody>().AddRelativeForce (Vector3.right*speed);
			break;
		case "Purple":
			Instantiate (GameManager.Instance.purple, showSplat.position, Quaternion.identity);
			gameObject.GetComponent <Rigidbody>().AddRelativeForce (Vector3.back*speed);
			break;
		case "Orange":
			Instantiate (GameManager.Instance.orange, showSplat.position, Quaternion.identity);
			gameObject.GetComponent <Rigidbody>().AddRelativeForce (Vector3.left*speed);
			break;
		}


		if (other.CompareTag ("Right"))
		{
			gameObject.transform.position = new Vector3 (250, 2, 260);
		}else if (other.CompareTag ("Left"))
		{
			gameObject.transform.position = new Vector3 (250, 2, 260);
		}else if (other.CompareTag ("Front"))
		{
			gameObject.transform.position = new Vector3 (250, 2, 260);
		}else if (other.CompareTag ("Back"))
		{
			gameObject.transform.position = new Vector3 (250, 2, 260);
		}else if (other.CompareTag ("Finish"))
		{
			SceneManager.LoadScene ("Win");
		} else
		{
			if (other.CompareTag ("Player"))
			{
				gameObject.transform.position = new Vector3 (250, 2, 260);
			}
			//destroy objects that collide with box
			Destroy (other.gameObject);
		}


	}
}
