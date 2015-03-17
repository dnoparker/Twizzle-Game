using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	public GameObject obsPrefab;
	public GameObject cylinder;
	public GameObject cylinder2;
	public bool pinchActive = false;  // this exists to distinguish between using two fingers or one
	public static float score = 0;
	public float highscore = 0;
	public TextMesh scoreText1;
	public TextMesh scoreText2;


	// Use this for initialization
	void Start () {
		score = 0;
		InvokeRepeating("CreateObstacle", 1f, 4f); // Call this method every 4 seconds
	}
	
	// Update is called once per frame
	void Update () {
		highscore = PlayerPrefs.GetFloat ("Highscore");  
		if (highscore < score) {
			PlayerPrefs.SetFloat ("Highscore", score);
			scoreText2.text = score.ToString();
		}
		scoreText1.text = score.ToString ();
		scoreText2.text = highscore.ToString();
		
	}

	public void Rotate(Vector2 Delta) {
		if (pinchActive == false) {
			this.transform.Rotate (Vector3.up * Delta.x / 5);  // rotate up based on fingers movement on the X axis
		}
	}

	public void PinchIn() {
		pinchActive = true;
		cylinder.transform.localPosition += new Vector3 (0.5F*Time.deltaTime,0,0);
		cylinder2.transform.localPosition -= new Vector3 (0.5F*Time.deltaTime,0,0);
	}

	public void PinchOut() {
		pinchActive = true;
		cylinder.transform.localPosition -= new Vector3 (0.5F*Time.deltaTime,0,0);
		cylinder2.transform.localPosition += new Vector3 (0.5F*Time.deltaTime,0,0);
	}

	public void PinchEnd() {
		pinchActive = false;
	}
	
	void CreateObstacle()
	{
		float ObsSelect = Random.Range (1, 6);
		Debug.Log (ObsSelect);
		Instantiate(obsPrefab); // spawn an obstacle 
	}
}
