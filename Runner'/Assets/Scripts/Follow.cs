using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

	public GameObject following;
	public Vector3 myPos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = following.rigidbody.position + myPos;
	}
}
