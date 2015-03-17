using UnityEngine;
using System.Collections;

public class Balls : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col) // if the balls hit eachother
	{
		if(col.gameObject.tag == "Cylinder")
		{
			Application.LoadLevel(Application.loadedLevel);
		}

		if(col.gameObject.name == "Bound")
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
