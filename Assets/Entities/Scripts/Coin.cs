using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	public int nextLevel;

	// Use this for initialization
	void Start () {
		if(nextLevel == 0)
		{
			nextLevel = (int)Application.loadedLevel + 1;
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			Application.LoadLevel(nextLevel);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
