using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	private Rigidbody2D body;
	public bool isJumping;
	public bool isRolling;
	public bool isTwerking;

	private Animator animator;
	public GameController gameController;
    // collider flags
    public bool collideWithTree;
    public bool collideWithCat;
    public bool collideWithLeftCar;
    public bool collideWithCrack;
    public bool collideWithRightCar;
    // Use this for initialization
    void Start ()
	{
		
		this.body = GetComponent<Rigidbody2D> ();
		this.animator = GetComponent<Animator>();
		this.gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}
	bool Grounded;
	// Update is called once per frame
	void Update ()
	{
		if (this.isJumping) {//we were jumping
			bool tempIsJumping = this.checkIfJumping ();//are we still jumping?
			if (!tempIsJumping) {//if we're not still jumping
				this.isJumping = false;
				this.animator.ResetTrigger("isJumping");
			}
		}
		if (Input.GetKeyDown ("w")) {
			print ("w was pressed");
			if (this.Grounded) {
//				transform.Translate (Vector2.up * 2.75f);
				this.body.AddForce (Vector2.up * 275f);
				this.isJumping = true;
				this.isTwerking = false;
				if (this.isTwerking) {
					this.isTwerking = false;
					this.animator.ResetTrigger ("isTwerking");
				}
				this.animator.SetTrigger ("isJumping");
			} else {
				print ("velocity was " + this.body.velocity.y);
			}
            if (collideWithCrack)
            {
                gameController.SendMessage("AddScore", 3);
            }
            else
            {
                gameController.SendMessage("AddScore", -1);
            }
        } else if (Input.GetKeyDown ("a")) {
			print ("a was pressed");
            if (collideWithLeftCar)
            {
                gameController.SendMessage("AddScore", 3);
            }
            else
            {
                gameController.SendMessage("AddScore", -1);
            }
        } else if (Input.GetKeyDown ("s")) {

			//we roll if
			//not rolling AND not jumping
			if (this.Grounded && !this.isJumping) {
				if (this.isTwerking) {
					this.isTwerking = false;
					this.animator.ResetTrigger ("isTwerking");
				}
				this.animator.SetTrigger ("isRolling");
			}
            //we stop rolling if
            //animation ends - how to know this
            //did jump

            // check collision
            if (collideWithCat)
            {
                gameController.SendMessage("AddScore", 3);
            }
            else
            {
                gameController.SendMessage("AddScore", -1);
            }
        } else if (Input.GetKeyDown ("d")) {
			print ("d was pressed");
            if (collideWithRightCar)
            {
                gameController.SendMessage("AddScore", 3);
            }
            else
            {
                gameController.SendMessage("AddScore", -1);
            }

			if (!this.isTwerking && !this.isJumping && !this.isRolling) {
				this.isTwerking = true;
				this.animator.SetTrigger ("isTwerking");
			}
        }
	}

	public bool checkIfJumping ()
	{

//		RaycastHit hit;
//		Ray ray;
////ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//		Debug.DrawRay(transform.position, -transform.up * 50, Color.blue);
//		if (Physics.Raycast (transform.position, Vector3.down, out hit)) {
//			Debug.Log (hit.collider.gameObject.name);
//		}
		float absVel = abs(this.body.velocity.y);
		if (
//			this.body.velocity.y != 0 &&
			(int)this.body.velocity.y != 0) {
//			||(this.body.velocity.y < 0 && this.body.velocity.y < -0.0001)) {
			print ("jump velocity was " + (int)this.body.velocity.y);
			return true;
		} else {
			print ("velocity was " + absVel);

			print ("velocity was " + (int)this.body.velocity.y);
		}
		return false;
	}

	public float abs(float value) {

		float retVal = (value * value)/ value;

		return retVal;
	
	}

    /// <summary>
    /// Collision checks
    /// </summary>
    /// <param name="collider"></param>
    void OnCollisionStay2D(Collision2D collider)
	{
		CheckIfGrounded ();
	}

	void OnCollisionExit2D(Collision2D collider)
	{
		Grounded = false;
    }

    private void CheckIfGrounded()
	{
		RaycastHit2D[] hits;

		//We raycast down 1 pixel from this position to check for a collider
		Vector2 positionToCheck = transform.position;
		hits = Physics2D.RaycastAll (positionToCheck, new Vector2 (0, -1), 0.01f);

		//if a collider was hit, we are grounded
		if (hits.Length > 0) {
			Grounded = true;
		}
	}

    /// <summary>
    /// 
    /// </summary>
	public void didFinishRoll() {
		this.isRolling = false;
		this.animator.ResetTrigger ("isRolling");
	}

    /// <summary>
    /// Message receivers
    /// </summary>
    /// <param name="value"></param>
    void SetCollideWithCat(bool value)
    {
        collideWithCat = value;
    }

    void SetCollideWithCrack(bool value)
    {
        collideWithCrack = value;
    }

    void SetCollideWithLeftCar(bool value)
    {
        collideWithLeftCar = value;
    }

    void SetCollideWithRightCar(bool value)
    {
        collideWithRightCar = value;
    }

    void SetCollideWithTree(bool value)
    {
        collideWithTree = value;
    }

}
