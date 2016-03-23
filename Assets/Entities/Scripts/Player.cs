using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Vector3 OriginalPosition;		//Where the player starts

	public float moveSpeed;					//How fast the object can move through space
	private float DefaultSpeed = 3;				//If speed is set to 0 in inspector it automatically sets to this.

	public GameObject MainCamera;			//The Main Camera in the scene

	public bool moving = false;				//is the object moving
	public bool stopped = false;			//has the game started? if it has, has the object stopped moving
	public bool GameStarted = false;			//Has this round of the game started yet

	public int ready = 0;

	/*
	 * North = 0
	 * east = 1
	 * south = 2
	 * west = 3
	 */

	public int directionFacing = 0;

	void Start () {

		if(moveSpeed == 0f)
		{
			moveSpeed = DefaultSpeed;
		}

		OriginalPosition = transform.position;
		GameStarted = false;
		if(MainCamera == null)
		{
			MainCamera = GameObject.Find("Main Camera");
		}
	}

	void FixedUpdate()
	{
		if(GameStarted)
		{
			if(!stopped)
			{
				move();
			}
		}
	}

	void Update () {

		transform.eulerAngles = new Vector3(0, 0, MainCamera.transform.eulerAngles.z);

		if(Input.GetButtonDown("Start"))
		{
		
			GameStarted = true;
		}
		if(ready == 0)
		{
		if(Input.GetButtonDown("Right"))
		{
			// TurnRight();
			// ready++;

		}
		if(Input.GetButtonDown("Left"))
		{
			// TurnLeft();
			// ready++;
			
		}
		}
	}

	public void TurnLeft ()
	{
		stop ();

		if(ready == 0){

			if(directionFacing < 3)
			{
				directionFacing++;
			}else{
				directionFacing = 0;
			}
			ready++;
		}
	}
	public void TurnRight()
	{


		if(ready == 0){
			if(!stopped)
				{
				if(directionFacing > 0)
				{
					directionFacing--;
					stop ();
				}else{
					directionFacing = 3;
					stop ();
				}
				ready++;
			}
		}
	}

	public void stop()
	{
		stopped = true;
	}
	public void go()
	{
		stopped = false;
	}

	public void fixDirection(float rotation){
		Debug.Log("Gone");
		if(rotation >= 89 && rotation <= 91)
		{
			directionFacing = 1;
		}
		else if(rotation >= 179 && rotation <= 181)
		{
			directionFacing = 2;
		}
		else if(rotation >= 269 && rotation <= 271)
		{
			directionFacing = 3;
		}
		else if(rotation == 0)
		{
			directionFacing = 0;
		}
	}

	void move()
	{
		if(directionFacing == 0)
		{
			transform.position = new Vector3(transform.position.x,
			                                 transform.position.y + (moveSpeed * Time.deltaTime),
			                                 transform.position.z);
		}
		else if(directionFacing == 1)
		{

			transform.position = new Vector3(transform.position.x - (moveSpeed * Time.deltaTime),
			                                 transform.position.y,
			                                 transform.position.z);
		}
		else if(directionFacing == 2)
		{
			transform.position = new Vector3(transform.position.x,
			                                 transform.position.y - (moveSpeed * Time.deltaTime),
			                                 transform.position.z);
		}
		else if(directionFacing == 3)
		{
			transform.position = new Vector3(transform.position.x + (moveSpeed * Time.deltaTime),
			                                 transform.position.y,
			                                 transform.position.z);
		}
	}

}
