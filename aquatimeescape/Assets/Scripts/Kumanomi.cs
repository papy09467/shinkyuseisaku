using UnityEngine;
using System.Collections;

public class Kumanomi : MonoBehaviour {
	public float rotationSpeed = 1f;
	float maxAngleX = 40;
	float minAngleX = -40;
	public static float movespeed = 0.1f;
	private bool maxaccel = false;
	public float maxspeed;
	public float accel = 0.1f;
	public static float defaltspeed = 0.1f;
	//public GameObject kumanomi;
	//public GameObject isogin;


	Rigidbody rb;
	CharacterController characterController;
	InputManager inputManager;

	//InputManager inputManager;

	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController> ();
		rb = GetComponent<Rigidbody> ();
		inputManager = FindObjectOfType<InputManager> ();


	}

	// Update is called once per frame
	void Update () {
		Vector3 direction = new Vector3 (Input.GetAxisRaw ("Mouse X"), Input.GetAxisRaw ("Mouse Y"), 0);
		//inputManager.GameStart ();
		direction.y = -direction.y;

		//縦回転制限
		float rotateX = (transform.eulerAngles.x  > 180)? transform.eulerAngles.x -360 : transform.eulerAngles.x;
		float angleX = Mathf.Clamp (rotateX + direction.y * rotationSpeed, minAngleX, maxAngleX);
		angleX = (angleX < 0) ? angleX + 360 : angleX;

		//横回転制限
		float rotateY = transform.eulerAngles.y;
		float angleY = rotateY + direction.x * rotationSpeed;

		//回転
		transform.rotation = Quaternion.Euler (angleX, angleY, 0);

		//加速
		if (Input.GetKeyDown (KeyCode.A) && maxaccel == false) {
			maxaccel = true;
			inputManager.Moved ();
		}

		if (Input.GetKeyUp (KeyCode.A)) {
			maxaccel = false;
			inputManager.MoveFin ();
		}

		//加速減速処理(maxaccel true or else)
		if (maxaccel == true) {
			if (movespeed < maxspeed) {
				movespeed += accel;
			}
		} else if (defaltspeed < movespeed) {
			movespeed -= accel;
		}

		//停止
		//if (Input.NotGetKey (Keycode.A) || Input.NotGetKey (Keycode.S)) {
		transform.position += transform.TransformDirection (Vector3.forward) * movespeed;
		//}

		/*Vector3 Apos = kumanomi.transform.position;
		Vector3 Bpos = isogin.transform.position;
		float dis = Vector3.Distance (Apos, Bpos);
		Debug.Log ("Distance : " + dis);

		//隠れる
		if (Distance <= 100) {
			print ("左クリックで隠れる");

			if (Input.GetKey (KeyCode.Mouse.Left)) {

				if (Input.GetKey (KeyCode.Mouse.Left)) {
					break;
				}
			}
		}*/
	}
}
	
	

