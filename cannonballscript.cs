using UnityEngine;
using System.Collections;

public class cannonballscript : MonoBehaviour {

	bool fromLeft;
	public AudioClip fire;
	public AudioSource fireSource;
	// Use this for initialization
	void Start () 
	{
		fireSource.clip = fire;
		fireSource.Play ();
		fromLeft = transform.position.x < 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(fromLeft)
		transform.Translate (0.05f, 0, 0);
		else
		transform.Translate (-0.05f, 0, 0);

		if (transform.position.x > 5)
						Destroy (gameObject);
	}
}
