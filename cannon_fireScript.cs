using UnityEngine;
using System.Collections;

public class cannon_fireScript : MonoBehaviour {

	bool canFire = true;
	public GameObject cannonball;
	public GameObject smoke;

	// Update is called once per frame
	void Update () 
	{ 
		if (canFire == true && CharlieController.isDead == false) 
		{
			Fire ();
			StartCoroutine(FirePause());
		}

	}
	void Fire()
	{
		Vector3 leftlocation = new Vector3 (transform.position.x + 0.3f, transform.position.y+0.1f, -2.0f);
		Vector3 rightlocation = new Vector3 (transform.position.x - 0.3f, transform.position.y+0.1f, -2.0f);
		if (this.gameObject.tag == "cannonleft") 
		{
			GameObject shot = Instantiate (cannonball, leftlocation, transform.rotation) as GameObject;
			GameObject gunsmoke = Instantiate (smoke, leftlocation, transform.rotation) as GameObject;
		}
		else
		{
			GameObject shot = Instantiate (cannonball, rightlocation, transform.rotation) as GameObject;
			GameObject gunsmoke = Instantiate (smoke, rightlocation, transform.rotation) as GameObject;
		}
		canFire = false;
	}

	IEnumerator FirePause()
	{
		yield return new WaitForSeconds (3);
		canFire = true;
	}
}
