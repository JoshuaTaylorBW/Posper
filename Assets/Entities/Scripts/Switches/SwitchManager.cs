using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwitchManager : MonoBehaviour {
	
	public bool Destroying = false;				//Does the switch Destroy an object?
	public bool Create = false;					//Does the switch create an object?

	public GameObject[] switches;				//a list of all the switches on the map
	public int amountOfSwitches;				//the amount of switches on the map
	public int SwitchesDone = 0;

	public Vector3 createTransform;				//The position that we spawn the object




	public Transform TheObject;					//the object that is created or destroyed
	private Queue<Transform> objectQueue;		//queue that allows us to spawn the object
	private int created;						//has the object been created or destroyed? 0 = not yet 1 = done







	// Use this for initialization
	void Start () {
		objectQueue = new Queue<Transform>(1);
		if(amountOfSwitches == 0)
		{
		amountOfSwitches = switches.Length;
		}
		created = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(SwitchesDone >= amountOfSwitches)
		{
			if(created == 0)
			{
				if(Create)
				{
					Creator();

				}
				else if(Destroying)
				{
					Destroyer();
				}
			}
		}
	}

	// Every time a switch is turned it adds through this
	public void Switched () {
		SwitchesDone++;
	}

	//Creates object
	void Creator (){
		objectQueue.Enqueue((Transform)Instantiate(
			TheObject, createTransform, Quaternion.identity));
		created++;
	
	}

	//Destroys Object
	void Destroyer(){

	}

}
