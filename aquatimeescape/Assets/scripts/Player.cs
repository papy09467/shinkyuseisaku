using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float movespead = 5f;
	public float rotationSpeed = 360f;

	CharacterController characterController;

	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = new Vector3 (Input.GetAxisRaw ("Mouse X"), Input.GetAxisRaw ("Mouse Y"), 0);
		if (Input.GetMouseButton (1)) {
			if (direction.sqrMagnitude > 0.01f) {
				Vector3 turn = Vector3.Slerp (transform.forward, direction, rotationSpeed * Time.deltaTime / Vector3.Angle (transform.forward, direction));
				transform.LookAt (transform.position + turn);
			}
		}
	}
}
