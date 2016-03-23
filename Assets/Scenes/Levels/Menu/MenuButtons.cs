using UnityEngine;
using System.Collections;

public class MenuButtons: MonoBehaviour {

	public int SceneToLoad;
	public GUITexture Button;

	// Use this for initialization
	void Start () {
		Button = gameObject.GetComponent<GUITexture>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount > 0)
		{
			for(int i = 0; i < Input.touchCount; i++)
			{
				Touch touch = Input.GetTouch(i);
				
				
				if(touch.phase == TouchPhase.Began &&   //Check If Left side of screen is pressed and turn camera left if true
				   Button.HitTest(touch.position))
				{
					Application.LoadLevel(SceneToLoad);
				}
			}
		}
	}
}
