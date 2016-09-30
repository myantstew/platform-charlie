using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeController : MonoBehaviour {

	public static int LIVES;
	public static bool TITLE = false;
	Text text;

	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad (this.gameObject);
			text = GetComponent<Text> ();
		LIVES = 5;
	}
	
	// Update is called once per frame
	void Update () 
	{
		text.text = "Lives: " + LIVES;
	}
}
