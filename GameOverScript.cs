using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	public AudioClip gameover;
	public AudioSource gameSource;
	float xMove =0f;
	float yMove = 0.1f;
	float zMove =0f;

	// Use this for initialization
	void Start ()
	{
		gameSource.clip = gameover;
		gameSource.Play ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (transform.position.y < 0)
		transform.Translate (xMove, yMove, zMove);
		else
		StartCoroutine (Restart ());
	}
	IEnumerator Restart()
	{
		yield return new WaitForSeconds (3);
		Application.LoadLevel ("titleScene");
		}
}
