using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour {

	public static int SCORE;
	Text text;
	
	// Use this for initialization
	void Awake () 
	{
		text = GetComponent<Text> ();
		SCORE = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		text.text = "COMPLETE: " + SCORE +"/5";
	}
}
