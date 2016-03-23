using UnityEngine;
using System.Collections;

public class HerTurnPoints : MonoBehaviour {

	public bool LeftTurn, RightTurn;
	public GameObject Her;

	// Use this for initialization
	void Start () {
		if(Her == null)
		{
			Her = GameObject.Find("Her");
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.tag == "Her")
		{
			if(LeftTurn)
			{
				Her.GetComponent<HerMovement>().TurnLeft();
				Her.transform.Rotate(new Vector3(0, 0, 90));
			}
			if(RightTurn)
			{
				Her.GetComponent<HerMovement>().TurnRight();
				Her.transform.Rotate(new Vector3(0, 0, -90));
			}
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
