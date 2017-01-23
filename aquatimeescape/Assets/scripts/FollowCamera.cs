using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	public float distance;			// ターゲットとの距離
	public float rotAngle	;		// ターゲットを見る方向
	public Transform lookTarget;	// ターゲット情報
	public Vector3 offset;			// ターゲットと実際に見る方向とのオフセット
	public float maxCameraSpeed;

	private Transform last_transform;		// 前回のTransform

	InputManager inputManager;

	// Use this for initialization
	void Start () {
		inputManager = FindObjectOfType<InputManager> ();
		// カメラの座標と向きの初期値を求める
		Vector3 relativePos = Quaternion.Euler (lookTarget.eulerAngles.x, lookTarget.eulerAngles.y, 0) * new Vector3 ( 0, 6, -distance * 2);
		transform.position = lookTarget.position + (relativePos / 2);
		transform.LookAt (lookTarget.position);
		last_transform = transform;
	}

	// Update is called once per frame
	void Update () {
		float startCameraSpeed = maxCameraSpeed;

		if (lookTarget != null ) {
			// 目標座標
			Vector3 lookPosition = lookTarget.position + offset;
			// 向かうベクトルの算出
			Vector3 cameraNewPosition = Quaternion.Euler (lookTarget.eulerAngles.x, lookTarget.eulerAngles.y, 0) * new Vector3 ( 0, 6, -distance * 2);
			lookPosition += cameraNewPosition;
			// 距離を測る
			float now_distance;
			now_distance = Vector3.Distance (lookPosition, last_transform.position);
			// 一定距離以上離されたら追いかける
			if (now_distance > distance) {
				// 前回座標から今回向かう座標までの差分を算出
				Vector3 normalVec = lookPosition - last_transform.position;
				// 座標値を単位化
				normalVec = Vector3.Normalize (normalVec);
				// カメラの移動速度を掛けてカメラを移動
				if (inputManager.moved == true && maxCameraSpeed == startCameraSpeed) {
					normalVec *= maxCameraSpeed;
				} else if(inputManager.moved == false && maxCameraSpeed > startCameraSpeed) {
					normalVec *= maxCameraSpeed - 3;
				}

				// 前回の座標に移動量を加算
				transform.position = last_transform.position + normalVec;
			}
			// カメラをターゲットに向ける
			transform.LookAt (lookTarget.position);
			// 今回の座標を保存
			last_transform = transform;
		}
	}
}

