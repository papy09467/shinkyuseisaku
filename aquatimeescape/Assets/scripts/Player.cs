using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float rotationSpeed = 1f;
	float maxAngleX = 60;
	float minAngleX = -60;
	float maxAngleY = 60;
	float minAngleY = -60;
	public float movespeed = 0.1f;
	private bool maxaccel = false;
	public float maxspeed;
	public float accel = 0.1f;
	float defaltspeed = 0.1f;

	Rigidbody rb;
	CharacterController characterController;


	//InputManager inputManager;

	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController> ();
		rb = GetComponent<Rigidbody> ();
		//inputManager = FindObjectOfType<InputManager> ();
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
		float rotateY = (transform.eulerAngles.y  > 180)? transform.eulerAngles.y -360 : transform.eulerAngles.y;
		float angleY = Mathf.Clamp (rotateY + direction.x * rotationSpeed, minAngleY, maxAngleY);
		angleY = (angleY < 0) ? angleY + 360 : angleY;

		//回転
		transform.rotation = Quaternion.Euler (angleX, angleY, 0);

		if (Input.GetKeyDown (KeyCode.A) && maxaccel == false) {
			maxaccel = true;
		}

		if (Input.GetKeyUp (KeyCode.A)) {
			maxaccel = false;
		}

		if (maxaccel == true) {
			if (movespeed < maxspeed) {
				movespeed += accel;
			}
		} else if (defaltspeed <= movespeed ){
			movespeed -= accel;
		}

		transform.position += transform.TransformDirection (Vector3.forward) * movespeed;

	}
}
