using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	public float distance = 5.0f;
	public float horizontalAngle = 0.0f;
	public float rotAngle = 180.0f;
	public float verticalAngle = 10.0f;
	public Transform lookTarget;
	public Vector3 offset = Vector3.zero;

	GameObject player;


	InputManager inputManager;

	// Use this for initialization
	void Start () {
		inputManager = FindObjectOfType<InputManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		//float anglePerPixel = rotAngle / (float)Screen.width;
		//Vector2 delta = inputManager.GetDeltaPosition ();
		//horizontalAngle += delta.x * anglePerPixel;
		//horizontalAngle = Mathf.Repeat (horizontalAngle, 360.0f);
		//verticalAngle -= delta.y * anglePerPixel;
		//verticalAngle = Mathf.Clamp (verticalAngle, -60.0f, 60.0f);

		if (lookTarget != null) {
			Vector3 lookPosition = lookTarget.position + offset;
			Vector3 relativePos = Quaternion.Euler (verticalAngle, horizontalAngle, 0) * new Vector3 (0, 0, -distance);
			transform.position =lookPosition + relativePos;

			transform.LookAt (lookPosition);
		}
	}
	public void SetTarget(Transform target){
		lookTarget = target;
	}
}
