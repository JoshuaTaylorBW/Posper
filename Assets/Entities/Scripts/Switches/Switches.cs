using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;

public class Switches : MonoBehaviour {

	public GameObject player;
	public GameObject SwitchManager;
	public GameObject theCamera;

	public Transform Explosion;
	private Queue<Transform> ExplosionQueue;		//queue that allows us to spawn the explosion

	private Animator animator;
	private int done = 0;
	public int exited = 0;				//has the player left the collision?
	public Stopwatch deathWatch;

	// Use this for initialization
	void Start () {

		deathWatch = new Stopwatch();
		if(theCamera == null)
		{
			theCamera = GameObject.Find("Main Camera");
		}
		if(SwitchManager == null)
		{
			SwitchManager = GameObject.Find("SwitchManager");
		}
		ExplosionQueue = new Queue<Transform>(SwitchManager.GetComponent<SwitchManager>().amountOfSwitches);
		animator = this.GetComponent<Animator>();
		if(player == null)
		{
			player = GameObject.Find("Character");
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player")
		{
			if(exited == 0)
			{
				if(done == 0)
				{
					SwitchManager.GetComponent<SwitchManager>().Switched();
					animator.SetBool("On", true);
					done++;
				}
			}
			else if(exited > 0)
			{
				//makes the explosion
				ExplosionQueue.Enqueue((Transform)Instantiate(
					Explosion, new Vector3(this.transform.position.x,
				                       		this.transform.position.y,
				                       			-5),
												Quaternion.identity));

				//move the player on the z axis.. looks like he "disappears"
				player.transform.position = new Vector3(player.transform.position.x,
				                                        player.transform.position.y,
				                                        12);
				//shake the camera
				theCamera.GetComponent<ScreenShake>().SmallShake();
				deathWatch.Start();

			}
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if(col.gameObject.tag == "Player")
		{
			UnityEngine.Debug.Log("Left");
			exited++;
		}
	}

	// Update is called once per frame
	void Update () {
		if(deathWatch.ElapsedMilliseconds >= 1500)
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
