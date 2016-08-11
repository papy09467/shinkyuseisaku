using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	GameObject CameraParent;

	Vector3	defaultPosition;
	Quaternion defaultRotation;
	float defaultZoom;

	// Use this for initialization
	void Start () {
		CameraParent = GameObject.Find("CameraParent");

		//デフォルト位置を保存
		defaultPosition = Camera.main.transform.position;
		defaultRotation = CameraParent.transform.rotation;
		defaultZoom = Camera.main.fieldOfView;
	}
	
	// Update is called once per frame
	void Update () {
		
		//カメラ回転
		if( Input.GetMouseButton(1) ){

			Camera.main.transform.Rotate(Input.GetAxisRaw("Mouse Y") * 10, Input.GetAxisRaw("Mouse X") * 10, 0);
		}

		Camera.main.fieldOfView += (20 * Input.GetAxis ("Mouse ScrollWheel"));

		if (Camera.main.fieldOfView < 10) {
			Camera.main.fieldOfView = 10;
		}

		if (Input.GetMouseButton (2)) {

			Camera.main.transform.position = defaultPosition;
			CameraParent.transform.rotation = defaultRotation;
			Camera.main.fieldOfView = defaultZoom;
		}
	}
}
