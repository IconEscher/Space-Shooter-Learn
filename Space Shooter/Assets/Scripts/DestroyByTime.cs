using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	public float lifetime;

	void start ()
	{
		Destroy (gameObject, lifetime);
	}

}
