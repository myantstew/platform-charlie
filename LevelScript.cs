using UnityEngine;
using System.Collections;

public class LevelScript : MonoBehaviour {

	public GameObject gameOver;
	bool over = false;
	Vector3 bottom;
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (ScoreController.SCORE >= 5) 
		{
			Application.LoadLevel (Application.loadedLevel + 1);
			ScoreController.SCORE = 0;
		}
		if (LifeController.LIVES <= 0 && over == false) 
		{
			over = true;
			LifeController.TITLE = true;
			bottom = new Vector3 (0, -3, -1);
			Instantiate (gameOver, bottom, Quaternion.identity);
		}
		if (Input.GetKeyDown (KeyCode.Escape))
			Application.Quit ();
	}

}