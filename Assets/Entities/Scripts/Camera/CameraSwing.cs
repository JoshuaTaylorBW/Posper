using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System.Threading;

public class CameraSwing: MonoBehaviour {
	
	public Stopwatch turnWatch;
	public GameObject player;
	
	public Vector3 lastRotation;				//what the rotation was before rotation
	public float rotateSpeed = 2;				//how fast the camera rotates
	public float turnWatcher;					//watches length of pause after turn
	private float originalTurnPause;			//what the turn pause was initially
	public float turnPause;						//how long we pause before moving the character again
	private float swing;						//strength of the swing of the camera
	public bool toRight = false;				//are we moving right?
	public bool toLeft = false;					//are we moving left?
	public bool DoneTurning = true;				//are we done turning?
	public bool angle = false;
	// Use this for initialization
	void Start () {
		turnWatcher = 0f;
		turnWatch = new Stopwatch();
		player = GameObject.Find("Character");
		lastRotation = transform.eulerAngles;
		
		originalTurnPause = turnPause;
		
	}
	
	
	
	// Update is called once per frame
	void Update () {
		
		angle = cardinalAngles();

		//rotate 90 degrees to right
		turnRight();
		//rotate 90 degrees to left
		turnLeft();

		turnWatcher = turnWatch.ElapsedMilliseconds; //sets turnwatcher to be the milliseconds of the stopwatch
		
		
		
		if(turnWatcher > turnPause)
		{
			player.GetComponent<Player>().ready = 0;
			player.GetComponent<Player>().go();
			
			//this.GetComponent<ScreenShake>().TeensyShake();
			this.GetComponent<ScreenShake>().sleep();
			turnWatch.Stop();
			turnWatch.Reset();
		}
		else
		{
			if(player.GetComponent<Player>().ready != 0)
			{
				//this.GetComponent<ScreenShake>().TeensyShake();
			}
		}
	}
	
	void turnLeft()
	{
		if(Input.GetButtonDown("Left")){
			if(cardinalAngles())
			{
				toLeft = true;
			}
		}
		if(toLeft)
		{
			rotateSpeed = 5;
			turnPause = originalTurnPause - 100;
			if(!toRight && 
			   Mathf.RoundToInt(transform.eulerAngles.z) != Mathf.RoundToInt(lastRotation.z)+90)
			{
				
				this.GetComponent<ScreenShake>().TeensyShake();
				swing = Mathf.Abs(Mathf.RoundToInt(lastRotation.z)+90-Mathf.RoundToInt(transform.eulerAngles.z));
				if(this.GetComponent<CameraFollow>().VerticalFollowY || this.GetComponent<CameraFollow>().HorizontFollowY)
				{
					transform.RotateAround(player.transform.position, transform.forward, rotateSpeed * swing *Time.deltaTime);
				}
				else
				{
					transform.RotateAround(transform.position, transform.forward, rotateSpeed * swing *Time.deltaTime);
				}
				player.GetComponent<Player>().TurnLeft();
			}
			
			
			if(Mathf.RoundToInt(transform.eulerAngles.z) >= Mathf.RoundToInt(lastRotation.z)+90){
				player.GetComponent<Player>().ready++;
				LeftFinish();
				lastRotation = transform.eulerAngles;
				toLeft = false;
			}
		}
	}
	
	void LeftFinish()
	{
		if(transform.eulerAngles.z > 80 && transform.eulerAngles.z < 115)
		{
			transform.eulerAngles = new Vector3(0, 0, 90);;
		}
		if(transform.eulerAngles.z > 179 && transform.eulerAngles.z < 181)
		{
			transform.eulerAngles = new Vector3(0, 0, 180);;
		}
		if(transform.eulerAngles.z > 269 && transform.eulerAngles.z < 271)
		{
			transform.eulerAngles = new Vector3(0, 0, 270);;
		}
		if((transform.eulerAngles.z > 0 && transform.eulerAngles.z < 16) || transform.eulerAngles.z > 358)
		{
			transform.eulerAngles = new Vector3(0, 0, 0);;
		}
		player.GetComponent<Player>().ready = 0;

		player.GetComponent<Player>().go();
		this.GetComponent<ScreenShake>().TeensyShake();
		this.GetComponent<ScreenShake>().sleep();
	}

	public bool cardinalAngles()
	{
		if(transform.eulerAngles.z >= 89 && transform.eulerAngles.z <= 91)
		{
			return true;
		}
		else if(transform.eulerAngles.z >= 179 && transform.eulerAngles.z <= 181)
		{
			return true;
		}
		else if(transform.eulerAngles.z >= 269 && transform.eulerAngles.z <= 271)
		{
			return true;
		}
		else if(transform.eulerAngles.z == 0)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	void turnRight()
	{
		if(Input.GetButtonDown("Right")){
			if(cardinalAngles())
			{
				toRight = true;
			}
		}
		if(toRight)
		{
			turnPause = originalTurnPause;
			if(!toLeft && 
			   Mathf.RoundToInt(transform.eulerAngles.z) != Mathf.RoundToInt(lastRotation.z)-90)
			{
				
				
				this.GetComponent<ScreenShake>().TeensyShake();
				if(lastRotation.z == 0)
				{
					rotateSpeed = 7;
					
					swing = Mathf.Abs(Mathf.RoundToInt(lastRotation.z)+270-Mathf.RoundToInt(transform.eulerAngles.z));
				}
				else
				{
					rotateSpeed = 5;
					swing = Mathf.Abs(Mathf.RoundToInt(lastRotation.z)-90-Mathf.RoundToInt(transform.eulerAngles.z));
				}
				if(this.GetComponent<CameraFollow>().VerticalFollowY || this.GetComponent<CameraFollow>().HorizontFollowY)
				{
				transform.RotateAround(player.transform.position, -transform.forward, rotateSpeed * swing *Time.deltaTime);
				}
				else
				{
					transform.RotateAround(transform.position, -transform.forward, rotateSpeed * swing *Time.deltaTime);
				}
				player.GetComponent<Player>().TurnRight();
			}
			
			if((Mathf.RoundToInt(transform.eulerAngles.z) <= Mathf.RoundToInt(lastRotation.z)-80) ||
			   ((Mathf.RoundToInt(transform.eulerAngles.z) >= 269 && Mathf.RoundToInt(transform.eulerAngles.z) <= 271) && player.GetComponent<Player>().directionFacing == 3)){
				player.GetComponent<Player>().ready++;
				RightFinish();
				lastRotation = transform.eulerAngles;
				toRight = false;
			}
		}
		//}
	}
	
	void RightFinish()
	{
		if(transform.eulerAngles.z > 250 && transform.eulerAngles.z < 283)
		{
			transform.eulerAngles = new Vector3(0, 0, 270);;
		}
		if(transform.eulerAngles.z > 160 && transform.eulerAngles.z < 200)
		{
			transform.eulerAngles = new Vector3(0, 0, 180);;
		}
		if(transform.eulerAngles.z > 89 && transform.eulerAngles.z < 101)
		{
			transform.eulerAngles = new Vector3(0, 0, 90);;
		}
		if(transform.eulerAngles.z > 0 && transform.eulerAngles.z < 11)
		{
			transform.eulerAngles = new Vector3(0, 0, 0);;
		}
		player.GetComponent<Player>().fixDirection(transform.eulerAngles.z);
		turnWatch.Start();
		
	}
	
}
