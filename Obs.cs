using UnityEngine;
using System.Collections;

public class Obs : MonoBehaviour {
	public float posY;

	// Use this for initialization
	void Start () {
		float scaleRangeX = Random.Range(0.5F,3F);
		float scaleRangeY = Random.Range(0.5F,1F);
		transform.localScale = new Vector3(scaleRangeX, scaleRangeY, 1);
		float posX = Random.Range (-2.3F, 2.3F);
		posY = transform.position.y;
		float posZ = transform.position.z;
		transform.position = new Vector3 (posX,posY,posZ);
		
	}
	
	// Update is called once per frame
	void Update () {
		posY = transform.position.y;
		float speed = 1.5F * Time.deltaTime;
		transform.Translate(Vector3.down * speed);

		if (posY < -5) {
			Main.score = Main.score +1;
			Destroy(gameObject);
			speed = speed + 0.1F;
		}
	}


	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Cylinder")
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
