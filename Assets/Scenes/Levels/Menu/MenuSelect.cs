using UnityEngine;
using System.Collections;

public class MenuSelect : MonoBehaviour {

	public GUITexture Play, Exit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount > 0)
		{
			for(int i = 0; i < Input.touchCount; i++)
			{
				Touch touch = Input.GetTouch(i);
				

					if(touch.phase == TouchPhase.Began &&   //Check If Left side of screen is pressed and turn camera left if true
					   Play.HitTest(touch.position))
					{
						Application.LoadLevel(2);
					}
					if(touch.phase == TouchPhase.Began &&
					   Exit.HitTest(touch.position))
					{
					Application.Quit();
					}
				}
			}
		}
	}
