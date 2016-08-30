using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float rotationSpeed = 2f;
	float maxAngle = 40;
	float minAngle = -40;
	public float movespeed = 5f;

	CharacterController characterController;

	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController> ();
	}

	// Update is called once per frame
	void Update () {
		Vector3 direction = new Vector3 (Input.GetAxisRaw ("Mouse X"), Input.GetAxisRaw ("Mouse Y"), 0);
		direction.y = -direction.y;

		//縦回転制限
		float rotateX = (transform.eulerAngles.x  > 180)? transform.eulerAngles.x -360 : transform.eulerAngles.x;
		float angleX = Mathf.Clamp (rotateX + direction.y * rotationSpeed, minAngle, maxAngle);
		angleX = (angleX < 0) ? angleX + 360 : angleX;

		//横回転制限
		float rotateY = (transform.eulerAngles.y  > 180)? transform.eulerAngles.y -360 : transform.eulerAngles.y;
		float angleY = Mathf.Clamp (rotateY + direction.x * rotationSpeed, minAngle, maxAngle);
		angleY = (angleY < 0) ? angleY + 360 : angleY;

		//回転
		transform.rotation = Quaternion.Euler (angleX, angleY, 0);

	}
}
