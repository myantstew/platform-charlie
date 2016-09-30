using UnityEngine;
using System.Collections;

public class KelliAIController : MonoBehaviour {
	
	public float speed =1;
	private float jumpForce = 250f;
	bool facingRight = true;
	
	bool isGrounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	Animator anim;

	public GameObject target;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{	

		anim.SetFloat ("speed", Mathf.Abs (speed));
		anim.SetBool ("Ground", isGrounded);

		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

		if (CharlieController.isDead == false) 
		{
			if (target.transform.position.x + 0.01 > transform.position.x)
			speed = 1;
			else if (target.transform.position.x - 0.01 < transform.position.x)
			speed = -1;
		}
		else if (transform.position.x < 0) speed = 1;
		else speed = 0;

		GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
				
		if(speed>0&&!facingRight)
			Flip ();
		else if(speed<0&&facingRight)
			Flip ();
	}
	
	void Update()
	{
		if (isGrounded && Input.GetKeyDown (KeyCode.Space) && target.transform.position.y > transform.position.y) 
		{
			GetComponent<Rigidbody2D>().AddForce (new Vector2(0,jumpForce));
		}
	}
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
