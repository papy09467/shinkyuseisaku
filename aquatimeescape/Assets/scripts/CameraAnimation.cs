using UnityEngine;
using System.Collections;

public class CameraAnimation : MonoBehaviour
{
	private Transform myTransform;
	public Transform target;
	public float degrees = 10.0f;

	GameObject cameraParent;

	Vector3 defaultPosition;
	Quaternion defaultRotation;
	float defaultZoom;

	void Awake ()
	{
		myTransform = transform;
	}

	// Use this for initialization
	void Start ()
	{
		cameraParent = GameObject.Find("CameraParent");

		defaultPosition = Camera.main.transform.position;
		defaultRotation = cameraParent.transform.rotation;
		defaultZoom = Camera.main.fieldOfView;
	}

	// Update is called once per frame
	void Update ()
	{
		//カメラ移動
		Vector3 relativePos = target.position - myTransform.position;
		Quaternion rotation = Quaternion.LookRotation(relativePos);
		myTransform.rotation = rotation;
		if (Input.GetMouseButton (1)) {
			myTransform.RotateAround (target.position, Vector3.up, degrees * Input.GetAxisRaw("Mouse X"));
			myTransform.RotateAround (target.position, Vector3.right, degrees * Input.GetAxisRaw("Mouse Y"));
		}

		//ズームインズームアウト
		Camera.main.fieldOfView += (20 * Input.GetAxis("Mouse ScrollWheel"));

		if (Camera.main.fieldOfView < 10) {
			
			Camera.main.fieldOfView = 10;

		}

		if (Camera.main.fieldOfView > 100) {

			Camera.main.fieldOfView = 100;

		}

		if (Input.GetMouseButton (2)) {
			Camera.main.transform.position = defaultPosition;
			cameraParent.transform.rotation = defaultRotation;
			Camera.main.fieldOfView = defaultZoom;
		}
	}
}