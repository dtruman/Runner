using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	public GameObject currentPath;
	public GameObject nextPath;
	public GameObject walls;
	GameObject pather;
	public GameObject[] paths;
	GameObject player;
	Run runScript;

	bool isColliding;
	bool alreadyCollided=false;

	// Use this for initialization
	void Start () {
		pather = paths [Random.Range (0,paths.Length)];
		player = GameObject.Find ("Player");
	}

	bool checkCollision()
	{
		return isColliding;
	}

	void OnCollisionEnter()
	{
		if (!alreadyCollided) {
			isColliding = true;
			Instantiate (pather, new Vector3 (nextPath.transform.position.x, nextPath.transform.position.y + 0.5f, nextPath.transform.position.z), new Quaternion ());
			Instantiate (walls, new Vector3(nextPath.transform.position.x, nextPath.transform.position.y-0.5f, nextPath.transform.position.z), new Quaternion());
			alreadyCollided=true;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.name == "Destroyer") {
			Destroy (currentPath);
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (pather.GetComponent<Spawner> ().checkCollision ()) {
						Destroy (currentPath);
				}

		//runScript = player.GetComponent<Run> ();
		//
		//this.rigidbody.velocity= (-runScript.moveDirection);
	}
}
