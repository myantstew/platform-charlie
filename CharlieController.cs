using UnityEngine;
using System.Collections;

public class CharlieController : MonoBehaviour {

	public float maxSpeed = 3f;
	public float speed;
	private float jumpForce = 250f;

	public static bool hasBag = false;
	public static bool isDead = false;

	public AudioClip jump;
	public AudioClip death;
	public AudioClip getbag;
	public AudioClip score;
	public AudioSource charlieAudioSource;

	bool facingRight = true;

	Animator anim;

	public bool isGrounded = false;


	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public GameObject blood;
	public GameObject explode;
	public GameObject appear;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
		LifeController.TITLE = false;

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat ("speed", Mathf.Abs (move));
		anim.SetBool ("Ground", isGrounded);
		anim.SetBool ("hasBag", hasBag);

		if(!isDead)
		GetComponent<Rigidbody2D>().velocity = new Vector2(move*maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

		if(move>0&&!facingRight)
			Flip ();
		else if(move<0&&facingRight)
			Flip ();
	}

	void Update()
	{
		if (!isDead && isGrounded && Input.GetKeyDown (KeyCode.Space)) 
		{
			anim.SetBool ("Ground", false);
			GetComponent<Rigidbody2D>().AddForce (new Vector2(0,jumpForce));
			charlieAudioSource.clip = jump;
			charlieAudioSource.Play ();
		}
	}
	 void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy" && !isDead)
		Die ();
		else if (other.gameObject.tag == "Dumpster" && hasBag) 
		{
			hasBag = false;
			ScoreController.SCORE += 1;
			charlieAudioSource.clip = score;
			charlieAudioSource.Play ();
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Enemy" && !isDead)
		Die ();
	}

	void Die()
	{	
		isDead = true;
		Vector3 inFront = new Vector3 (transform.position.x, transform.position.y, -2.0f);
		GameObject exploded = Instantiate (explode, inFront, transform.rotation) as GameObject;
		GameObject bloody = Instantiate (blood, inFront, transform.rotation) as GameObject;
		LifeController.LIVES -= 1;
		GetComponent<Renderer>().enabled = false;
		hasBag = false;
		transform.position = new Vector3 (5, 5, 5);
		charlieAudioSource.clip = death;
		charlieAudioSource.Play ();
		StartCoroutine (Respawn ());
	}
	IEnumerator Respawn()
	{
		if (LifeController.LIVES > 0) 
		{
			yield return new WaitForSeconds (2);
			Vector3 spawnPoint = new Vector3 (-1.54f, -2.01f, 0f);
			Vector3 starPoint = new Vector3 (-1.54f, -2.01f, -1f);
			GameObject spawn = Instantiate (appear, starPoint, transform.rotation) as GameObject;
			yield return new WaitForSeconds (1);
			transform.position = spawnPoint;
			transform.rotation = Quaternion.identity;
			GetComponent<Renderer>().enabled = true;
			isDead = false;
		} 
		else
		{
			yield return new WaitForSeconds (3);
			isDead = false;
		}
	}
}
