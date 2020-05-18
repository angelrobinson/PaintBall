using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {

	private float lifetime;

	// Use this for initialization
	void Start () 
	{
		//destroy object after certain amount of time if it wasn't destroyed on collision
		lifetime = 0.5f;
		Destroy (gameObject,lifetime);
	}
	

}
