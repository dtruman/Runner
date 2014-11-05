using UnityEngine;
using System.Collections;

public class Run : MonoBehaviour {

	public Vector3 moveDirection=new Vector3 (0, 0, 1);
	public AudioClip collide;

	GameObject crasher;
	public GUIText score;
	float scoreNum;

	bool lost;
	float lastMove;
	float downTime;
	float doubleTapTime;
	float timeInAir=3;
	float maxVelocity=50;

	float endTimer=0;

	float gyroThreshHold=0.075f;
	// Use this for initialization
	void Start () {
		lost = false;
		crasher = GameObject.Find ("Crash");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!lost)
		{
			if (moveDirection.z > 0)
			{
					this.rigidbody.transform.position = new Vector3 ((0.2f * Input.acceleration.x) + this.rigidbody.position.x, this.rigidbody.position.y, this.rigidbody.position.z);
					this.rigidbody.velocity = new Vector3 (this.rigidbody.velocity.x, this.rigidbody.velocity.y, moveDirection.z);
			
				if(Input.GetKeyDown (KeyCode.D))
				{
					this.rigidbody.transform.position = new Vector3 (this.rigidbody.position.x + 0.5f, this.rigidbody.position.y, this.rigidbody.position.z);
				}
			
			 	if(Input.GetKeyDown (KeyCode.A))
				{
					this.rigidbody.transform.position = new Vector3 (this.rigidbody.position.x - 0.5f, this.rigidbody.position.y, this.rigidbody.position.z);
				}
			}
			
			if(this.rigidbody.position.y < 0.5f)
			{
				this.rigidbody.transform.position = new Vector3 (this.rigidbody.position.x, 0.5f, this.rigidbody.position.z);
			}
			
			DoubleTapLogic ();
			
			if(lastMove == this.rigidbody.position.z && downTime > 2)
			{
				crasher.particleSystem.Play ();
				audio.PlayOneShot(collide);
			
				lost = true;
			}
			else if (lastMove == this.rigidbody.position.z)
			{
				downTime++;
			}
			else
			{
				downTime = 0;
			}

			scoreNum+=Time.deltaTime;
			scoreNum=Mathf.Round(scoreNum*100f)/100f;

			lastMove = this.rigidbody.position.z;

			score.text="Score: " + scoreNum;
		}
		else if (lost)
		{
			endTimer+=Time.deltaTime;

			if(endTimer>2)
			{
				if(PlayerPrefs.GetInt("HighScore")<scoreNum)
				{
					PlayerPrefs.SetInt("HighScore", (int)scoreNum);
				}
				PlayerPrefs.SetInt ("LastScore", (int)scoreNum);

				Application.LoadLevel(2);
			}
		}

		if (scoreNum >= 100*moveDirection.z)
		{
			moveDirection.z+=1;
		}

		if (Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Home))
		{
			Debug.Log ("QUITTER");
			Application.LoadLevel(0);
		}
	}

	void DoubleTapLogic()
	{
		bool doubleTap = false;

		if (Input.GetMouseButtonDown(0))
		{
			if(Time.time<doubleTapTime+.3f && this.rigidbody.position.y==0.5f)
			{
				doubleTap=true;
			}
			doubleTapTime=Time.time;
		}

		if (doubleTap)
		{
			rigidbody.AddForce(0, 300,0);
		}
	}
}
