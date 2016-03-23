using UnityEngine;
using System.Collections;



public class ScreenShake : MonoBehaviour {

	public GameObject TheCamera;
	private Vector3 TheCameraInit;
	public double shake = 0;
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;
	private int stopper = 0; //0 = ready

	// Use this for initialization
	void Start () {
		if(TheCamera == null)
		{
			TheCamera = GameObject.Find("Main Camera");
		}
		TheCameraInit = TheCamera.transform.localPosition;
	}

	void startStopper(){
		if(stopper == 0){
			stopper++;
			///stopwatch.Start;
		}
	}

	float makeShakeAmount(){
		int choice = Random.Range(0, 2);

		if(choice == 0){
			return -shakeAmount;
		}else{
			return shakeAmount;
		}
	}

	// Update is called once per frame
	void Update () {
		if(shake > 0){
			TheCameraInit = TheCamera.transform.localPosition;
			TheCamera.GetComponent<CameraFollow>().shaking = true;
			TheCamera.transform.localPosition = new Vector3(TheCameraInit.x + (Random.value * makeShakeAmount()), TheCameraInit.y + (Random.value * makeShakeAmount()), TheCameraInit.z);
			shake -= Time.deltaTime * decreaseFactor;
		}else{
			shake=0;
			TheCamera.GetComponent<CameraFollow>().shaking = false;

		}
	}
	public void MicroShake() {
		shake = .005;
	}
	public void TeensyShake() {
		shake = .01;
	}
	public void WeensyShake() {
		shake = .05;
	}
	public void IttyShake() {
		shake = .10;
	}
	public void BittyShake() {
		shake = .10;
	}

	public void TinyShake(){
		shake = .5;
	}

	public void SmallShake () {
		shake = 1;
	}

	public void BigShake() {
		shake = 2;
	}

	public void sleep() {
		System.Threading.Thread.Sleep(10);
	}

}
