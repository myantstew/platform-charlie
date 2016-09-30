using UnityEngine;
using System.Collections;

public class bagController : MonoBehaviour {

	public GameObject appear;
	bool bagSpawn;
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (CharlieController.hasBag == false && !GetComponent<Renderer>().enabled && bagSpawn == false) 
		{
			bagSpawn = true;
			StartCoroutine (Spawn ());
		}
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (GetComponent<Renderer>().enabled && other.gameObject.tag == "Player") 
		{
			CharlieController.hasBag = true;
			GetComponent<Renderer>().enabled = false;
			transform.position = new Vector3 (5, 5, 5);
		}

	}
	IEnumerator Spawn()
	{
		transform.position = new Vector3 (-1.427f, 0.85f, 0f);
		transform.rotation = Quaternion.identity;
		Vector3 starPoint = new Vector3 (-1.427f, 0.85f, -1f);
		GameObject spawn = Instantiate (appear, starPoint, transform.rotation) as GameObject;
		yield return new WaitForSeconds (1);
		GetComponent<Renderer>().enabled = true;
		bagSpawn = false;
	}
}
