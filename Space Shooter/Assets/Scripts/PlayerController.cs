using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn; //shotSpawn.transform.position
	public float fireRate;
	public AudioSource audio;

	private float nextFire;


	void Update ()
	{ 
		if (Input.GetButton("Fire1") && Time.time > nextFire) // Firing shot
		{
			nextFire = Time.time + fireRate;
			// gameObject clone = 
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation); // as GameObject
			audio = GetComponent<AudioSource>();
			audio.Play();
	}
	}

	void FixedUpdate ()
	{	//Movements
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody> ().velocity = movement * speed;

		GetComponent<Rigidbody> ().position = new Vector3 
			(
				Mathf.Clamp (GetComponent<Rigidbody> ().position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp (GetComponent<Rigidbody> ().position.z, boundary.zMin, boundary.zMax)
			);

	
	}

}
