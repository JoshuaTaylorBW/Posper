using UnityEngine;
using System.Collections;

public class HerMovement : MonoBehaviour {

	public GameObject Player;
	public bool waitForPlayer;				//Do we wait to move for the player to start to move or do we go right away?
	public float moveSpeed;

	public int directionFacing = 0;
	/* 0 = north
	 * 1 = east
	 * 2 = south
	 * 3 = west
	 */

	// Use this for initialization
	void Start () {
		if(Player == null)
		{
			Player = GameObject.Find("Character"); 
		}
		if(moveSpeed == 0)
		{
		moveSpeed = Player.GetComponent<Player>().moveSpeed;
		}
	}
	
	// Update is called once per frame

	void FixedUpdate() {
		if(waitForPlayer && Player.GetComponent<Player>().GameStarted)
		{
				move();
		}
		else if(!waitForPlayer)
		{
			move();
		}
	}

	void Update () {
		
	}

	public void TurnLeft(){
		if(directionFacing < 3)
		{
			directionFacing++;
		}else{
			directionFacing = 0;
		}
	}

	public void TurnRight() {
		if(directionFacing > 0)
		{
			directionFacing--;
		}else{
			directionFacing = 3;
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
