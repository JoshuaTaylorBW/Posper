using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	public int Level;
	public Transform StopPoint;
	public GameObject TutorialTouch1;

	// Use this for initialization
	void Start () {
		TutorialTouch1.renderer.enabled = false;
	}

	void OnCollisionEnter2D (Collision2D col){
		if(col.gameObject.name == "StopSpot")
		{
			if(transform.eulerAngles.z == 0)
			{
			GetComponent<Player>().stop();

			}

			TutorialTouch1.renderer.enabled = true;

		}
	}

	// Update is called once per frame
	void Update () {
		if(Level == 1)
		{
			if(transform.position.y > 2.8 && (transform.eulerAngles.z > 269 && transform.eulerAngles.z < 271))
			{
				TutorialTouch1.renderer.enabled = false;
				GetComponent<Player>().go();
			}
		}
		else if(Level == 2)
		{
			if(transform.position.y > 2.8 && (transform.eulerAngles.z > 89 && transform.eulerAngles.z < 91))
			{
				TutorialTouch1.renderer.enabled = false;
				GetComponent<Player>().go();
			}
		}
	}
}
