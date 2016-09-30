using UnityEngine;
using System.Collections;

public class endController : MonoBehaviour {
	
	public AudioClip intro;
	public AudioSource introSource;
	
	// Use this for initialization
	void Start () 
	{
		introSource.clip = intro;
		introSource.Play ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyUp (KeyCode.Return))
			Application.LoadLevel ("titleScene");
	}
}
