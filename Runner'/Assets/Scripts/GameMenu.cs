using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour {
	public GameObject start;
	public GameObject quit;

	public GUIText yourScore;
	public GUIText highScore;
	// Use this for initialization
	void Start () {
		if (yourScore) {
			int ys=PlayerPrefs.GetInt("LastScore");
			yourScore.text=yourScore.text+ " " + ys.ToString();
		}
		if (highScore) {
			int hs=PlayerPrefs.GetInt("HighScore");
			highScore.text=highScore.text+ " " + hs.ToString();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit ();
				}

		if(Input.GetMouseButtonDown(0))
		{
			Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit=new RaycastHit();

			if(Physics.Raycast(ray,out hit, 200))
			{
				GameObject hitObject=hit.collider.gameObject.transform.parent.gameObject;

				if(hitObject.name=="Quit")
				{
					Application.Quit();
				}
				else if(hitObject.name=="Start")
				{
					Application.LoadLevel (1);
				}
				else if(hitObject.name=="Menu")
				{
					Application.LoadLevel (0);
				}
			}
		}

		if (Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Home))
		{
			Debug.Log ("QUITTER");
			Application.Quit();
		}
	}
}
