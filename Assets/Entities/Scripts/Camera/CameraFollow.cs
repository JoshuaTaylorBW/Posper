using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public bool HorizontFollowX;				//do we want to follow the camera on the x axis
	public bool HorizontFollowY;				//do we want to follow the camera on the y axis

	public bool VerticalFollowX;				//do we want to follow the camera on the x axis
	public bool VerticalFollowY;

	public Vector3 CameraInit;

	public float difference;			//for vert follow y. do we need to move the camera extra?

	[HideInInspector]
	public bool shaking; 				//is the camera currently going through screen shake?

	public GameObject Player;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find("Character");
		CameraInit = this.transform.position;
	}

	void HorizontalShake()
	{
		if(HorizontFollowX && HorizontFollowY)
		{
			if((transform.eulerAngles.z > 89 && transform.eulerAngles.z < 91)  || (transform.eulerAngles.z > 269 && transform.eulerAngles.z < 271))
			{
				Debug.Log("aksdjf");
				transform.position = new Vector3(Player.transform.position.x,
				                                 Player.transform.position.y,
				                                 CameraInit.z
				                                 );
			}
		}
		if(!HorizontFollowX && HorizontFollowY)
		{
			if((transform.eulerAngles.z > 89 && transform.eulerAngles.z < 91)  || (transform.eulerAngles.z > 269 && transform.eulerAngles.z < 271))
			{
				transform.position = new Vector3(CameraInit.x,
				                                 Player.transform.position.y,
				                                 CameraInit.z
				                                 );
			}
		}
		if(HorizontFollowX && !HorizontFollowY)
		{
			if((transform.eulerAngles.z > 89 && transform.eulerAngles.z < 91)  || (transform.eulerAngles.z > 269 && transform.eulerAngles.z < 271))
			{
				transform.position = new Vector3(Player.transform.position.x,
				                                 CameraInit.y,
				                                 CameraInit.z
				                                 );
			}
		}
		if(!HorizontFollowX && !HorizontFollowY)
		{
			if((transform.eulerAngles.z > 89 && transform.eulerAngles.z < 91)  || (transform.eulerAngles.z > 269 && transform.eulerAngles.z < 271))
			{
				transform.position = new Vector3(CameraInit.x,
				                                 CameraInit.y,
				                                 CameraInit.z
				                                 );
			}
		}
	}

	void VerticalShake()
	{
		if(VerticalFollowX && VerticalFollowY)
		{
			if(transform.eulerAngles.z == 0 || (transform.eulerAngles.z > 179 && transform.eulerAngles.z < 181))
			{
				transform.position = new Vector3(Player.transform.position.x,
				                                 Player.transform.position.y,
				                                 CameraInit.z
				                                 );
			}
		}
		if(!VerticalFollowX && VerticalFollowY)
		{
			if(transform.eulerAngles.z == 0 || (transform.eulerAngles.z > 179 && transform.eulerAngles.z < 181))
			{
				transform.position = new Vector3(CameraInit.x,
				                                 Player.transform.position.y + difference,
				                                 CameraInit.z
				                                 );
			}
		}
		if(VerticalFollowX && !VerticalFollowY)
		{
			if(transform.eulerAngles.z == 0 || (transform.eulerAngles.z > 179 && transform.eulerAngles.z < 181))
			{
				transform.position = new Vector3(Player.transform.position.x,
				                                 CameraInit.y,
				                                 CameraInit.z
				                                 );
			}
		}

		if(!VerticalFollowX && !VerticalFollowY)
		{
			if(transform.eulerAngles.z == 0 || (transform.eulerAngles.z > 179 && transform.eulerAngles.z < 181))
			{
				transform.position = new Vector3(CameraInit.x,
				                                 CameraInit.y,
				                                 CameraInit.z
				                                 );
			}
		}


	}

	// Update is called once per frame
	void Update () {
	if(!shaking)
		{
			HorizontalShake();
			VerticalShake();
		}
	}
}
