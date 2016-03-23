using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;

public class Triggers : MonoBehaviour {

	public GameObject player;
	public GameObject theCamera;
	
	public Transform Explosion;
	private Queue<Transform> ExplosionQueue;		//queue that allows us to spawn the explosion

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
		ExplosionQueue = new Queue<Transform>(1);
		if(player == null)
		{
			player = GameObject.Find("Character");
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player")
		{

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


	// Update is called once per frame
	void Update () {
		if(deathWatch.ElapsedMilliseconds >= 1500)
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
