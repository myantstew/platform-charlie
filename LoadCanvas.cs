using UnityEngine;
using System.Collections;

public class LoadCanvas : MonoBehaviour {
	
	// Use this for initialization
	void Start () 
	{
		if (LifeController.TITLE == false) 
			DontDestroyOnLoad (this.gameObject);
		else Destroy(this);
			ScoreController.SCORE = 0;
	}



	// Update is called once per frame
	void Update () 
	{

	}
}
