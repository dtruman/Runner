using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter(Collider col)
	{
		Debug.Log (col.gameObject.name);
		Destroy (this.gameObject);
	}
	
	// Update is called once per frame
	void Update ()
	{

	}
}
