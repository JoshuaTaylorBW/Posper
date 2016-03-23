using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour {

	public bool TouchControls;
	public GUITexture LeftTouch, RightTouch;
	public GameObject Player;

	// Use this for initialization
	void Start () {
		if(Player == null)
		{
			Player = GameObject.Find("Character");
		}
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.touches.Length == 2)
		{
			Application.LoadLevel(1);
		}

		if(Input.touchCount > 0)
		{
			for(int i = 0; i < Input.touchCount; i++)
			{
				Touch touch = Input.GetTouch(i);

				
				if(Player.GetComponent<Player>().GameStarted)
				{
					if(touch.phase == TouchPhase.Began &&   //Check If Left side of screen is pressed and turn camera left if true
					   LeftTouch.HitTest(touch.position))
					{
						if(this.GetComponent<CameraSwing>().cardinalAngles())
						{
							this.GetComponent<CameraSwing>().toLeft = true;
						}
					}
					if(touch.phase == TouchPhase.Began &&
					   RightTouch.HitTest(touch.position))
					{
						if(this.GetComponent<CameraSwing>().cardinalAngles())
						{
						this.GetComponent<CameraSwing>().toRight = true;
						}
					}
				}

				if(!Player.GetComponent<Player>().GameStarted)
				{
					if(touch.phase == TouchPhase.Began)
					{
						Player.GetComponent<Player>().GameStarted = true;
					}
				}

			}
		}
	}
}
