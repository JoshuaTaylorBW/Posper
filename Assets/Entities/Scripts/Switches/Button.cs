using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Button : MonoBehaviour {

	public bool Destroy;
	public GameObject DestroyedObject;
	public bool Build;
	public Transform ObjectBuilt;
	public Vector3 WhereToBuild;

	private Queue<Transform> objectQueue;		//queue that allows us to spawn the object
	private int created;						//has the object been created or destroyed? 0 = not yet 1 = done

	private GameObject player;
	private GameObject theCamera;

	private Animator animator;
	private int done = 0;



	// Use this for initialization
	void Start () {
		objectQueue = new Queue<Transform>(1);
		if(theCamera == null)
		{
			theCamera = GameObject.Find("Main Camera");
		}
		animator = this.GetComponent<Animator>();
		if(player == null)
		{
			player = GameObject.Find("Character");
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player")
		{
			if(done == 0)
			{
				animator.SetBool("On", true);
				if(Destroy)
				{
					DestroyEntity();
				}
				else if(Build)
				{
					BuildEntity();
				}
				done++;
			}
		}
	}

	// Update is called once per frame
	void Update () {
	
	}

	void DestroyEntity() {
		DestroyObject(DestroyedObject);
	}

	void BuildEntity() {
		if(created == 0)
		{
			objectQueue.Enqueue((Transform)Instantiate(
				ObjectBuilt, WhereToBuild, Quaternion.identity));
			created++;
		}
	}

}
